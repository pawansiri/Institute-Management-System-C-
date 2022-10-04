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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnTeachRegister_Click(object sender, EventArgs e)
        {
            RegisterTeacher tech = new RegisterTeacher();
            tech.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM teacher WHERE TeacherID = '" + txtTeachSearch.Text + "'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable td = new DataTable();
                adapter.Fill(td);
                dataGridView2.DataSource = td;
                con.Close();
                clrData();
            }
            catch
            {

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure want to delete this field", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand et = new SqlCommand("DELETE FROM teacher WHERE TeacherID = '" + txtTeachSearch + "'", con);
                    et.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Field Deleted");
                    clrData();
                    txtTeachSearch.Focus();
                }
            }
            catch (Exception ui)
            {
                MessageBox.Show(ui.Message);
            }
        }
        public void clrData()
        {
            txtTeachSearch.Clear();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home et = new Home();
            et.Show();
            this.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student u = new Student();
            u.Show();
            this.Hide();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance kj = new Attendance();
            kj.Show();
            this.Hide();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Payment hg = new Payment();
            hg.Show();
            this.Hide();
        }
    }
}
