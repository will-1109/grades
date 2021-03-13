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
    public partial class showcourse : Form
    {
        public showcourse()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            while (dataGridView1.Rows.Count != 0)
            {
                dataGridView1.DataSource = null;
            }
            if (comboBox1.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("请输入查询信息！");
            }
            else if (comboBox1.Text != "" && textBox1.Text == "")
            {
                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                conn.Open();
                string sql = "select claid as 课程号,claname as 课程名,sctime as 上课时间,term as 学期,location as 上课地点,teachername as 任课老师 from mycourse5 where term='" + comboBox1.Text.Trim() + "'and stuxuehao='" + FrmLogin.getStudent() + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            else if (textBox1.Text != "" && comboBox1.Text == "")
            {

                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                conn.Open();
                //textBox1.Text.Trim()  textBox2.Text.Trim()
                string sql = "select claid as 课程号,claname as 课程名,sctime as 上课时间,term as 学期,location as 上课地点,teachername as 任课老师 from mycourse5 where claname='" + textBox1.Text.Trim() + "'and stuxuehao='" + FrmLogin.getStudent() + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();
            }
            else if (textBox1.Text != "" && comboBox1.Text != "")
            {

                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                conn.Open();
                //textBox1.Text.Trim()  textBox2.Text.Trim()
                string sql = "select claid as 课程号,claname as 课程名,sctime as 上课时间,term as 学期,location as 上课地点,teachername as 任课老师 from mycourse5 where claname='" + textBox1.Text.Trim() + "'and stuxuehao='" + FrmLogin.getStudent() + "'and term='" + comboBox1.Text.Trim() + "'";
                SqlDataAdapter adp1 = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp1.Fill(ds);
                //载入基本信息
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
                conn.Close();

            }
        }

        private void showcourse_Load(object sender, EventArgs e)
        {
            
        }
    }
}