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
    public partial class Change_password : Form
    {
        public Change_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P0ROQPB\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                string tk = textTenUser.Text;
                string mk = textMatKhau.Text;
                string mk3s = textMatKhauChange.Text;
                string mk3r = textMatKhauChange_A.Text;
                
                if (tk == "") MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk == "") MessageBox.Show("Chưa nhập mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk3s == "") MessageBox.Show("Chưa nhập mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk3r == "") MessageBox.Show("Chưa nhập lại pass", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk3s != mk3r)
                {
                    MessageBox.Show("Mật khẩu nhập không đúng. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // Đổi mật khẩu
                else
                {
                    // Thực thi lệnh SQL:
                    string sql = "UPDATE NGUOIDUNG SET MATKHAU= @MATKHAU WHERE TAIKHOAN=@TAIKHOAN";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@MATKHAU", textMatKhauChange.Text);
                    command.Parameters.AddWithValue("@TAIKHOAN", textTenUser.Text);
                    // Kết nối:
                    conn.Open();
                    // Excute:
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn có chắc muốn ngừng đổi mật khẩu?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textMatKhau.UseSystemPasswordChar = false;
                textMatKhauChange.UseSystemPasswordChar = false;
                textMatKhauChange_A.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                textMatKhau.UseSystemPasswordChar = true;
                textMatKhauChange.UseSystemPasswordChar = true;
                textMatKhauChange_A.UseSystemPasswordChar = true;
            }
        }

        private void textMatKhauChange_TextChanged(object sender, EventArgs e)
        {
            textMatKhauChange_A.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void textTenUser_TextChanged(object sender, EventArgs e)
        {
            textMatKhau.Enabled = true;
        }

        private void textMatKhau_TextChanged(object sender, EventArgs e)
        {
            textMatKhauChange.Enabled = true;
        }

        private void textMatKhauChange_A_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textTenUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhauChange_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhauChange_A_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }
    }
}
