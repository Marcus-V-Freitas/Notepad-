using System;
using System.Windows.Forms;

namespace Notepad__
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if ((textBoxUsername.Text == "marcus") && (textBoxPassword.Text == "marcus"))
            {
                this.Close();
                Notepad obj = new Notepad();
                obj.Show();
            }
            else
                MessageBox.Show("Please Enter Correct Username and Password", "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
            Notepad obj = new Notepad();
            obj.Show();
        }
    }
}