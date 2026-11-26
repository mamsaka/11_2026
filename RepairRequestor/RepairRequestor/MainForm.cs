using System;
using System.Collections.Generic;
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

            LoadRequests();
        }

        private void LoadRequests()
        {
            try
            {
                int userId = currentUser.Role == UserRole.Employee ? currentUser.Id : -1;
                List<RequestListItem> requests = DatabaseHandler.GetRequests(userId);
                RequestsGrid.DataSource = requests;
            }
            catch (DatabaseUnavailableException exception)
            {
                MessageBox.Show(
                    this,
                    exception.Message,
                    "Ошибка базы данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    this,
                    "Не удалось загрузить список заявок.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
