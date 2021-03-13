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

namespace 登录案例
{
    public partial class select : Form
    {
        public select()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void select_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“exampleDBDataSet6.allcourse”中。您可以根据需要移动或删除它。
            this.allcourseTableAdapter.Fill(this.exampleDBDataSet6.allcourse);
  
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string sql;
                string flags = "1";
                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                conn.Open();

                string select_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//选择的当前行第一列的值，也就是课程号
                sql = "select sctime from sctime where claid =" + select_id;
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string term = comboBox1.Text.Trim();
                    DataRow dr = ds.Tables[0].Rows[i];
                    string time = dr[0].ToString();//第一列
                    sql = "select * from sc,sctime,class where class.claid = sc.claid and class.claid = sctime.claid and sctime = '" + time + "' and sc.stuxuehao='" + FrmLogin.getStudent() + "'and class.term='" + term + "'";
                    SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                    DataSet ds1 = new DataSet();
                    adp1.Fill(ds1);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {

                        flags = "2";
                        MessageBox.Show("课程上课时间冲突！");
                        break;
                    }
                    if (flags == "1")
                    {

                        sql = "insert into sc(claid,stuxuehao,term) values(" + select_id + "," + FrmLogin.getStudent() + ",'" + term + "')";
                        cmd.CommandText = sql;
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("选课成功！");

                        }

                    }

                    sql = "select class.claname  from sc,class where sc.claid = class.claid and stuxuehao='" + FrmLogin.getStudent() + "'";
                    SqlDataAdapter adp2 = new SqlDataAdapter(sql, conn);
                    DataSet ds2 = new DataSet();
                    adp2.Fill(ds2);

                    conn.Close();
                }
            }
            catch {
                MessageBox.Show("请正确点击！");
            }
        
        }

      

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
               
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

    

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                String strsort = comboBox1.SelectedItem.ToString();
                conn.Open();
                // string select_by_term = "select * from class where term="+strsort;


                string sql = "select * from allcourse where term='" + strsort + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();

            }
            catch
            {
                MessageBox.Show("查询语句有误!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}