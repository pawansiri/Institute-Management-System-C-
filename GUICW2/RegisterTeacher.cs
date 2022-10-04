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
    public partial class RegisterTeacher : Form
    {
        public RegisterTeacher()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Samsung\Documents\ExcelDatabase.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnSave_Click(object sender, EventArgs e)
        {
            string tGender, tSubject,techFName = txtTFirstName.Text,techLName = txtTLastName.Text;

            if (chbScience.Checked)
            {
                tGender = "Male";
            }
            else
            {
                tGender = "Female";
            }


            if (chbScience.Checked)
            {
                tSubject = "Science";
            }
            else if (chbMaths.Checked)
            {
                tSubject = "Mathematics";
            }
            else if (chbComm.Checked)
            {
                tSubject = "Commerce";
            }
            else if (chbArt.Checked)
            {
                tSubject = "Art";
            }
            else
            {
                tSubject = "Technology";
            }
            try
            {

                txtTeacherID.Focus();
                if (techFName.All(char.IsLetter) == true)
                {
                    if(techLName.All(char.IsLetter) == true)
                    {
                        if (txtTeacherID.Text == "" && txtTFirstName.Text == "" && txtTLastName.Text == "")
                        {
                            MessageBox.Show("Please Enter Required Details");
                            txtTeacherID.Focus();
                        }
                        else
                        {
                            string TSave = ("INSERT INTO teacher(TeacherID,FirstName,LastName,Gender,Stream,Address,City,ZipCode)VALUES('" + txtTeacherID.Text + "','" + txtTFirstName.Text + "','" + txtTLastName.Text + "','" + tGender + "','" + tSubject + "','" + txtTAddress.Text + "','" + txtTCity.Text + "','" + txtTZipCode.Text + "')");
                            con.Open();
                            SqlCommand tdm = new SqlCommand(TSave, con);
                            tdm.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Details Saved");
                            clrTdata();
                            txtTeacherID.Focus();


                        }
                    }
                }
               
            }
            catch (Exception c)
            {
                MessageBox.Show(c.Message);
            }
           
           
        }

        private void clrTdata()
        {
            txtTeacherID.Clear();
            txtTFirstName.Clear();
            txtTLastName.Clear();
            txtTAddress.Clear();
            txtTCity.Clear();
            txtTZipCode.Clear();
            
        }

        private void RegisterTeacher_Load(object sender, EventArgs e)
        {
            txtTeacherID.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string tGender, tSubject;

            if (chbScience.Checked)
            {
                tGender = "Male";
            }
            else
            {
                tGender = "Female";
            }


            if (chbScience.Checked)
            {
                tSubject = "Science";
            }
            else if (chbMaths.Checked)
            {
                tSubject = "Mathematics";
            }
            else if (chbComm.Checked)
            {
                tSubject = "Commerce";
            }
            else if (chbArt.Checked)
            {
                tSubject = "Art";
            }
            else
            {
                tSubject = "Technology";
            }

            try
            {
                if (MessageBox.Show("Are you sure want to edit this field", "Warning" ,MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (txtTeacherID.Text == "" && txtTFirstName.Text == "" && txtTLastName.Text == "" && txtTAddress.Text == "" && txtTCity.Text == "" && txtTZipCode.Text == "")
                    {
                        MessageBox.Show("Please Enter teacher ID to update");
                        txtTeacherID.Focus();
                    }
                    else
                    {
                        string editData = ("UPDATE teacher SET(TeacherID = '" + txtTeacherID.Text + "',FirstName = '" + txtTFirstName.Text + "',LastName = '" + txtTLastName.Text + "',Gender = '" + tGender + "', Stream = '" + tSubject + "', Address = '" + txtTAddress.Text + "',City = '" + txtTCity.Text + "',ZipCode = '" + txtTZipCode.Text + "')WHERE TeacherID ='"+txtTeacherID.Text+"' ");
                        con.Open();
                        SqlCommand ted = new SqlCommand(editData, con);
                        ted.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Details Updated");
                        
                    }

                }
               
            }
            catch 
            { 

            }
        }

        private void pictTBack_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are sure want to go back,All the data will be lost?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Teacher l = new Teacher();
                l.Show();
                this.Hide();
            }
        }
    }
}
