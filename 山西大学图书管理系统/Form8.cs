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
    public partial class Form8 : Form
    {
        string str = String.Empty;
        public Form8(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string a = "select system_readers.readerid 读者编号 ,system_readers.readername 读者姓名, system_books.bookid 图书编号, system_books.bookname 图是名字 ,return_record.returndate 归还日期 from system_books,system_readers,return_record where return_record.bookid=system_books.bookid and return_record.readerid = system_readers.readerid";
            //textBox1.Text = a;
            SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 NextForm = new Form2(this.str);//Form2要跳转的窗体名
            NextForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name;
            name = comboBox1.Text;
            if (name == "用户编号")
            {
                name = "system_readers.readerid";
            }
            else 
            {
                name = "system_readers.readername";
            }
            
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string a = "select system_readers.readerid 读者编号 ,system_readers.readername 读者姓名, system_books.bookid 图书编号, system_books.bookname 图是名字 ,return_record.returndate 归还日期 from system_books,system_readers,return_record where return_record.bookid=system_books.bookid and return_record.readerid = system_readers.readerid and "+name+" like '%"+textBox1.Text+"%';";
            //textBox1.Text = a;
            SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
