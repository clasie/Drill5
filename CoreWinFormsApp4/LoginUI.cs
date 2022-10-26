using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWinFormsApp4
{
    public partial class LoginUI : Form
    {
        public bool IsLogged = false;
        public LoginUI()
        {
            InitializeComponent();
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {

        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "" || txt_password.Text == "")
            {
                MessageBox.Show("Empty creds");
                return;
            }
            else if (txt_name.Text == "a" || txt_password.Text == "a")
            {
                this.IsLogged = true;
                this.Close();
            }
            else {
                MessageBox.Show("Bad creds");
            }
        }

        private void txt_name_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_validate.PerformClick();
            }
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_validate.PerformClick();
            }
        }
    }
}
