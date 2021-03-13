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
    public partial class stumana : Form
    {
        public stumana()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            watermarkTextBox1.Text = "";
            watermarkTextBox2.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        SqlConnection conn = new SqlConnection(updatepswd.connectionString);
        private void button2_Click(object sender, EventArgs e)
        {
            string sql;
            conn.Open();
            if (watermarkTextBox1.Text == "" || comboBox1.Text == "" || watermarkTextBox2.Text=="")
            {
                MessageBox.Show("请将信息填写完整！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                MessageBox.Show("请将信息填写完整！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                string gender = radioButton1.Checked ? "女" : "男";
                int mima = 123456;
                sql = "insert into student(stuname,stupasswd,stugrade ,stubanji,stusex)values('" + watermarkTextBox1.Text.Trim() + "','" + mima + "','" + comboBox1.Text.Trim() + "','" + watermarkTextBox2.Text.Trim() + "','" + gender + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("添加用户成功！");
            }
            sql = "insert into SysLog values ( '" + FrmLogin.getid() + "' , '" + DateTime.Now + "' , '" + "insert Student" + "')";                                            //编写SQL命令
            SqlCommand sqlCommand = new SqlCommand(sql, conn);//记录日志
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int flag = 0;
            try
            {
                conn.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是学生学号
                string delete_by_id = "delete from student where stuxuehao="+"'"+ select_id + "'";//sql删除语句,根据stuxuehao删除
                SqlCommand cmd = new SqlCommand(delete_by_id, conn);
                cmd.ExecuteNonQuery();  //执行命令

                String sql = "insert into SysLog values ( '" + FrmLogin.getid() + "' , '" + DateTime.Now + "' , '" + "Delete student" + "')";                                            //编写SQL命令
                SqlCommand sqlCommand = new SqlCommand(sql, conn);//记录日志
                sqlCommand.ExecuteNonQuery();
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
            this.studentTableAdapter.Fill(this.exampleDBDataSet4.student);//使其显示更新后的表
            if (flag == 0)
            {
                MessageBox.Show("成功删除！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void stumana_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“exampleDBDataSet4.student”中。您可以根据需要移动或删除它。
            this.studentTableAdapter.Fill(this.exampleDBDataSet4.student);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            watermarkTextBox3.Text = "";
            watermarkTextBox4.Text = "";
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false; 
            checkBox2.Checked = false;
            checkBox3.Checked = false; 
            checkBox4.Checked = false;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string strsex = radioButton3.Checked ? "女" : "男";
            string strname = watermarkTextBox4.Text.Trim();
            string strbanji = watermarkTextBox3.Text.Trim();

            try
            {
                conn.Open();
                String select_by_chose = "select * from student where ";
                int flag1 = 0;       //表示前面是否已经加了筛选条件,1表示前面有其他条件，则后面的条件需要加AND       
                if (checkBox3.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "stusex='" + strsex + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND stusex='" + strsex + "'";
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
                    String strsort = comboBox2.SelectedItem.ToString();  //取出组合框中的选中项
                    if (flag1 == 0)
                    {
                        select_by_chose += "stugrade='" + strsort + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND stugrade='" + strsort + "'";
                    }
                }
                if (checkBox2.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "stubanji='" + strbanji + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND stubanji='" + strbanji + "'";
                    }
                }
                SqlCommand sqlCommand = new SqlCommand(select_by_chose, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
            }
            catch
            {
                MessageBox.Show("查询语句有误，请认真检查SQL语句!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { conn.Close();}
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String select_by_id = "select * from student";
                SqlCommand sqlCommand = new SqlCommand(select_by_id, conn);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = sqlDataReader;
                dataGridView1.DataSource = bindingSource;
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
    }
}
