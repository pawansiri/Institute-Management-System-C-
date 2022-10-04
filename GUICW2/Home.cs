using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUICW2
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student a = new Student();
            a.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teacher a = new Teacher();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Attendance b = new Attendance();
            b.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure want to logout","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                Login o = new Login();
                o.Show();
                this.Hide();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Payment k = new Payment();
            k.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register op = new Register();
            op.Show();
            this.Hide();

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterTeacher pk = new RegisterTeacher();
            pk.Show();
            this.Hide();

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student ab = new Student();
            ab.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher ac = new Teacher();
            ac.Show();
            this.Hide();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance ak = new Attendance();
            ak.Show();
            this.Hide();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment al = new Payment();
            al.Show();
            this.Hide();
        }
    }
}
