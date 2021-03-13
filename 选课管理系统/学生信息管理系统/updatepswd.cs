using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Data.SqlClient.sqlConnection;
namespace 登录案例
{
    public partial class updatepswd : Form
    {
        public static string connectionString = "uid=sa;pwd=Sa123;initial catalog=ExampleDB;data source=127.0.0.1;Integrated Security=True;MultipleActiveResultSets=true";
        private void updatepswd_Load(object sender, EventArgs e)
        {
            
        }
        public updatepswd()
        {
            InitializeComponent();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string passwd = textBox2.Text;
            string quepasswd = textBox3.Text;
            SqlConnection sqlCnt = new SqlConnection(connectionString);
            sqlCnt.Open();

            if (passwd == "" || quepasswd == "")
            {
                MessageBox.Show("请将信息填写完整!");
            }
            else
            {
                if (quepasswd != passwd)
                {
                    MessageBox.Show("两次输入的密码不一致!");
                }
                else
                {
                    if (FrmLogin.getRole() == "学生")
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCnt;
                        string sql = "update student set stupasswd ='" + passwd + "' where stuxuehao = '" + FrmLogin.getStudent() + "'";
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        MessageBox.Show("修改密码成功！");
                        this.Close();
                    }
                    else if (FrmLogin.getRole() == "教师")
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCnt;
                        string sql = "update Teacher set teachpasswd ='" + passwd + "' where teachbm = '" + FrmLogin.gettid() + "'";
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        MessageBox.Show("修改密码成功！");
                        this.Close();
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = sqlCnt;
                        string sql = "update Users set userpassword ='" + passwd + "' where userid = '" + FrmLogin.getid()+ "'";
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        MessageBox.Show("修改密码成功！");
                        this.Close();
                    }
                }
                sqlCnt.Close();
            }
        }
    }
}



     
    
