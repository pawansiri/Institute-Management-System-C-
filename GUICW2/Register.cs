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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                
                string gender;
                if (radMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                string grade = cboGrade.Text;
                string fName = txtFirstName.Text, lName = txtLastName.Text;
                if (fName.All(char.IsLetter) == true) 
                {
                    if (lName.All(char.IsLetter) == true)
                    {
                        if (txtStudentID.Text == "" && txtFirstName.Text == "" && txtLastName.Text == "" )
                        {
                            MessageBox.Show("Please Fill Required Details");

                        }
                        else 
                        {
                            string data = ("INSERT INTO student(StudentID,FirstName,LastName,School,GuardianName,Grade,Gender,Address,City,ZipCode)VALUES('"+txtStudentID.Text+"','"+txtFirstName.Text+"','"+txtLastName.Text+"','"+txtSchool.Text+"','"+txtGuardName.Text+"','"+grade+"','"+gender+"','"+txtAddress.Text+"','"+txtCity.Text+"','"+txtZipCode.Text+"')");
                            con.Open();
                            SqlCommand cmd = new SqlCommand(data,con);
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Data Saved","Sucess",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            clearData();
                            txtStudentID.Focus();
                        }
                    }
                }
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clearData()
        {
            txtStudentID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtSchool.Clear();
            txtGuardName.Clear();
            txtAddress.Clear();
            txtCity.Clear();
            txtZipCode.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string grade = cboGrade.Text, gender;
                if (radMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                if (txtStudentID.Text == "")
                {
                    MessageBox.Show("Please Enter Student ID to Update");
                    clearData();
                    txtStudentID.Focus();
                }
                else
                {
                    string data = ("UPDATE student SET(StudentID='" + txtStudentID.Text + "',FirstName='" + txtFirstName.Text + "',LastName='" + txtLastName.Text + "',School='" + txtSchool.Text + "',GuardianName='" + txtGuardName.Text + "',Grade='" + grade + "',Gender='" + gender + "',Address='" + txtAddress.Text + "',City='" + txtCity.Text + "',ZipCode='" + txtZipCode.Text + "')WHERE StudentID='" + txtStudentID.Text + "'");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(data, con);
                    //cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Field Updated Sucessfully", "Done");
                    clearData();
                    txtStudentID.Focus();

                }
                
            }
            catch (Exception yt)
            {
                MessageBox.Show(yt.Message);

            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are sure want to go back,All the data will be lost?","Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                Student r = new Student();
                r.Show();
                this.Hide();
            }
        }
    }
}
