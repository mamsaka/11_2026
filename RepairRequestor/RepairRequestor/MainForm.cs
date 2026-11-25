using System;
using System.Windows.Forms;
using RepairRequestor.services;

namespace RepairRequestor
{
    public partial class MainForm : Form
    {
        private readonly UserSession currentUser;

        public MainForm(UserSession user)
        {
            currentUser = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();
            UserInfoLabel.Text = currentUser.FullName;
            RoleLabel.Text = "Роль: " + currentUser.RoleDisplayName;
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
