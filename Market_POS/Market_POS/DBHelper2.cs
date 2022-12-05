using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market_POS
{
    public class DBHelper2
    {
        public static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;

        //DB연결
        public static void ConnectDB()
        {//접속해주는 함수
            try
            {
                string connect = string.Format("Data Source={0};" +
                "Initial Catalog = {1};" +
                "Persist Security Info = True;" +
                "User ID=us;Password=1234",
                "192.168.0.106,1433", "MarketPos");
                conn = new SqlConnection(connect);
                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("connect Fail");
            }
        }

        //데이터 선택
        public static void selectQuery()
        {
            try
            {
                ConnectDB(); //db 연결

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn; //어디에 커맨드 보낼지 지정
                cmd.CommandText = "select * from stock_tb;";
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "stock_tb");
                dt = ds.Tables[0];
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "stock");
                System.Windows.Forms.MessageBox.Show(e.StackTrace + "stock");
                //DataManager.printLog("select" + e.StackTrace);
                return;
            }
            finally
            {
                conn.Close(); //db 연결 해제
            }
        }
    }
}
