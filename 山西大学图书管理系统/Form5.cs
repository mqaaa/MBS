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
    public partial class Form5 : Form
    {
        int f5 = 0;
        string str = String.Empty;
        public Form5(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
            label8.Text = "准备就绪";
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (f5 == 0)
            {
                string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
                /*SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string sele = "select * from book_style where bookstyle = '" + comboBox1.Text + "'";
                textBox5.Text = sele;
                SqlCommand cmd1 = new SqlCommand(sele, conn);
                cmd1.CommandType = CommandType.Text;
                SqlDataReader sdr1;
                
                sdr1 = cmd1.ExecuteReader();
                sdr1.Read();
                comboBox1.Text = sele;
                conn.Close();*/
                SqlConnection conn1 = new SqlConnection(str);
                conn1.Open();
                string selectsql = "insert into system_books (bookid,bookname,bookstyleno,bookauthor,bookpub,bookpubdate,bookindate,isborrowed) values ('" + textBox1.Text + "','" + textBox2.Text + "',(select bookstyleno from book_style where bookstyle = '"+comboBox1.Text+"'),'" + textBox3.Text + "','" + textBox4.Text + "',GETDATE(),GETDATE(),'0')";
                //string selectsql = "insert into system_books (bookid,bookname,bookstyleno,bookauthor,bookpub,bookpubdate,bookindate,isborrowed) values ('20170621',                  'c++',               (select bookstyleno from book_style where bookstyle = '"+comboBox1.Text+"'),'1','1',GETDATE(),GETDATE(),'0')"
                //textBox6.Text = selectsql;
                SqlCommand cmd = new SqlCommand(selectsql, conn1);
                cmd.CommandType = CommandType.Text;
                int sdr;
                sdr = cmd.ExecuteNonQuery();
                if (sdr == 1)
                {

                    f5 = 1;
                    label8.Text = "添加成功";
                }
                else
                {
                    label8.Text = "添加失败";
                }

                conn1.Close();
            }
            else
            {
                label8.Text = "图书已添加";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 NextForm = new Form2(this.str);//Form2要跳转的窗体名
            NextForm.Show();
        }
    }
}
