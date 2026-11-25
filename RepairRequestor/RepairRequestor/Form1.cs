using System;
using System.Windows.Forms;
using RepairRequestor.services;

namespace RepairRequestor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            LoginButton.Enabled = false;

            try
            {
                AuthResult result = AuthService.Login(LoginInput.Text, PasswordInput.Text);

                if (!result.Success)
                {
                    MessageBox.Show(
                        this,
                        result.ErrorMessage,
                        "Ошибка входа",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    PasswordInput.Clear();
                    PasswordInput.Focus();
                    return;
                }

                OpenMainForm(result.User);
            }
            finally
            {
                LoginButton.Enabled = true;
            }
        }

        private void OpenMainForm(UserSession user)
        {
            Hide();

            try
            {
                using (MainForm mainForm = new MainForm(user))
                {
                    mainForm.ShowDialog(this);
                }
            }
            finally
            {
                PasswordInput.Clear();
                Show();
                Activate();
                LoginInput.Focus();
            }
        }
    }
}
