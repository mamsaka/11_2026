using RepairRequestor.services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace RepairRequestor
{
    public partial class MainForm : Form
    {
        private readonly UserSession currentUser;

        public MainForm(UserSession user)
        {
            currentUser = user ?? throw new ArgumentNullException(nameof(user));

            InitializeComponent();
            ReserveCopyButton.Visible = currentUser.Role == UserRole.Administrator;
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

        private void ReserveCopyButton_Click(object sender, EventArgs e)
        {
            string defaultFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "RepairRequestorReserveCopies");

            // Папку нужно создать ДО показа диалога: на несуществующий
            // InitialDirectory SaveFileDialog молча откроется в «Документах».
            try
            {
                Directory.CreateDirectory(defaultFolder);
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception);
            }

            using (SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "База данных SQLite (*.db)|*.db|Все файлы (*.*)|*.*",
                InitialDirectory = defaultFolder,
                FileName = "repair-db-" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".db",
                AddExtension = true,
                DefaultExt = "db",
                OverwritePrompt = true
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    DatabaseHandler.BackupDBToFile(dialog.FileName);

                    MessageBox.Show(
                        this,
                        "Резервная копия базы данных создана:" + Environment.NewLine + dialog.FileName,
                        "Готово",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (DatabaseUnavailableException exception)
                {
                    MessageBox.Show(this, exception.Message, "Ошибка базы данных",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (IOException exception)
                {
                    MessageBox.Show(this,
                        "Не удалось записать файл. Возможно, он открыт в другой программе." +
                        Environment.NewLine + Environment.NewLine + exception.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception);
                    MessageBox.Show(this, "Не удалось создать резервную копию базы данных.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

    }
}
