using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Market_POS
{
    public partial class Form3 : Form
    {
        private static SqlConnection conn = new SqlConnection();
        public static SqlDataAdapter da;
        public static DataSet ds;
        public static DataTable dt;
        DataTable table = new DataTable();

        public Form3()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            DataManager2.Load();
            dataGridView1.DataSource = DataManager2.Stock;
        }
        public void LoadData()
        {
            string connect = string.Format("Data Source={0};" +
              "Initial Catalog = {1};" +
              "Persist Security Info = True;" +
              "User ID=us;Password=1234",
              "192.168.0.106,1433", "MarketPos");
            conn = new SqlConnection(connect);

            try
            {
                conn.Open(); //db 연결

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

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        

        }

        //뒤로가기
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //검색
        private void button2_Click(object sender, EventArgs e)
        {

        }

        //추가
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            { 
                MessageBox.Show("항목을 정확히 입력해주세요");
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            else
            {
                //합계를 구하기 위해 품목명과 가격을 정의하고 total로 합침
                decimal price = decimal.Parse(textBox4.Text);
                decimal count = decimal.Parse(textBox5.Text);
               

                //text박스내의 정보를 표에 삽입
                table.Rows.Add(textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                dataGridView1.DataSource = table;

                //text박스의 정보 초기화
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

            
            }
        }


        //수정
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //삭제
        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
