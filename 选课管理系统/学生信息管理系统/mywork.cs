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
    public partial class mywork : Form
    {
        public mywork()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(updatepswd.connectionString);
                String strterm = comboBox1.SelectedItem.ToString();
                conn.Open();
                


                string sql = "select claname as 课程名,sctime as 上课时间,location as 上课地点,term as 学期 from mywork1 where term='" + strterm + "'and teacherid='" + FrmLogin.gettid()+"'";
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
    }
}
