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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P0ROQPB\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                string tk2 = textUserNew.Text;
                string tk2s = textPlayerName.Text;
                string mk2 = textMatKhauNew.Text;
                string mk2s = textMatKhauAgain.Text;

                if (tk2 == "") MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tk2s == "") MessageBox.Show("Chưa nhập tên Profile", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk2 == "") MessageBox.Show("Chưa nhập mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk2s == "") MessageBox.Show("Vui lòng nhập lại mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (mk2 == mk2s)
                {
                    // Kết nối với SQL
                    conn.Open();
                    string sql2 = "insert into NGUOIDUNG(TAIKHOAN, MATKHAU, TEN) values(@TAIKHOAN, @MATKHAU, @TEN)";
                    SqlCommand sqlcmd = new SqlCommand(sql2, conn);
                    sqlcmd.Parameters.AddWithValue("@TAIKHOAN", textUserNew.Text);
                    sqlcmd.Parameters.AddWithValue("@MATKHAU", textMatKhauNew.Text);
                    sqlcmd.Parameters.AddWithValue("@TEN", textPlayerName.Text);
                    // Thực thi
                    sqlcmd.ExecuteNonQuery();  
                    // Khác:
                    //SqlCommand sqlcmd = new SqlCommand("insert into NGUOIDUNG(TAIKHOAN, MATKHAU) values('" + textUserNew.Text + "' and '" + textMatKhauNew + "')", conn);
                    //sqlcmd.ExecuteNonQuery();
                    //conn.Close();
                    // Thông báo khi nhập đúng 
                    MessageBox.Show("Tạo mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else if (mk2 != mk2s)
                {
                    MessageBox.Show("Mật khẩu nhập lại không đúng. Vui lòng thử lại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn chắc muốn dừng việc đăng ký?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                textMatKhauNew.UseSystemPasswordChar = false;
                textMatKhauAgain.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                textMatKhauNew.UseSystemPasswordChar = true;
                textMatKhauAgain.UseSystemPasswordChar = true;
            }
        }

        private void textPlayerName_TextChanged(object sender, EventArgs e)
        {
            textUserNew.Enabled = true;
        }

        private void textUserNew_TextChanged(object sender, EventArgs e)
        {
            label6.Visible = true;
            textMatKhauNew.Enabled = true;
        }

        private void textMatKhauNew_TextChanged(object sender, EventArgs e)
        {
            textMatKhauAgain.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void textMatKhauAgain_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void textUserNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' '; // Chặn việc ấn phím spacebar
        }

        private void textMatKhauNew_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhauAgain_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }
    }
}
