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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        private void btnLog_Click(object sender, EventArgs e)
        {
            textUserName.Focus();
            if(textUserName.Text == "" && textPassword.Text == "")
            {
                MessageBox.Show("Invalid Login Details,Please try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textUserName.Focus();
            }
            else if (textUserName.Text != "excel" && textPassword.Text != "1234")
            {
                MessageBox.Show("User Name or Password Incorrect,Please Try Again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textPassword.Clear();
                textUserName.Clear();
                textUserName.Focus();
            }
            else if(textUserName.Text == "excel" && textPassword.Text == "1234")
            {
                Home a = new Home();
                a.Show();
                this.Hide();
            }
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }
    }
}
