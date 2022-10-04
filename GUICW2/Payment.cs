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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnPay_Click(object sender, EventArgs e)
        {
            double amount = 0 ;
            int count = 0;
            if(txtPayStudentID.Text == "" && txtPayName.Text == "" && cboStream.Text == "")
            {
                MessageBox.Show("Please Enter Required Details");
                txtPayStudentID.Focus();
            }

            else 
            {
                if(radSubject1.Checked)
                {
                    amount = 1000;
                    count = 1;
                    if(MessageBox.Show(" Amount is 1000 ,Do you Confirm the Payment?") == DialogResult.OK)
                    {

                        txtTotal.Text = amount.ToString();
                    }
                   
                    
                }
                else if(radSubject2.Checked)
                {
                    amount = 3000;
                    count = 2;
                    if (MessageBox.Show(" Amount is 3000 ,Do you Confirm the Payment?") == DialogResult.OK)
                    {
                        txtTotal.Text = amount.ToString();
                    }
                }
                else
                {
                    amount = 6000;
                    count = 3;
                    if (MessageBox.Show(" Amount is 6000 ,Do you Confirm the Payment?") == DialogResult.OK)
                    {
                        txtTotal.Text = amount.ToString();
                    }
                }

                try
                {
                    string payData = ("INSERT INTO payment(StudentID,Name,Stream,Amount,NoOfSubjects)VALUES('" + txtPayStudentID.Text + "','" + txtPayName.Text + "','"+cboStream.Text+"','" + amount + "','"+count+"')");
                    con.Open();
                    SqlCommand kl = new SqlCommand(payData, con);
                    kl.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Payment Saved","Done",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    clrPayData();
                    txtPayStudentID.Focus();


                }
                catch(Exception et)
                {
                    MessageBox.Show(et.Message);
                }



            }



            
           
            




        }
        private void clrPayData()
        {
            txtPayStudentID.Clear();
            txtPayName.Clear();
            txtTotal.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try 
            {
                if(txtPaySearch.Text == "")
                {
                    MessageBox.Show("Please Enter a Student ID to Search", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    txtPaySearch.Focus();
                }
                else
                {
                    con.Open();
                    SqlCommand sp = new SqlCommand("SELECT * FROM payment WHERE StudentID = '" + txtPaySearch.Text + "'", con);
                    SqlDataAdapter adap = new SqlDataAdapter(sp);
                    DataTable td = new DataTable();
                    adap.Fill(td);
                    dataGridPayment.DataSource = td;
                    con.Close();
                    txtPaySearch.Clear();
                    txtPaySearch.Focus();
                    
                }
               
            }
            catch (Exception y)
            {
                MessageBox.Show(y.Message);
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Home y = new Home();
            y.Show();
            this.Hide();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student yr = new Student();
            yr.Show();
            this.Hide();
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Teacher g = new Teacher();
            g.Show();
            this.Hide();
        }

        private void attendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Attendance oi = new Attendance();
            oi.Show();
            this.Hide();
        }
    }
    
   
}
