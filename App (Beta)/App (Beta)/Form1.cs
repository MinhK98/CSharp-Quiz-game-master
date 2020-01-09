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
using System.Threading;

namespace App__Beta_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Thread t = new Thread(new ThreadStart(App__Beta_));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
            //load();
        }
        //void load()
        //{
        //    Profile p = new Profile();
        //    p.DangXuat += P_DangXuat;
        //}

        //private void P_DangXuat(object sender, EventArgs e)
        //{
        //    (sender as Profile).Close();
        //    this.Show();
        //}

        private void App__Beta_()
        {
            Application.Run(new Welcome());
        }

        private void tácGiảToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Coded by Nhóm 9:\n 1. Nguyễn Khắc Minh\n 2. Vũ Quang Linh\n 3. Đào Văn Hảo\n 4. Bùi Quang Chí", "Tác giả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void phiênBảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Version 0.2.5","Phiên bản",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void cáchChơiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("- Người chơi đăng nhập tài khoản hoặc đăng ký để bắt đầu.\n- Có 3 chế độ: Dễ, trung bình và khó. Tùy theo 3 chế độ mà câu hỏi và thời gian tương ứng khác nhau:\n + Dễ: Câu hỏi đơn giản và thời gian trôi chậm.\n + Trung bình: Câu hỏi bình thường, hơi lắt léo và thời gian trôi nhanh hơn.\n + Khó: Câu hỏi cực troll và hóc búa, thời gian chạy cực nhanh.\n- Mỗi câu hỏi có 10 giây để người chơi trả lời.\n- Người chơi trả lời sai hoặc hết giờ sẽ thua cuộc và dừng cuộc chơi. Thành tích sẽ được lưu vào bảng điểm.\n- Bạn có thể dừng chơi bằng cách nhấn vào Bạn đã nạn chí --> Bỏ cuộc.\n *CHÚC BẠN MAY MẮN*", "Cách chơi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mẹoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hãy thật nhanh tay nhanh mắt. Nhưng đừng tay nhanh hơn não nhé :))", "Mẹo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void chiTiếtBảnCậpNhậtToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            MessageBox.Show("- Thay đổi nhỏ và sửa lỗi khác.", "Có gì mới?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sign_in frmSignIn = new Sign_in();
            frmSignIn.ShowDialog();
        }

        private void đăngNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Sign_in frmSignIn = new Sign_in();
            frmSignIn.ShowDialog();
        }

        private void đăngKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SignUp frmSignUp = new SignUp();
            frmSignUp.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Change_password frmFP = new Change_password();
            frmFP.ShowDialog();
        }

        private void tùyChọnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult ex = MessageBox.Show("Bạn muốn thoát game?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ex == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
