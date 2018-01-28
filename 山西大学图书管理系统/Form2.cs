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
    public partial class Form2 : Form
    {
        int f2 = 0;
        string str = String.Empty;//接收传过来的值
        public Form2(string textValue)
        {
            InitializeComponent();
            this.str = textValue;
            label1.Text = "准备就绪";
            label2.Text = "准备就绪";
            label4.Text = this.str;
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "select * from system_readers where readerid ='" + label4.Text + "'and readertype = '管理'";
            //textBox1.Text = selectsql;   
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                f2 = 1;
            }
            conn.Close();
             str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn1 = new SqlConnection(str);
            conn1.Open();
            string a = "select bookid 图书编号, bookname 图书名字,bookauthor 作者,bookpub 图书出版社 from system_books where isborrowed = '0'";
            //textBox1.Text = a;
            SqlDataAdapter ada = new SqlDataAdapter(a, conn1);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            conn1.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 NextForm = new Form7(label4.Text);//Form2要跳转的窗体名
            NextForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (f2 == 1)
            {
                this.Hide();
                Form8 NextForm = new Form8(label4.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else
            {
                string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string a = "select  system_books.bookid 图书编号, system_books.bookname 图是名字 ,return_record.returndate 归还日期 from system_books,return_record where return_record.bookid=system_books.bookid  and return_record.readerid = '"+label4.Text+"'";
                //textBox1.Text = a;
                SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
                DataSet ds = new DataSet();                         //创建数据集对象
                ada.Fill(ds);                                      //填充数据集
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close(); 
            } 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (f2==1)
            {
                this.Hide();
                Form3 NextForm = new Form3(label4.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else
            {
                //button3.Text = "权限不足";
                MessageBox.Show("权限不足");
            } 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "select bookname from system_books where bookid = '" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string bookname = sdr["bookname"].ToString();
                label1.Text = bookname;
                /*this.Hide();
                Form2 NextForm = new Form2();//Form2要跳转的窗体名
                NextForm.Show();*/
            }
            else
            {
                label1.Text = "验证失败";
            }
            conn.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            try
            {
                conn.Open();
                string selectsql = "insert into borrow_record (bookid,readerid,borrowdate) values(" + textBox1.Text + "," + label4.Text + ",GETDATE())";
                //textBox1.Text = selectsql;
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                int sdr;
                sdr = cmd.ExecuteNonQuery();


                label1.Text = "借书成功";
            }
            catch
            {
                label1.Text = "图书已借出";
                MessageBox.Show("图书已借出");
            }
            
            conn.Close();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            try
            {
                conn.Open();
                string selectsql = "delete from borrow_record where bookid='" + textBox2.Text + "'";
                //textBox2.Text = selectsql;
                SqlCommand cmd = new SqlCommand(selectsql, conn);
                cmd.CommandType = CommandType.Text;
                int sdr;
                sdr = cmd.ExecuteNonQuery();

                label2.Text = "还书成功";
                /*string name=sdr["cname"].ToString();   
                label1.Text = name;
                /*this.Hide();
                Form2 NextForm = new Form2();//Form2要跳转的窗体名
                NextForm.Show();*/
            }
            catch
            {

                label2.Text = "还书失败";
                MessageBox.Show("还书失败");
            }
            conn.Close();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string selectsql = "select bookname from system_books where bookid = '" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                string bookname = sdr["bookname"].ToString();
                label2.Text = bookname;
                /*this.Hide();
                Form2 NextForm = new Form2();//Form2要跳转的窗体名
                NextForm.Show();*/
            }
            else
            {
                label2.Text = "验证失败";
            }
            conn.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (f2==1)
            {
                this.Hide();
                Form4 NextForm = new Form4(label4.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else
            {
                //button10.Text = "权限不足";
                MessageBox.Show("权限不足");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (f2 == 1)
            {
                this.Hide();
                Form5 NextForm = new Form5(label4.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else {
                //button9.Text = "权限不足";
                MessageBox.Show("权限不足");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (f2 == 1)
            {
                this.Hide();
                Form6 NextForm = new Form6(label4.Text);//Form2要跳转的窗体名
                NextForm.Show();
            }
            else 
            {
                string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string a = "select system_books.bookid 书籍编号,bookname 书名,borrowdate 借书时间,datediff(day,convert(smalldatetime,borrowdate),getdate()) 借阅天数 from borrow_record,system_books  where borrow_record.readerid='"+label4.Text+"' and borrow_record.bookid=system_books.bookid";
                //textBox1.Text = a;
                SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
                DataSet ds = new DataSet();                         //创建数据集对象
                ada.Fill(ds);                                      //填充数据集
                dataGridView1.DataSource = ds.Tables[0];
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "server=DESKTOP-IOGDVON\\SQLEXPRESS;database=student;integrated security=SSPI";
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string a = "select bookstyleno 编号,bookstyle 图书类别 from book_style ";
            //textBox1.Text = a;
            SqlDataAdapter ada = new SqlDataAdapter(a, conn);  //创建数据适配器对象
            DataSet ds = new DataSet();                         //创建数据集对象
            ada.Fill(ds);                                      //填充数据集
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }
    }
}
