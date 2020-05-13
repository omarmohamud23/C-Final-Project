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
using System.Text.RegularExpressions;

namespace C__FINALPROJ
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
       
        //Connecting the project to the database through sqlconnection.
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-CB681IG\SQLEXPRESS;Initial Catalog=LoginDatabase;Integrated Security=True");
        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            con.Open(); //Opening the database communication.
            
            //inserting data into Table regirstration 
            string query = "INSERT INTO tbl_Reg (UserId,Fname,Lname,Email,Address,Gender) VALUES('" + txtUserId.Text + "', '" + txtFirstname.Text + "', '" + txtLastName.Text + "', '" + txtEmail.Text + "', '" + cbxGender.Text + "', '" + txtAddress.Text + "')";
            
            //This is command class which will handle the query and connection object. 
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
          
            SDA.SelectCommand.ExecuteNonQuery(); //Executing the command which inserts data into the Registration Table

            con.Close(); //closing database communication
           
            MessageBox.Show("REGISTERED SUCCESSFULLY !! "); // when the user registeres show this
        }

       private void BtnView_Click(object sender, EventArgs e)
        {
            con.Open(); //opening database communication
            string query = "SELECT * FROM tbl_Reg "; //selecting it from Regirstration Table
           
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);  

            DataTable dt = new DataTable(); //creating new datatable
            SDA.Fill(dt); //filling the data in out new datatable
            dataGridView1.DataSource = dt; 	//binding the datasource to the datagridview1.			 

            con.Close(); //closing database communcation
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            //clearing all the text boxes and the combo box 

            txtFirstname.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            cbxGender.Text = string.Empty; //clearing the combo box 

            txtUserId.Focus(); //focus on the first textbox 

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //simply closing the whole app once the user is done
            this.Close();
        }
    }
}
