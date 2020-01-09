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

namespace App__Beta_
{
    public delegate void delPassData(TextBox text);
    public partial class Sign_in : Form
    {
   
        public Sign_in()
        {
            InitializeComponent();
        }
        // Tạo một phương thức khởi tạo mới

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-V267KUV\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                conn.Open();
                string tk = textTenUser.Text;
                string mk = textMatKhau.Text;
                if (tk == "") MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk == "") MessageBox.Show("Chưa nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    string sql = "select *from NGUOIDUNG where TAIKHOAN='" + tk + "' and MATKHAU='" + mk + "'";
                    SqlCommand cmd = new SqlCommand(sql, conn); 
                    SqlDataReader dta = cmd.ExecuteReader(); // Đọc từ TextBox và đối chiếu với CSDL
                    if (dta.Read() == true)
                    {
                        // Mở dữ liệu ra 
                        this.Close();
                        textTenUser.Enabled = false;
                        textMatKhau.Enabled = false;
                        Profile frmP = new Profile();
                        delPassData del = new delPassData(frmP.funData);
                        del(this.textTenUser);
                        delPassData del2 = new delPassData(frmP.funData2);
                        del2(this.textMatKhau);
                        frmP.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Đăng ký
            SignUp frmSignUp = new SignUp();
            frmSignUp.ShowDialog();
        }

        private void textTenUser_TextChanged(object sender, EventArgs e)
        {
            textMatKhau.Enabled = true;
        }
        public string _textTenUser { get { return textTenUser.Text; } }

        private void textMatKhau_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide(); // Đổi mật khẩu
            Change_password frmFP = new Change_password();
            frmFP.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn muốn thoát game?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void textTenUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' '; 
        }

        private void textMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }
    }
}
