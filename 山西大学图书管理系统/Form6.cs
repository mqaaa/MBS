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
    public partial class Form6 : Form
    {
         string str = String.Empty;//接收传过来的值
         public Form6(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 NextForm = new Form2(this.str);//Form2要跳转的窗体名
            NextForm.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string a = "select system_readers.readerid 读者借书证编号,readername 读者姓名,system_books.bookid 书籍编号,bookname 书名,borrowdate 借书时间,datediff(day,convert(smalldatetime,borrowdate),getdate())-30 超过天数 from borrow_record ,system_readers,system_books where system_readers.readerid=borrow_record.readerid and system_books.bookid=borrow_record.bookid and datediff(day,convert(smalldatetime,borrowdate),getdate())>=30";
            SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];     
        }
    }
}
