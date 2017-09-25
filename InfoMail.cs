using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CustomerDataUpdateSystem
{
    class InfoMail
    {
        // クリティカルなエラーが発生した場合メールを送信します。
        public static void error_mail(string errorMsg, string strErrorVisitDate, string processingContent)
        {
            //MailMessageの作成  (メールアドレス送信アカウント, 送信先メールアドレス, 件名, 本文)
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("hanamura@bridge.vc", "hanamura@bridge.vc", "顧客更新システムのエラー情報", "発生日時: " + strErrorVisitDate + Environment.NewLine + 
            "詳細内容: " + errorMsg + Environment.NewLine + "処理内容: " + processingContent);
            System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
            //SMTPサーバーなどを設定する
            sc.Host = "mail35.heteml.jp";
            sc.Port = 587;
            sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //ユーザー名とパスワードを設定する
            sc.Credentials = new System.Net.NetworkCredential("hanamura", "222222");
            //メッセージを送信する
            sc.Send(msg);
            //後始末
            msg.Dispose();
            //後始末（.NET Framework 4.0以降）
            sc.Dispose();
        }

        public static void info_mail(string strErrorVisitDate, string infoMailText, string processingContent)
        {
            //MailMessageの作成  (メールアドレス送信アカウント, 送信先メールアドレス, 件名, 本文)
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage("hanamura@bridge.vc", "hanamura@bridge.vc", "顧客更新システムの更新結果情報", "更新日時：" + strErrorVisitDate + Environment.NewLine +
                                                         infoMailText + "処理内容" + processingContent);
            System.Net.Mail.SmtpClient sc = new System.Net.Mail.SmtpClient();
            //SMTPサーバーなどを設定する
            sc.Host = "mail35.heteml.jp";
            sc.Port = 587;
            sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //ユーザー名とパスワードを設定する
            sc.Credentials = new System.Net.NetworkCredential("hanamura", "222222");
            //メッセージを送信する
            sc.Send(msg);
            //後始末
            msg.Dispose();
            //後始末（.NET Framework 4.0以降）
            sc.Dispose();
        }
    }
}
