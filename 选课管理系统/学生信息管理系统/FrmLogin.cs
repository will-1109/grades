using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//引用该命名空间

namespace 登录案例
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        public static string role;
        public static String getRole()//获取当前登陆用户的身份信息
        {
            String role1 = "";
            role1 = role;
            return role1;
        }
        public static string name;
        
        public static String getStudent()//得到学生的登陆账号
        {
            String stuxuehao = "";
            stuxuehao = name;
            return stuxuehao;
        }
        public static string getid()//得到管理员的登陆账号
        {
            string uid = "";
            uid = name;
            return uid;
        }
        public static string gettid()//得到教师的登陆账号
        {
            string tid = "";
            tid = name;
            return tid;
        }
        private bool ExitProg = true; 
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //首先添加引用：程序序集中的"System.Configuration"
            try
            {
                GlobalClass.StrCnn = System.Configuration.ConfigurationManager.ConnectionStrings["strCnn"].ConnectionString.ToString();
                GlobalClass.ConLoginDB.ConnectionString = GlobalClass.StrCnn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            name = TxtUserName.Text.Trim();//获取当前用户登录的账号id
            role = this.comboBox1.SelectedItem.ToString();


            if (TxtUserName.Text == "" || TxtPassword.Text == ""||role=="")
            {
                MessageBox.Show("请将信息填写完整！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUserName.Focus();
                return;
            }
             else
             {
                if (role == "管理员")
                 {
                 try
                 {
                     GlobalClass.ConLoginDB.Open();
                     SqlCommand LoginCmd = new SqlCommand("UserLogin", GlobalClass.ConLoginDB);
                     LoginCmd.CommandType = CommandType.StoredProcedure;
                     LoginCmd.Parameters.Add("@userID", SqlDbType.NChar, 30);
                     LoginCmd.Parameters.Add("@passWord", SqlDbType.NChar, 30);
                     LoginCmd.Parameters.Add("@returnValue", SqlDbType.Int, 0);
                     LoginCmd.Parameters[2].Direction = ParameterDirection.ReturnValue;
                     LoginCmd.Parameters[0].Value = TxtUserName.Text;
                     LoginCmd.Parameters[1].Value = TxtPassword.Text.Trim();
                     LoginCmd.ExecuteNonQuery();
                     Int32 returnvalue = (Int32)LoginCmd.Parameters[2].Value;//返回0时表示表空
                     GlobalClass.ConLoginDB.Close();
                     if (returnvalue == 1)
                     {
                         ExitProg = false;
                         this.Close();
                         FrmMain MyFrmMain = new FrmMain();
                         MyFrmMain.Text = "管理员界面";
                         MyFrmMain.Show();
                     }
                     else
                     {
                         MessageBox.Show("信息填写错误！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         TxtUserName.Focus();
                         TxtUserName.SelectAll();
                     }
                 }
                 catch (SqlException err)
                 {
                     MessageBox.Show(err.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     GlobalClass.ConLoginDB.Close();
                 }
                }
                else if (role == "学生") 
                {
                     
                     try
                 {
                     GlobalClass.ConLoginDB.Open();
                     SqlCommand LoginCmd = new SqlCommand("stuLogin", GlobalClass.ConLoginDB);
                     LoginCmd.CommandType = CommandType.StoredProcedure;
                     LoginCmd.Parameters.Add("@stuID", SqlDbType.NChar, 6);
                     LoginCmd.Parameters.Add("@passWord", SqlDbType.NChar, 6);
                     LoginCmd.Parameters.Add("@returnValue", SqlDbType.Int, 0);
                     LoginCmd.Parameters[2].Direction = ParameterDirection.ReturnValue;
                     LoginCmd.Parameters[0].Value = TxtUserName.Text;
                     LoginCmd.Parameters[1].Value = TxtPassword.Text.Trim();
                     LoginCmd.ExecuteNonQuery();
                     Int32 returnvalue = (Int32)LoginCmd.Parameters[2].Value;//返回0时表示表空
                     GlobalClass.ConLoginDB.Close();
                     if (returnvalue == 1)
                     {
                         ExitProg = false;
                         this.Close();
                         student MyFrmMain = new student();
                         MyFrmMain.Text = "学生界面";
                         MyFrmMain.Show();
                     }
                     else
                     {
                         MessageBox.Show("信息填写错误！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         TxtUserName.Focus();
                         TxtUserName.SelectAll();
                     }
                 }
                 catch (SqlException err)
                 {
                     MessageBox.Show(err.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     GlobalClass.ConLoginDB.Close();
                 }
                
                
                }
                else if (role == "教师")
                {

                    try
                    {
                        GlobalClass.ConLoginDB.Open();
                        SqlCommand LoginCmd = new SqlCommand("teachLogin", GlobalClass.ConLoginDB);
                        LoginCmd.CommandType = CommandType.StoredProcedure;
                        LoginCmd.Parameters.Add("@teachID", SqlDbType.NChar, 6);
                        LoginCmd.Parameters.Add("@passWord", SqlDbType.NChar, 6);
                        LoginCmd.Parameters.Add("@returnValue", SqlDbType.Int, 0);
                        LoginCmd.Parameters[2].Direction = ParameterDirection.ReturnValue;
                        LoginCmd.Parameters[0].Value = TxtUserName.Text;
                        LoginCmd.Parameters[1].Value = TxtPassword.Text.Trim();
                        LoginCmd.ExecuteNonQuery();
                        Int32 returnvalue = (Int32)LoginCmd.Parameters[2].Value;//返回0时表示表空
                        GlobalClass.ConLoginDB.Close();
                        if (returnvalue == 1)
                        {
                            ExitProg = false;
                            this.Close();
                            teacher MyFrmMain = new teacher();
                            MyFrmMain.Text = "教师界面";
                            MyFrmMain.Show();
                        }
                        else
                        {
                            MessageBox.Show("信息填写错误！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TxtUserName.Focus();
                            TxtUserName.SelectAll();
                        }
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show(err.Message, "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GlobalClass.ConLoginDB.Close();
                    }


                }
             }
        }














        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                TxtPassword.Focus();
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ButtonOk.Focus();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ExitProg)
                Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TxtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
