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
    public partial class manaclass : Form
    {
        public manaclass()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void manaclass_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“exampleDBDataSet2.Teacher”中。您可以根据需要移动或删除它。
            this.teacherTableAdapter.Fill(this.exampleDBDataSet2.Teacher);
            // TODO: 这行代码将数据加载到表“exampleDBDataSet9.teachclass1”中。您可以根据需要移动或删除它。
            this.teachclass1TableAdapter.Fill(this.exampleDBDataSet9.teachclass1);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            comboBox1.Text = "";
            watermarkTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(updatepswd.connectionString);
            try
            {
                conn.Open();
                String select_by_id = "select * from teachclass1";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(updatepswd.connectionString);
            string strsex = radioButton1.Checked ? "女" : "男";
            string strname = watermarkTextBox1.Text.Trim();

            try
            {
                conn.Open();
                String select_by_chose = "select * from teachclass1 where ";
                int flag1 = 0;       //表示前面是否已经加了筛选条件,1表示前面有其他条件，则后面的条件需要加AND       
                if (checkBox2.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "tsex='" + strsex + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND tsex='" + strsex + "'";
                    }
                }
                if (checkBox3.Checked == true)
                {
                    if (flag1 == 0)
                    {
                        select_by_chose += "(tname='" + strname + "' OR tname LIKE '" + strname + "%')";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += "AND (tname='" + strname + "' OR tname LIKE '" + strname + "%')";
                    }
                }
                if (checkBox1.Checked == true)
                {
                    String strsort = comboBox1.SelectedItem.ToString();  //取出组合框中的选中项
                    if (flag1 == 0)
                    {
                        select_by_chose += "teachsort='" + strsort + "'";
                        flag1 = 1;
                    }
                    else
                    {
                        select_by_chose += " AND teachsort='" + strsort + "'";
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
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(updatepswd.connectionString);
            int flag = 0;
            try
            {
                conn.Open();
                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是课程号
                string selectif = "select * from sctime where claid='"+select_id+"'";

                SqlCommand sqlCommand = new SqlCommand(selectif, conn);
                SqlDataReader sqlDataReader2 = sqlCommand.ExecuteReader();
                if (sqlDataReader2.HasRows)
                {
                    string real = "delete from sctime where claid=" + "'" + select_id + "'";//sql删除语句
                    SqlCommand cmd1 = new SqlCommand(real, conn);
                    cmd1.ExecuteNonQuery();  //执行命令
                    /*BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = sqlDataReader;
                    dataGridView1.DataSource = bindingSource;*/
                }
                else
                {
                    string del = "delete from class where claid='"+select_id+"'";
                    SqlCommand sckb = new SqlCommand(del,conn);
                    sckb.ExecuteNonQuery();
                   
                }


               

                String sql = "insert into SysLog values ( '" + FrmLogin.getid() + "' , '" + DateTime.Now + "' , '" + "Delete class" + "')";                                            //编写SQL命令
                SqlCommand sqlComm = new SqlCommand(sql, conn);//记录日志
                sqlComm.ExecuteNonQuery();
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
            this.teachclass1TableAdapter.Fill(this.exampleDBDataSet9.teachclass1);//使其显示更新后的表
            if (flag == 0)
            {
                MessageBox.Show("成功删除！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            watermarkTextBox2.Text = "";
            comboBox2.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (watermarkTextBox2.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "")
            {
                MessageBox.Show("请将信息填写完整！", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {

                string claname = watermarkTextBox2.Text.Trim();
                string loca = comboBox2.Text.Trim();
                string term = comboBox3.Text.Trim();
                string time = comboBox4.Text.Trim();
                string tercher_id = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是教师编码
                string teachername = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();//选择的当前行第二列的值，也就是教师编码
                string teachsort = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();//选择的当前行第三列的值，也就是教师编码
                
                try
                {
                    SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                    
                    string sql = "";
                    conn.Open();
                    sql = "select * from sctime where sctime = '" + time + "'and location = '" + loca + "'and term='" + term + "'";


                    SqlCommand sqlCommand = new SqlCommand(sql, conn); sqlCommand.ExecuteNonQuery();  //执行命令
                    SqlDataReader sqlDataReader3 = sqlCommand.ExecuteReader();
                    if (sqlDataReader3.HasRows)
                    {
                        MessageBox.Show("该时间该地点已有课程！");
                        
                    }
                    else
                    {
                        string kaike = "insert into class (claname,term,teacherid,teachername) values ('" + claname + "','" + term + "','" + tercher_id + "','" + teachername + "')";
                        SqlCommand cmd2 = new SqlCommand(kaike, conn);
                        cmd2.ExecuteNonQuery();  


                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = conn;
                        sql = "select claid from class where claname = '" + claname + "' and term = '" + term + "' and teacherid = '" + tercher_id + "'";
                        cmd.CommandText = sql;
                        String id1 = cmd.ExecuteScalar().ToString();
                        int id = 0;
                        int.TryParse(id1, out id);


                        string kaike2 = "insert into sctime values(" + id + ","+tercher_id+",'" + time + "','" + loca + "','" + term + "')";
                       
                        SqlCommand cmd1 = new SqlCommand(kaike2, conn);
                        cmd1.ExecuteNonQuery();  //执行命令
                        
                        MessageBox.Show("开设课程成功！");
                        
                    }
                    this.teachclass1TableAdapter.Fill(this.exampleDBDataSet9.teachclass1);//使其显示更新后的表

                    conn.Close();

                    // string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是教师编码
                    
                }
                catch
                {
                    
                    MessageBox.Show("请正确选择行!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    
                }
            }

        }
    }
}
