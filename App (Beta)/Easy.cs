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
    public partial class Easy : Form
    {
        public void funData4(Label label13) { label8.Text = label13.Text; }
        public Easy()
        {
            InitializeComponent();
        }
        private int inext = 1;
        private int idem;
        private int iscore = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            timer1.Start();

            label13.Visible = false;
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P0ROQPB\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                conn.Open(); // Kết nối           
                idem = int.Parse(label16.Text.ToString());
                iscore = int.Parse(label17.Text.ToString());
                inext = int.Parse(label20.Text.ToString());
                string d_a = label1.Text;
                string d_b = label2.Text;
                string d_c = label4.Text;
                string d_d = label3.Text;
                string stt = label5.Text;
                string cauhoi = richTextBox1.Text;

                string sql = "SELECT * FROM EASY_QUESTION where STT = '"+label16.Text.ToString()+"'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    label1.Text = (dr["DAPAN_A"].ToString());
                    label2.Text = (dr["DAPAN_B"].ToString());
                    label4.Text = (dr["DAPAN_C"].ToString());
                    label3.Text = (dr["DAPAN_D"].ToString());
                    label5.Text = (dr["STT"].ToString());
                    richTextBox1.Text = (dr["TENCAU"].ToString());
                }
                else
                {
                    label1.Text = "";
                    label2.Text = "";
                    label4.Text = "";
                    label3.Text = "";
                    richTextBox1.Text = "";
                    MessageBox.Show("Không tìm thấy câu hỏi", "Lỗi",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P0ROQPB\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                button1.Visible = true;
                conn.Open();
                string kt = label19.Text;

                string d_a = label1.Text;
                string d_b = label2.Text;
                string d_c = label4.Text;
                string d_d = label3.Text;
                string stt = label5.Text;
                string cauhoi = richTextBox1.Text;
                inext = int.Parse(label20.Text.ToString());

                int iscore = int.Parse(label17.Text.ToString());
                int idem = int.Parse(label16.Text.ToString());

                string sql2 = "select *from EASY_QUESTION where STT = '" + stt + "' and DAPAN_DUNG ='" + kt + "'";
                SqlCommand cmd = new SqlCommand(sql2, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)
                {
                    iscore = iscore + 15;
                    label17.Text = iscore.ToString();
                    MessageBox.Show("Bạn thông minh quá. Trả lời đúng rồi :))", "Chuẩn cmnr!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Random rd = new Random();
                    idem = rd.Next(1,30);
                    label16.Text = idem.ToString(); 
                    inext = inext + 1;
                    label20.Text = inext.ToString();
                    button2.Visible = false;
                    label17.Text = iscore.ToString();
                    label14.Text = "10";
                }
                else 
                {
                    MessageBox.Show("Bạn thất bại vl!!!", "Trả lời sai rồi :((", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tùyChọnToolStripMenuItem.Enabled = false;
                    label11.Visible = true;
                    label17.Text = iscore.ToString();
                    label18.Text = iscore.ToString();
                    button3.Enabled = true;
                    richTextBox1.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                }
            }
            catch 
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            label19.Text = "A";
            button2.Visible = true;
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            label19.Text = "C";
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-P0ROQPB\SQLEXPRESS;Initial Catalog=QUIZ;Integrated Security=True");
            try
            {
                string mk = label8.Text;
                conn.Open();
                string sql3 = "UPDATE NGUOIDUNG SET DE = @DE WHERE MATKHAU = @MATKHAU";
                SqlCommand cmd2 = new SqlCommand(sql3, conn);
                cmd2.Parameters.AddWithValue("@DE", label18.Text);
                cmd2.Parameters.AddWithValue("@MATKHAU", label8.Text);
                // Excute:
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Đã lưu vào bảng điểm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bỏCuộcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label14.Text = "10";
            int iscore = int.Parse(label17.Text.ToString());
            timer1.Stop();

            label12.Visible = true;
            label15.Visible = true;
            label17.Text = iscore.ToString();
            label18.Text = iscore.ToString();
            button3.Enabled = true;
            richTextBox1.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int time = int.Parse(label14.Text);
            time--;
            if (time < 10)
            {
                label14.Text = "0" + time;
            }
            if (time == 0)
            {
                timer1.Stop();
                MessageBox.Show("Hết Giờ!", "Thông Báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                tùyChọnToolStripMenuItem.Enabled = false;
                label15.Visible = true;
                button3.Enabled = true;
                richTextBox1.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false; 
                label11.Visible = true;
                label17.Text = iscore.ToString();
                label18.Text = iscore.ToString();
            }
        }

        private void radioButton2_Click_1(object sender, EventArgs e)
        {
            label19.Text = "B";
            button2.Visible = true;
        }

        private void radioButton4_Click_1(object sender, EventArgs e)
        {
            label19.Text = "D";
            button2.Visible = true;
        }
    }
}
