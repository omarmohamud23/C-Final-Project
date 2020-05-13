using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C__FINALPROJ
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
		}
		//Creating a double variable named count which is initialized to zero.
		double count = 0;
		private void LoginForm_Load(object sender, EventArgs e)
		{

		}

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			//Setting the username to username and the password to password. Whether both the username and password contain small letters and capital letters, both will meet this condition.
			if ((txtUsername.Text.ToUpper() == "USERNAME") && (txtPassword.Text.ToUpper() == "PASSWORD"))
			{
				//If the above condition is met a welcome message pops up
				MessageBox.Show("Successfully logged in Welcome User");
			}

			//If either of the textboxes is empty, a message box pops and the textboxes are cleared and the focus is put on the first textbox.
			else if ((txtUsername.Text == string.Empty) || (txtPassword.Text == string.Empty))
			{
				MessageBox.Show("Please input the blank box");

				txtUsername.Clear();
				txtPassword.Clear();
				txtUsername.Focus();
			}

			else
			{
				//The count is incremented everytime the user puts in wrong username or password
				count = count + 1;

				//Creating a double variable named maxcount and initialize it to three. maxcount is how many tries the user is allowed to put in wrong username or password.
				double maxcount = 3;

				//Creating a variable named remain which is equal to maxcount - count.
				double remain = maxcount - count;

				MessageBox.Show("Wrong Username or password" + "\t" + remain + "" + "try left");

				txtUsername.Clear();
				txtPassword.Clear();
				txtUsername.Focus();

				//if the count is equal to the maxcount, a message box will pop up with the below message.
				if (count == maxcount)
				{
					MessageBox.Show("you exceeded the maximum try limit");

					//The application will be exited.
					Application.Exit();

				}


			}
		}

		//The textboxes are cleared and the focus is put on the first textbox.
		private void BtnReset_Click(object sender, EventArgs e)
		{
			txtUsername.Clear();
			txtPassword.Clear();
			txtUsername.Focus();
		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			this.Close(); //this closes the project.
		}

		// creating link label to take the suers who dont have accounts to Registration form
		private void lnkopenReg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RegistrationForm register = new RegistrationForm();
			register.ShowDialog();  //OPENS REgitrstaion form
		}
	}
}
