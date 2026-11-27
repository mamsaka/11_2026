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

            bool isAdministrator = currentUser.Role == UserRole.Administrator;
            bool isSpecialist = currentUser.Role == UserRole.Specialist;

            // Специальные настройки для администратора
            if (isAdministrator)
            {
                ReserveCopyButton.Visible = true;
                RestoreButton.Visible = true;
            }

            // Специальные настройки для специалиста
            if (isSpecialist)
            {
                RequestsGrid.CellDoubleClick -= RequestsGrid_CellDoubleClick;

                var colStatus = new DataGridViewComboBoxColumn
                {
                    Name = "colStatus",
                    HeaderText = "Статус",
                    DataPropertyName = nameof(RequestListItem.StatusName),
                    DataSource = new[] { "Новая", "В работе", "Выполнена" },
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton,
                    ReadOnly = false
                };

                int index = RequestsGrid.Columns["colStatus"].Index;
                RequestsGrid.Columns.RemoveAt(index);
                RequestsGrid.Columns.Insert(index, colStatus);
                RequestsGrid.CellValueChanged += RequestsGrid_CellValueChanged;
            }

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
            string defaultFolder = DatabaseHandler.DefaultBackupFolder;

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

        private void RestoreButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "База данных SQLite (*.db)|*.db|Все файлы (*.*)|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                CheckFileExists = true,
                Multiselect = false
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                DialogResult confirm = MessageBox.Show(
                    this,
                    "Текущая база данных будет заменена выбранным файлом:" + Environment.NewLine +
                    dialog.FileName + Environment.NewLine + Environment.NewLine +
                    "Перед заменой автоматически создаётся копия текущей базы." + Environment.NewLine +
                    "Продолжить?",
                    "Восстановление базы данных",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2);

                if (confirm != DialogResult.Yes)
                {
                    return;
                }

                try
                {
                    string backupPath = DatabaseHandler.RestoreDBFromFile(dialog.FileName);
                    LoadRequests();

                    string message = "База данных восстановлена из файла:" + Environment.NewLine +
                                     dialog.FileName;
                    if (!string.IsNullOrEmpty(backupPath))
                    {
                        message += Environment.NewLine + Environment.NewLine +
                                   "Копия прежней базы сохранена:" + Environment.NewLine + backupPath;
                    }

                    MessageBox.Show(this, message, "Готово",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DatabaseUnavailableException exception)
                {
                    MessageBox.Show(this, exception.Message, "Ошибка базы данных",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (IOException exception)
                {
                    MessageBox.Show(this,
                        "Не удалось заменить файл базы данных. Возможно, он используется другой программой." +
                        Environment.NewLine + Environment.NewLine + exception.Message,
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception exception)
                {
                    System.Diagnostics.Debug.WriteLine(exception);
                    MessageBox.Show(this, "Не удалось восстановить базу данных.", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void RequestsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            RequestListItem request = RequestsGrid.Rows[e.RowIndex].DataBoundItem as RequestListItem;
            if (request == null)
            {
                return;
            }

            using (RequestAddOrEditForm form = new RequestAddOrEditForm(request, currentUser))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    LoadRequests();
                }
            }
        }
        
        private void RequestsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
