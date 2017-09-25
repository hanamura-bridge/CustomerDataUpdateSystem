using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CustomerDataUpdateSystem
{
    class SqlServerClient
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = null;

            try
            {
                // 接続文字列をApp.configから取得します
                var connectionString = ConfigurationManager.ConnectionStrings["daitoukigyou"].ConnectionString;

                con = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                con = null;
                throw (ex);
            }
            return con;
        }

        public static void CloseConnection(SqlConnection con)
        {
            try
            {
                if (con != null)
                {
                    con.Close();
                    con = null;
                }
            }
            catch (Exception ex)
            {
                con = null;
                throw (ex);
            }
        }
        //  string mailMagazine,
        public static int CustomerUpdateSql(string tsCustomerId, string nameNo1, string nameNo2, string nameNo3, string nameNo4, string companyName, string telNumber, string customerId, DateTime updateDate)
        {
            int rslt = -1;
            //  isMail1 = @mailMagazine,
            string query = @" UPDATE [dbo].[M_Member] SET TSmemberCD = @tsCustomerId, kana_sei = @nameNo1 , kana_mei = @nameNo2 , kanji_sei = @nameNo3 , kanji_mei = @nameNo4 , companyName = @companyName, phone = @telNumber, UpdDT = @updateDate WHERE id = @customerId";
            using (var connection = GetConnection())
            {
                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = connection.CreateCommand();
                adapter.SelectCommand.CommandText = query;

                // パラメータ１つ目
                SqlParameter param1 = adapter.SelectCommand.CreateParameter();
                param1.ParameterName = "@tsCustomerId";
                param1.SqlDbType = SqlDbType.VarChar;
                param1.Direction = ParameterDirection.Input;
                param1.Value = tsCustomerId;
                adapter.SelectCommand.Parameters.Add(param1);

                // パラメータ2つ目
                SqlParameter param2 = adapter.SelectCommand.CreateParameter();
                param2.ParameterName = "@nameNo1";
                param2.SqlDbType = SqlDbType.VarChar;
                param2.Direction = ParameterDirection.Input;
                param2.Value = nameNo1;
                adapter.SelectCommand.Parameters.Add(param2);

                // パラメータ3つ目
                SqlParameter param3 = adapter.SelectCommand.CreateParameter();
                param3.ParameterName = "@nameNo2";
                param3.SqlDbType = SqlDbType.VarChar;
                param3.Direction = ParameterDirection.Input;
                param3.Value = nameNo2;
                adapter.SelectCommand.Parameters.Add(param3);

                // パラメータ4つ目
                SqlParameter param4 = adapter.SelectCommand.CreateParameter();
                param4.ParameterName = "@nameNo3";
                param4.SqlDbType = SqlDbType.VarChar;
                param4.Direction = ParameterDirection.Input;
                param4.Value = nameNo3;
                adapter.SelectCommand.Parameters.Add(param4);

                // パラメータ5つ目
                SqlParameter param5 = adapter.SelectCommand.CreateParameter();
                param5.ParameterName = "@nameNo4";
                param5.SqlDbType = SqlDbType.VarChar;
                param5.Direction = ParameterDirection.Input;
                param5.Value = nameNo4;
                adapter.SelectCommand.Parameters.Add(param5);

                // パラメータ6つ目
                SqlParameter param6 = adapter.SelectCommand.CreateParameter();
                param6.ParameterName = "@companyName";
                param6.SqlDbType = SqlDbType.VarChar;
                param6.Direction = ParameterDirection.Input;
                param6.Value = companyName;
                adapter.SelectCommand.Parameters.Add(param6);

                // パラメータ7つ目
                SqlParameter param7 = adapter.SelectCommand.CreateParameter();
                param7.ParameterName = "@telNumber";
                param7.SqlDbType = SqlDbType.VarChar;
                param7.Direction = ParameterDirection.Input;
                param7.Value = telNumber;
                adapter.SelectCommand.Parameters.Add(param7);

                // パラメータ8つ目
                //SqlParameter param8 = adapter.SelectCommand.CreateParameter();
                //param8.ParameterName = "@mailMagazine";
                //param8.SqlDbType = SqlDbType.VarChar;
                //param8.Direction = ParameterDirection.Input;
                //param8.Value = mailMagazine;
                //adapter.SelectCommand.Parameters.Add(param8);

                // パラメータ9つ目
                SqlParameter param9 = adapter.SelectCommand.CreateParameter();
                param9.ParameterName = "@customerId";
                param9.SqlDbType = SqlDbType.VarChar;
                param9.Direction = ParameterDirection.Input;
                param9.Value = customerId;
                adapter.SelectCommand.Parameters.Add(param9);

                // パラメータ10つ目
                SqlParameter param10 = adapter.SelectCommand.CreateParameter();
                param10.ParameterName = "@UpdateDate";
                param10.SqlDbType = SqlDbType.DateTime;
                param10.Direction = ParameterDirection.Input;
                param10.Value = updateDate;
                adapter.SelectCommand.Parameters.Add(param10);

                //var dataTable = new System.Data.DataTable();

                try
                {
                    connection.Open();
                    int cnt = adapter.SelectCommand.ExecuteNonQuery();

                    rslt = cnt;

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
                finally
                {
                    connection.Close();
                }

                return rslt;

            }
        }
    }
}
