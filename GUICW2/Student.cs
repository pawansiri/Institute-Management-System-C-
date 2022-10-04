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

namespace GUICW2
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");


        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register a = new Register();
            a.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != null)
                {
                    string search = ("SELECT * FROM student WHERE StudentID = '" + txtSearch.Text + "'");

                    con.Open();
                    SqlCommand smd = new SqlCommand(search, con);
                    SqlDataAdapter adp = new SqlDataAdapter(smd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();

                }
                else
                {
                    MessageBox.Show("Please Enter a Valid Student ID");
                }
            }
            catch(Exception td)
            {
                MessageBox.Show(td.Message);
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtSearch.Text != null)
                {
                    
                    if (MessageBox.Show("Are you sure want to Delete this Field?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        string delete = ("DELETE FROM student WHERE StudentID = '" + txtSearch.Text + "'");
                        con.Open();
                        SqlCommand cmd = new SqlCommand(delete, con);
                        //cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Deleted Succesfuly");

                    }
                    
                }
               

            }
            catch 
            {

            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home k = new Home();
            k.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher r = new Teacher();
            r.Show();
            this.Hide();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance p = new Attendance();
            p.Show();
            this.Hide();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment bl = new Payment();
            bl.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
