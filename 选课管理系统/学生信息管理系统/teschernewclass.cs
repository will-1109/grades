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
    public partial class teschernewclass : Form
    {
        public teschernewclass()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            string classes = textBox1.Text;
            string term = comboBox1.SelectedItem.ToString();
            string flags = "1";
            SqlConnection conn = new SqlConnection(updatepswd.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            //将开课信息插入到开课表里

            
            string sql = "";

            string didian = comboBox2.SelectedItem.ToString(); //得到上课的地点
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (checkedListBox1.GetItemChecked(i))
                {
                    string time = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                    sql = "select * from sctime where sctime = '" + time + "'and location = '" + didian + "'and term='"+term+"'";
                    SqlDataAdapter adp = new SqlDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        flags = "2";
                        MessageBox.Show("该时间该教室已经有课！");
                        break;
                    }
                    else
                    {
                        flags = "1";
                        break;
                    }
                }
            }
            if (flags == "1")
            {
                string teachername = string.Empty;
                //conn = new SqlConnection();
           //     conn.Open();
                SqlCommand getValueCom = conn.CreateCommand();
                getValueCom.CommandText = "select tname from teacher where teachbm=" + FrmLogin.gettid();
                SqlDataReader getValueReader = getValueCom.ExecuteReader();
                if (getValueReader.Read())
                {
                    teachername = getValueReader[0].ToString().Trim();

                }
                getValueReader.Close();


                sql = "insert into class (claname,term,teacherid,teachername) values ('" + classes + "','" + term + "','" + FrmLogin.gettid() + "','"+teachername+"')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();



                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (checkedListBox1.GetItemChecked(i))
                    {
                        



                        string time = checkedListBox1.GetItemText(checkedListBox1.Items[i]);
                        //将上课时间得到
                        sql = "select claid from class where claname = '" + classes + "' and term = '" + term + "' and teacherid = '" + FrmLogin.gettid() + "'";
                        cmd.CommandText = sql;
                        String id1 = cmd.ExecuteScalar().ToString();
                        int id = 0;
                        int.TryParse(id1, out id);


                        sql = "insert into sctime values(" + id + ",'"+FrmLogin.gettid()+"','" + time + "','" + didian + "','"+term+"')";
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("开设课程成功！");
                
            }

            conn.Close();
        }
    }
}
