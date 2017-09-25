using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using log4net;
using System.Configuration;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CustomerDataUpdateSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // 処理状態を書き換える入れ物（エラーがあるとlog情報に追記します。）
        string processingContent = "";
        // SQL　UPDATE時に何件更新できたかを確認するための入れ物
        int _countNumber = 0;
        

        // log4net
        static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType); // log4netを使用する時に動作します

        // [ENTER]キーで次の項目にに移動できるようにします
        [System.Security.Permissions.UIPermission(
            System.Security.Permissions.SecurityAction.Demand,
            Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]

        
        // EnterキーをTabキーと同じようにする
        protected override bool ProcessDialogKey(Keys keyData)
        {
            // Returnキーが押されているか調べます
            // AltかCtrlキーが押されている時は、本来の動作をさせます
            if (((keyData & Keys.KeyCode) == Keys.Return) &&
                ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
            {
                // Tabキーを押した時と同じ動作をさせます
                // Shiftキーが押されている時は、逆順にします
                this.ProcessTabKey((keyData & Keys.Shift) != Keys.Shift);
                // 本来の処理はさせない
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private string change_str(string strBuf, out int cnt, ref int kflg)
        {
            // 処理状態の初期化をします。
            processingContent = "";

            processingContent = "change_str-1: 処理を開始します。";
            var sb = new StringBuilder();
            //str_buf = str_buf.Replace("\n", "|");

            var buf = new char[1];
            //var chars = new StringBuilder();
            //var isLineEnd = false;
            int kanmaFlg = kflg;
            if (kflg != 0)
            {
                buf[0] = '|';
                sb.Append(buf);
            }

            // フラグが０の時の["]  フラグが１の時の["]     （条件)
            //       ↓                 ↓
            // ----------------------------------------------------
            //        "    24  ,  25    "   (CSV)
            // ----------------------------------------------------
            //       ↑       ↑        ↑
            //     フラグ   フラグ=1  フラグ               flgの処理
            //       0        の        1
            //       ↓       ↓        ↓
            //       1    カンマ[,]     0
            processingContent = "change_str-2: １文字ずつ検査し区切りカンマでなく文字としてのカンマは中黒に変更する処理をします。";
            for (int i = 0; i < strBuf.Length; i++)
            {
                buf[0] = strBuf[i];

                if (kanmaFlg == 1 && buf[0] == ',')
                {
                    buf[0] = '・';
                    sb.Append(buf);
                }
                else if (kanmaFlg == 0 && buf[0] == '"')
                {
                    kanmaFlg = 1;
                }
                else if (kanmaFlg == 1 && buf[0] == '"')
                {
                    kanmaFlg = 0;
                }
                else
                {
                    sb.Append(buf);
                }
            }
            string[] item = sb.ToString().Split(',');

            cnt = item.Length - 1;

            kflg = kanmaFlg;

            return sb.ToString();
        }

        private string CsvReadOne(StreamReader sw, int kanmaNum)
        {
                processingContent = "";
                processingContent = "CsvReadOne-1：処理を開始します。";
                int kanmaCnt = 0;
                int kanmaCnt2 = 0;
                string lin = sw.ReadLine("\r\n");
                string lin2 = "";
                int kflg = 0;
                int loopCnt = 0;

                lin = change_str(lin, out kanmaCnt, ref kflg);
                // 読み込んだ項目数がヘッダーの項目数よりも少ない場合の処理＝途中で改行されている場合の処理
                processingContent = "CsvReadOne-2：読み込んだ項目数がヘッダーの項目数よりも少ない場合の処理＝途中で改行されている場合の処理。";
                while (kanmaCnt < kanmaNum)
                {
                    kanmaCnt2 = 0;
                    lin2 = sw.ReadLine("\r\n");
                    lin2 = change_str(lin2, out kanmaCnt2, ref kflg);
                    lin += lin2;
                    kanmaCnt += kanmaCnt2;

                    // 無限にループするのを防止するための処理
                    processingContent = "CsvReadOne-2：無限にループするのを防止するための処理。";
                    if (loopCnt++ >= 100)
                    {
                        //// 例外エラー
                        Exception userException = new Exception("システムエラー・CSV読み込み中" + Environment.NewLine +
                                                                processingContent + 
                                                                "（CSVデータ、改行後の項目数が少なすぎます。顧客データに改行が100以上入力されています。）" +
                                                                Environment.NewLine + "エラー予約情報:" +
                                                                Environment.NewLine + lin + "です。");
                        throw userException;
                    }
                }
                return lin;          
        }

        // <summary>
        // 指定されたファイルがロックされているかどうかを返します。
        // </summary>
        // <param name="path">検証したいファイルへのフルパス</param>
        // <returns>ロックされているかどうか</returns>
        private bool IsFileLocked(string path)
        {
            FileStream stream = null;

            try
            {
                stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch
            {
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return false;
        }

        private void CSV_read(string readfilename)
        {
            processingContent = "";
            processingContent = "CSV_read-1：処理を開始します。";
            int linCnt = 0;

            // 別で開いているときのエラー表示を作る
            processingContent = "CSV_read-2 : 他のプロセスで使用しているかファイルを開き確認処理を行います。";
            bool FileLockedFlg = IsFileLocked(readfilename);
            if (FileLockedFlg == true)
            {
              string FileLockInfo = "※※ファイルロック確認中のエラー" + Environment.NewLine +
                                                        processingContent +
                                                        "別のプロセスで使用中の為使用できません。終了してから再度実行してください。";
                MessageBox.Show(FileLockInfo);
                //アプリケーションを終了する
                Application.Exit();
            }
            else
            {
                int dataProcessing = 0;
                int jumpRow = 0;

                processingContent = "CSV_read-3 :ファイルロック確認完了後ファイルを開き処理を開始します。";
                using (var sw = new StreamReader(readfilename, System.Text.Encoding.GetEncoding("shift_jis")))
                {
                    try
                    {
                        // 先頭から処理を行わない行数と処理を行う行数を取得
                        //string strDataProcessing = ConfigurationManager.AppSettings.Get("dataProcessing");
                        //int dataProcessing = int.Parse(strDataProcessing);      // データを処理する行数

                        string strDataProcessing = textBoxDataProcessing.Text;

                        processingContent = "CSV_read-4 :ﾃﾞｰﾀを処理する行数のテキストボックス値が数字で入力されているか確認します。";
                        if (!(Regex.Match(strDataProcessing, "[0-9]")).Success)
                        {
                            dataProcessing = 0;
                            processingContent = "CSV_read-5 :ﾃﾞｰﾀを処理する行数のテキストボックス値が数字で入力されていない為、0を入力しました。";
                        }
                        else
                        {
                            processingContent = "CSV_read-6 :ﾃﾞｰﾀを処理する行数のテキストボックス値が数字で入力されているか確認が完了しました。";
                            dataProcessing = int.Parse(strDataProcessing);
                        }
                        // string strjumpRow = ConfigurationManager.AppSettings.Get("jumpRow");
                        // int jumpRow = int.Parse(strjumpRow);                   // 先頭から飛ばす行数

                        string strJumpRow = textBoxJumpRow.Text;
                        processingContent = "CSV_read-7 :先頭から飛ばす行数のテキストボックス値が数字で入力されているか確認します。";
                        if (!(Regex.Match(strJumpRow, "[0-9]")).Success)
                        {
                            dataProcessing = 0;
                            processingContent = "CSV_read-8 :先頭から飛ばす行数のテキストボックス値が数字で入力されていない為、ﾃﾞｰﾀを処理する行数に0を入力しました。";
                        }
                        else
                        {
                            processingContent = "CSV_read-9 :先頭から飛ばす行数のテキストボックス値が数字で入力されているか確認が完了しました。";
                            jumpRow = int.Parse(strJumpRow);
                        }

                        // プログレスバーの初期設定
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = dataProcessing + jumpRow;
                        progressBar1.Value = 0;

                        labelInfo.Text = "進捗状況：";

                        dataGridView1.Rows.Clear();

                    }
                    catch (Exception ex)
                    {
                        Logger.Fatal(ex.Message + processingContent);
                    }

                    // 先頭行は「顧客」と入っているだけなので読み飛ばします。
                    processingContent = "CSV_read-10 :先頭行は「顧客」と入っているだけなので読み飛ばします。";
                    sw.ReadLine();
                    try
                    {
                        // ヘッダーを読み込みます。
                        processingContent = "CSV_read-11 :ヘッダーを読み込みます。";
                        string lin = sw.ReadLine("\r\n");

                        // ヘッダーから項目数を算出します。
                        processingContent = "CSV_read-12 :ヘッダーから項目数を算出します。";
                        int kanmaNum = 0;
                        var values = lin.Split(',');
                        kanmaNum = values.Length - 1;

                        if (kanmaNum <= 1)
                        {
                            // 例外エラー
                            Exception user_exception = new Exception("システムエラー・CSV読み込み中（CSVデータのヘッダー項目数が少なすぎます。）" + "動作情報" + processingContent);
                            throw user_exception;
                        }
                        // 総件数取得します
                        while (!sw.EndOfStream)
                        {
                            lin = CsvReadOne(sw, kanmaNum);
                            linCnt += 1;

                            // プログレスバーの値を変更します。
                            processingContent = "CSV_read-13 :プログレスバーの値を変更します。";
                            progressBar1.Value = linCnt;
                            progressBar1.Update();

                            labelInfo.Text = "進捗状況：　" + dataProcessing + "件中" + textBoxCountNumber.Text + "件読み込み中";
                            labelInfo.Update();

                            // 指定された１回で読み取る件数まで処理します。

                            if (linCnt > jumpRow)
                            {
                                // valuesに代入してdataGridViewにInsertします。
                                DataGridViewInsert(lin, sw);
                            }

                            // 読み込み終了判定
                            if (linCnt >= (jumpRow + dataProcessing))
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // 設定した行数のテストボックス両方に数字じゃない値が入った時はここのcatchに入ります。
                        Logger.Fatal(ex.Message + processingContent);
                        string strErrorVisitDate = DateTime.Now.ToString();
                        InfoMail.error_mail(ex.Message, strErrorVisitDate, processingContent);
                    }
                    finally
                    {
                        // SqlServerClient.CloseSqlSever();
                        sw.Close();
                        //System.IO.File.Delete(readfilename);
                        int dtNum = dataGridView1.RowCount;
                        labelInfo.Text = "進捗状況：　" + dataProcessing + "件中" + dtNum + "件のデータを読み込みました。";

                        labelUpdateInfo.Visible = true;
                        labelUpdateInfo.Text = "サーバーの更新完了件数は" + textBoxCountNumber.Text + "件でした。";

                        string infoMailText = "更新情報結果報告" + Environment.NewLine + "読み込み件数(トータル)" + dataProcessing + "件" +
                                              Environment.NewLine + "読み込み更新開始位置" + jumpRow + "行目から読み取り更新しました。" +
                                              Environment.NewLine +
                                              "顧客メモに顧客IDのなかった件数" + (dataProcessing - dtNum) + "件です。";
                        string strErrorVisitDate = DateTime.Now.ToString();
                        InfoMail.info_mail(strErrorVisitDate, infoMailText, processingContent);
                        buttonUpdateGo.Enabled = true;
                    }
                }
            }
        }

        private void DataGridViewInsert(string lin　, StreamReader sw)
        {
            // 読み込んだ一行をカンマ毎に分けて配列に格納する        
            var values = lin.Split(',');

            processingContent = "";
            processingContent = "DataGridViewInsert-1：処理を開始します。";
            int intFindPos = 0;
            int NoUpdateCount = 0;
            // 行の挿入
            processingContent = "DataGridViewInsert-2：行の挿入をします。";
            dataGridView1.Rows.Insert(0);
            try
            {
                for (int i = 0; i < values.GetLength(0); i++)
                {

                    Boolean break_flg = false;

                    // もし[i]がDataGridViewの列数に達していなければ下記を動作させる
                    processingContent = "DataGridViewInsert-3：もし[i]がDataGridViewの列数に達していなければ下記を動作させます。";
                    if (i < dataGridView1.Columns.Count)
                    {
                        switch (i)
                        {

                            // 顧客IDを取得しdataGridViewに表示します。
                            case 0:
                                processingContent = "DataGridViewInsert-4：case0";
                                string afters0 = values[i].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[0].Value = values[i];
                                break;

                            // 氏（あ・ア・A）を取得しdataGridViewに表示します。
                            case 1:
                                processingContent = "DataGridViewInsert-5：case1";
                                string afters1 = values[i].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[1].Value = values[i];
                                break;

                            // 名（あ・ア・A）を取得しdataGridViewに表示します。
                            case 2:
                                processingContent = "DataGridViewInsert-6：case2";
                                string afters2 = values[i].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[2].Value = values[i];
                                break;

                            // 氏（漢字）を取得しdataGridViewに表示します。
                            case 3:
                                processingContent = "DataGridViewInsert-7：case3";
                                string afters3 = values[i].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[3].Value = values[i];
                                break;

                            // 名（漢字）を取得しdataGridViewに表示します。
                            case 4:
                                processingContent = "DataGridViewInsert-8：case4";
                                string afters4 = values[i].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[4].Value = values[i];
                                break;

                            // 会社名を取得しdataGridViewに表示します。
                            case 5:
                                processingContent = "DataGridViewInsert-9：case5";
                                string afters6 = values[6].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[5].Value = values[6];
                                break;

                            // 電話を取得しdataGridViewに表示します。
                            case 6:
                                processingContent = "DataGridViewInsert-10：case6";
                                string afters24 = values[24].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[6].Value = values[24];
                                break;

                            // メルマガを取得しdataGridViewに表示します。
                            case 7:
                                processingContent = "DataGridViewInsert-11：case7";
                                string afters32 = values[32].Replace(" ", "");
                                dataGridView1.Rows[0].Cells[7].Value = values[32];
                                break;

                            // 顧客メモ欄の顧客ID６桁を取得しdataGridViewに表示します。
                            case 8:
                                processingContent = "DataGridViewInsert-12：case8";
                                string afters49 = values[49].Replace(" ", "");
                                // 顧客IDだけを取得します
                                int charCount = 0;
                                string IdSearch = "顧客ID:";
                                intFindPos = afters49.IndexOf(IdSearch, StringComparison.Ordinal);
                                if (intFindPos >= 0)
                                {
                                    int intAlldata = afters49.Length;
                                    intAlldata = intAlldata - intFindPos;
                                    string idData = afters49.Substring(intFindPos, intAlldata).Trim();

                                    string idDataProcessing = idData.Substring(5, idData.Length - 5);

                                    foreach (char idDataProcessings in idDataProcessing)
                                    {
                                        if (char.IsNumber(idDataProcessings))
                                        {
                                            charCount += 1;
                                        }
                                        else
                                        {
                                            idDataProcessing = idDataProcessing.Substring(0, charCount);
                                            break;                                            
                                        }
                                    }
                                    if (charCount == 0)
                                    {
                                        dataGridView1.Rows.RemoveAt(0);
                                        // Removeしたデータの顧客IDを取得します
                                        string RemoveMemo1 = values[0];

                                    }
                                    else
                                    {
                                        processingContent = "DataGridViewInsert-13：case8処理　顧客IDの桁を整理する処理を行います。";
                                        string idSet = "000000" + idDataProcessing;
                                        string idSetData = idSet.Substring(idSet.Length - 6, 6);
                                        dataGridView1.Rows[0].Cells[8].Value = idSetData;
                                        string tsCustomerId = values[0];
                                        string nameNo1 = values[1];
                                        string nameNo2 = values[2];
                                        string nameNo3 = values[3];
                                        string nameNo4 = values[4];
                                        string companyName = values[6];
                                        string telNumber = values[24];
                                        //string mailMagazine = values[32];
                                        //if (mailMagazine == "FALSE")
                                        //{
                                        //    mailMagazine = "0";
                                        //}
                                        //else if(mailMagazine == "TRUE")
                                        //{
                                        //    mailMagazine = "1";
                                        //}
                                        //else
                                        //{
                                        //    // TSからのデータが TRUE / FALSE 以外の時　エラー
                                        //}
                                        string customerId = idSetData;
                                        DateTime updateDate = DateTime.Now;
                                        //  mailMagazine,
                                        processingContent = "DataGridViewInsert-14：SQLSERVERに更新処理を行います。";
                                        int cnt = SqlServerClient.CustomerUpdateSql(tsCustomerId,nameNo1, nameNo2, nameNo3, nameNo4, companyName, telNumber, customerId, updateDate);

                                        if (cnt == 0)
                                        {
                                            processingContent = "DataGridViewInsert-15：更新できなかった時の処理を行います。";
                                            NoUpdateCount += 1;
                                        }
                                        else
                                        {
                                            processingContent = "DataGridViewInsert-16：更新した件数の確認を行います。";
                                            _countNumber += (cnt / 18);
                                            textBoxCountNumber.Text = _countNumber.ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    dataGridView1.Rows.RemoveAt(0);
                                    // Removeしたデータの顧客IDを取得します
                                    string RemoveMemo2 = values[0];
                                }
                                break;

                            default:
                                break;
                        } // switch文 end
                    } //if文 end
                    if (break_flg == true)
                    {
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // エラー処理
                dataGridView1.Rows.RemoveAt(0);
                Logger.Fatal(ex.Message);
                string strErrorVisitDate = DateTime.Now.ToString();
                InfoMail.error_mail(ex.Message, strErrorVisitDate, processingContent);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                    // CSVファイルの読み込みを開始します。
                    var readFilename = ConfigurationManager.AppSettings.Get("read_filename");
            if (File.Exists(readFilename))
            {
                // CSV→dataGridViewに全てのデータをコピーします。
                CSV_read(readFilename);
            }
            else
            {
                string InfoText = "進捗状況： データが見つかりませんでした。";
                labelInfo.Text = InfoText;
            }
        }

        private void button1_Enter(object sender, EventArgs e)
        {
            labelUpdateInfo.Text = "";
            labelUpdateInfo.Visible = false;
            buttonUpdateGo.Enabled = false;
                // CSVファイルの読み込みを開始します。
                var readFilename = ConfigurationManager.AppSettings.Get("read_filename");
                if (File.Exists(readFilename))
                {
                    // CSV→dataGridViewに全てのデータをコピーします。
                    CSV_read(readFilename);
                }
                else
                {
                    string InfoText = "進捗状況： データが見つかりませんでした。";
                    labelInfo.Text = InfoText;
                }
        }
    }
}