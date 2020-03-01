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
    public partial class Profile : Form
    {
        public void funData(TextBox textTenUser) { label9.Text = textTenUser.Text; } // Áp dụng hàm delegate
        public void funData2(TextBox textMatKhau) { label13.Text = textMatKhau.Text; } // Áp dụng hàm delegate

        public delegate void delPassData(Label text);

        public Profile()
        {
            InitializeComponent();
        }
        //public event   EventHandler DangXuat;

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DLPCKO6\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
        private void ketnoicsdl()
        {
            conn.Open(); // Ket noi csdl
            string sql = "select ID, TEN, DE, TRUNGBINH, KHO from NGUOIDUNG";  // Lấy hết dữ liệu trong bảng NGUOIDUNG
            SqlCommand com = new SqlCommand(sql, conn); // Bắt đầu truy vấn
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); // Chuyển dữ liệu về
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // Đổ dữ liệu vào 
            conn.Close();  // Đóng kết nối
            dataGridView1.DataSource = dt; // Đổ dữ liệu vào datagridview
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult tb2 = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Đăng xuất", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (tb2 == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DLPCKO6\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                string tk = textPlayerName.Text;
                string tks = textPlayerName_N.Text;
                string mk = textMatKhau.Text;

                if (tk == "") MessageBox.Show("Tên người dùng chưa được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (tks == "") MessageBox.Show("Tên mới chưa được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (mk == "") MessageBox.Show("Mật khẩu chưa được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    // Thực thi lệnh SQL:
                    string sql = "UPDATE NGUOIDUNG SET TEN = @TEN WHERE MATKHAU = @MATKHAU";
                    SqlCommand command = new SqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@TEN", textPlayerName_N.Text);
                    command.Parameters.AddWithValue("@MATKHAU", textMatKhau.Text);
                    // Kết nối:
                    conn.Open();
                    // Excute:
                    command.ExecuteNonQuery();
                    MessageBox.Show("Đổi tên người chơi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textMatKhau_S.UseSystemPasswordChar = false;
                textMatKhauChange.UseSystemPasswordChar = false;
                textMatKhauChange_A.UseSystemPasswordChar = false;
            }
            if (checkBox1.Checked == false)
            {
                textMatKhau_S.UseSystemPasswordChar = true;
                textMatKhauChange.UseSystemPasswordChar = true;
                textMatKhauChange_A.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-DLPCKO6\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                string tk = textTenUser.Text;
                string mks = textMatKhau_S.Text;
                string mk3s = textMatKhauChange.Text;
                string mk3r = textMatKhauChange_A.Text;

                if (tk == "") MessageBox.Show("Chưa nhập tên đăng nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (mks == "") MessageBox.Show("Chưa nhập mật khẩu cũ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (mk3s == "") MessageBox.Show("Chưa nhập mật khẩu mới", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (mk3r == "") MessageBox.Show("Chưa nhập lại pass", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (mk3s != mk3r)
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
                }

            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn chắc chắn chấp nhận thử thách?", "Chuẩn bị", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Easy frmC = new Easy();
                delPassData del4 = new delPassData(frmC.funData4);
                del4(this.label13);
                frmC.ShowDialog();
            }       
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mk_d = textMatKhau_Del.Text;
            if (mk_d == "")
            {
                MessageBox.Show("Mật khẩu chưa được nhập", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    conn.Open();
                    string sql2 = "DELETE FROM NGUOIDUNG WHERE MATKHAU = @MATKHAU";
                    SqlCommand command = new SqlCommand(sql2, conn);
                    command.Parameters.AddWithValue("@MATKHAU", textMatKhau_Del.Text);

                    DialogResult tb = MessageBox.Show("Bạn chắc muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (tb == DialogResult.Yes)
                    {
                        // Excute:
                        command.ExecuteNonQuery();
                        MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Profile frmP = new Profile();
                        frmP.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textMatKhau_Del_TextChanged(object sender, EventArgs e)
        {
            button4.Enabled = true;
        }

        private void textPlayerName_TextChanged(object sender, EventArgs e)
        {
            textPlayerName_N.Enabled = true;
        }

        private void textPlayerName_N_TextChanged(object sender, EventArgs e)
        {
            textMatKhau.Enabled = true;
        }

        private void textMatKhau_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void textTenUser_TextChanged(object sender, EventArgs e)
        {
            textMatKhau_S.Enabled = true;
        }

        private void textMatKhau_S_TextChanged(object sender, EventArgs e)
        {
            textMatKhauChange.Enabled = true;
            checkBox1.Enabled = true;
        }

        private void textMatKhauChange_TextChanged(object sender, EventArgs e)
        {
            textMatKhauChange_A.Enabled = true;
        }

        private void textMatKhauChange_A_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void thànhTíchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ketnoicsdl();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Một đi là không thể quay về. Bắt đầu?", "Chuẩn bị", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Normal frmN = new Normal();
                delPassData del4 = new delPassData(frmN.funData4);
                del4(this.label13);
                frmN.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Hãy chuẩn bị tinh thần cho Try Hard", "Chuẩn bị", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tb == DialogResult.Yes)
            {
                Hard frmH = new Hard();
                delPassData del4 = new delPassData(frmH.funData4);
                del4(this.label13);
                frmH.ShowDialog();
            }
        }

        private void textMatKhau_Del_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhau_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textTenUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
        }

        private void textMatKhau_S_KeyPress(object sender, KeyPressEventArgs e)
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

