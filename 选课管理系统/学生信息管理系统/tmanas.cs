using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 登录案例
{
    public partial class tmanas : Form
    {
        public tmanas()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            comboBox1.Text = "";
            textBox1.Text = "";
            watermarkTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }
        SqlConnection conn = new SqlConnection(updatepswd.connectionString);
        private void button1_Click(object sender, EventArgs e)
        {
            string strsex = radioButton1.Checked ? "女" : "男";
            string strname = watermarkTextBox1.Text.Trim();
            string strbj = textBox1.Text.Trim();

            try
            {
                conn.Open();
                String select_by_chose = "select stuxuehao as 学号,claid as 课程号,stuname as 姓名,stugrade as 年级, stubanji as 班级,stusex as 性别,claname as 课程,grades as 成绩,term as 学期 from ownstu2 where ";
                int flag1 = 0;       //表示前面是否已经加了筛选条件,1表示前面有其他条件，则后面的条件需要加AND       
                if (checkBox2.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "stusex='" + strsex + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += "AND stusex='" + strsex + "'";
                    }
                }
                if (checkBox4.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "(stuname='" + strname + "' OR stuname LIKE '" + strname + "%')";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += "AND (stuname='" + strname + "' OR stuname LIKE '" + strname + "%')";
                    }
                }
                if (checkBox1.Checked == true)
                {
                    String strsort = comboBox1.SelectedItem.ToString();  //取出组合框中的选中项
                    if (flag1 == 0)
                    {
                        select_by_chose += "stugrade='" + strsort +"'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND stugrade='" + strsort + "'";
                    }
                }
                if (checkBox3.Checked == true) {
                    if (flag1 == 0)
                    {
                        select_by_chose += "stubanji=" +strbj + "";
                        flag1 = 1;
                    }
                    else {
                        select_by_chose += "and stubanji="+strbj+ "";
                    }
                }

               
                SqlCommand sqlCommand = new SqlCommand(select_by_chose, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else {
                    MessageBox.Show("没有学生!", "空", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String select = "select stuxuehao as 学号,claid as 课程号,stuname as 姓名,stugrade as 年级, stubanji as 班级,stusex as 性别,claname as 课程,grades as 成绩,term as 学期 from ownstu2";
                SqlCommand sqlCommand = new SqlCommand(select,conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch {
            }
            finally
            {
                conn.Close();
            }
        }

        private void tmanas_Load(object sender, EventArgs e)
        {
            try {
                conn.Open();
                string jiancha = "IF (EXISTS(SELECT TABLE_NAME FROM INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME=N'mycourse4')) DROP VIEW mycourse4";
                SqlCommand cmd = new SqlCommand(jiancha, conn);
                cmd.ExecuteNonQuery();  //执行命令

                string cj = "CREATE VIEW ownstu2 AS SELECT student.stuxuehao,student.stuname,student.stugrade,student.stubanji,student.stusex,class.claname,class.teacherid,sc.grades,class.term,class.claid FROM class,sc,student where class.claid=sc.claid and sc.stuxuehao=student.stuxuehao and teacherid='"+FrmLogin.gettid()+"'";
                SqlCommand cmd2 = new SqlCommand(cj, conn);
                cmd.ExecuteNonQuery();  //执行命令
            }
            catch { }
            finally { conn.Close(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int flag = 0;
            try
            {
                conn.Open();
                string fenshu = watermarkTextBox2.Text.Trim();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是学号
                
                string classid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//当前行第二列的值
                string update_by_id = "update sc set grades='" + fenshu + "'where stuxuehao='" + select_id + "'and claid='"+classid+"'";//sql更新语句
                SqlCommand cmd = new SqlCommand(update_by_id, conn);
                cmd.ExecuteNonQuery();  //执行命令

                String select_by_chose = "select stuxuehao as 学号,claid as 课程号,stuname as 姓名,stugrade as 年级, stubanji as 班级,stusex as 性别,claname as 课程,grades as 成绩,term as 学期 from ownstu2 where teacherid='" + FrmLogin.gettid() + "'";
                SqlCommand sqlCommand = new SqlCommand(select_by_chose, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
               
            }
            catch
            {
                flag = 1;
                MessageBox.Show("请正确选择行!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
            
            if (flag == 0)
            {
                MessageBox.Show("录入成绩成功！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                conn.Open();
                string select = "select stuxuehao as 学号,claid as 课程号,stuname as 姓名,stugrade as 年级, stubanji as 班级,stusex as 性别,claname as 课程,grades as 成绩,term as 学期 from ownstu2 where ISNULL(grades,'')=''";
                //SqlCommand cmd = new SqlCommand(select, conn);
                //cmd.ExecuteNonQuery();  //执行命令
                SqlCommand sqlCommand = new SqlCommand(select, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;
                }
                else
                {
                    MessageBox.Show("所有学生成绩登陆完毕!", "空", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
            }
            catch { }
            finally {
                conn.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String select = "select stuxuehao as 学号,claid as 课程号,stuname as 姓名,stugrade as 年级, stubanji as 班级,stusex as 性别,claname as 课程,grades as 成绩,term as 学期 from ownstu2";
                SqlCommand sqlCommand = new SqlCommand(select, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
