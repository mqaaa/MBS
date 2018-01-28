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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label5.Text = "准备就绪";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "select * from system_readers where readerid = '" + textBox1.Text + "'and pad = '" + textBox2.Text + "' and readertype = '" + comboBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                this.Hide();
                Form2 NextForm = new Form2(textBox1.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else
            {
                label5.Text = "登录失败";
            }
            
            conn.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
