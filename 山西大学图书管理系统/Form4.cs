using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 山西大学图书管理系统
{
    public partial class Form4 : Form
    {
        int a = 0;
        string str = String.Empty;
        public Form4(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
            label8.Text = label9.Text = label10.Text = label11.Text = label12.Text = label13.Text = "";
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 NextForm = new Form2(this.str);//Form2要跳转的窗体名
            NextForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "select * from system_readers where readerid = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string readername = sdr["readername"].ToString();
                label9.Text = readername;
                readername = sdr["readersex"].ToString();
                label10.Text = readername;
                readername = sdr["readertype"].ToString();
                label11.Text = readername;
                readername = sdr["regdate"].ToString();
                label12.Text = readername;
                /*this.Hide();
                Form2 NextForm = new Form2();//Form2要跳转的窗体名
                NextForm.Show();*/
            }
            else
            {
                label9.Text = "验证失败";
            }
            conn.Close();
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            selectsql = "select COUNT(*) from borrow_record where readerid = '"+textBox1.Text+"'";
            SqlCommand sql = new SqlCommand(selectsql,conn1);
            sql.CommandType = CommandType.Text;
            int sdr2;
            sdr2 = (int)sql.ExecuteScalar();
            if (sdr2 == 0)
            {
                a = 2;
                label8.Text = "可以删除";
            }
            else
            {
                a = 1;
                label8.Text = "该用户还有"+sdr2+"本书没有归还";
                button1.Text = "无法注销";
            }
            conn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a == 2)
            {
                string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string selectsql = "delete from system_readers where readerid ='" + textBox1.Text + "'";
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                int sdr;
                sdr = cmd.ExecuteNonQuery(); 
                if (sdr == 1)
                {
                    a = 4;
                    label13.Text = "用户已经删除";
                    /*this.Hide();
                    Form2 NextForm = new Form2();//Form2要跳转的窗体名
                    NextForm.Show();*/
                }
                else
                {
                    label9.Text = "验证失败";
                }
                conn.Close();
            }
            else if (a == 1)
            {
                label13.Text = "无法删除";
            }
            else if (a == 0)
            {
                label13.Text = "请先验证";
            }
            else
            {
                label13.Text = "用户已经删除";
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
