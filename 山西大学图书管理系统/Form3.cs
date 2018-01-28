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
    public partial class Form3 : Form
    {
        string str = String.Empty;
        public Form3(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
            label6.Text = "准备就绪";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "insert into system_readers (readerid,readername,readersex,readertype,pad,regdate) values('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "',GETDATE())";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            int sdr;
            sdr = cmd.ExecuteNonQuery();
            if (sdr == 1)
            {
                label6.Text = "添加成功";
            }
            else
            {
                label6.Text = "添加失败";
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 NextForm = new Form2(this.str);//Form2要跳转的窗体名
            NextForm.Show();
        }
    }
}
