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
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnAttend_Click(object sender, EventArgs e)
        {
            try 
            {
                if (txtAtStudentID.Text == "" && txtAtFirstName.Text == "")
                {
                    MessageBox.Show("Please Enter StudentID and Name");
                    txtAtStudentID.Focus();
                }
                else
                {
                    DateTime DateTime = Convert.ToDateTime(dtpAttdend.Text);
                    string attend = ("INSERT INTO attendance(AttStudentID,Name,DateTime)VALUES('"+txtAtStudentID.Text+"','"+txtAtFirstName.Text+"','"+DateTime+"')");
                    con.Open();
                    SqlCommand stAttend = new SqlCommand(attend, con);
                    stAttend.ExecuteNonQuery();
                    con.Close();
                    clrData();
                    MessageBox.Show("Record Saved Successfuly");

                }
            }
            catch (Exception ty)
            {
                MessageBox.Show(ty.Message);
            }
        }

        private void clrData()
        {
            txtAtStudentID.Clear();
            txtAtFirstName.Clear();
            

        }

        private void btnAtSearch_Click(object sender, EventArgs e)
        {
            try 
            {
                if(txtAtSearch.Text == "")
                {
                    MessageBox.Show("Please Enter a Student ID");
                }
                else
                {
                    con.Open();
                    SqlCommand cms = new SqlCommand("SELECT * FROM attendance ",con);
                    SqlDataAdapter ata = new SqlDataAdapter(cms);
                    DataTable tx = new DataTable();
                    ata.Fill(tx);
                    dataGridAttend.DataSource = tx;
                    con.Close();
                }
            }
            catch 
            {
                
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home ut = new Home();
            ut.Show();
            this.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student re = new Student();
            re.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher qe = new Teacher();
            qe.Show();
            this.Hide();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance x = new Attendance();
            x.Show();
            this.Hide();
        }
    }
}
