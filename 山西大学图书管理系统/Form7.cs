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
    public partial class Form7 : Form
    {
        string str = String.Empty;
        public Form7(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            if (name == "编号")
            {
                name = "bookid";
            }
            else if(name == "名字")
            {
                name = "bookname";
            }
            else if (name == "作者")
            {
                name = "bookauthor";
            }
            else 
            {
                name = "bookpub";
            }
            string name2 = comboBox2.Text;
            int f7 = 0;
            if(name2 == "已被借走")
            {
                f7 = 1;
            }
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string a = "select bookid 图书编号,bookname 图书名字,bookauthor 作者,bookpub 出版社 from system_books where "+name+" like '%"+textBox1.Text+"%'and isborrowed = '"+f7+"'";
            //textBox1.Text = a;
            SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];
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
