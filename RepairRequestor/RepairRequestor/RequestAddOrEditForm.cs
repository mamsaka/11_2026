using System;
using System.Windows.Forms;
using RepairRequestor.services;

namespace RepairRequestor
{
    /// <summary>
    /// Форма создания и редактирования заявки.
    /// В режиме редактирования заполняется данными выбранной заявки
    /// и данными пользователя, который её открыл.
    /// </summary>
    public partial class RequestAddOrEditForm : Form
    {
        private readonly RequestListItem request;
        private readonly UserSession currentUser;

        public RequestAddOrEditForm()
        {
            InitializeComponent();
        }

        public RequestAddOrEditForm(RequestListItem request, UserSession currentUser)
            : this()
        {
            this.request = request;
            this.currentUser = currentUser;

            FillCurrentUser();
            FillRequest();
        }

        private void FillCurrentUser()
        {
            if (currentUser == null)
            {
                return;
            }
        }

        private void FillRequest()
        {
            if (request == null)
            {
                Text = "Новая заявка";
                StatusTextBox.Text = "Новая";

                // Сотрудник оформляет заявку на себя — подставляем его ФИО.
                if (currentUser != null && currentUser.Role == UserRole.Employee)
                {
                    EmployeeTextBox.Text = currentUser.FullName;
                }

                return;
            }

            Text = "Заявка №" + request.Id;

            EmployeeTextBox.Text = request.EmployeeName;
            EquipmentTextBox.Text = request.EquipmentTypeName;
            StatusTextBox.Text = request.StatusName;
            SpecialistTextBox.Text = request.SpecialistName;
            CreatedAtTextBox.Text = request.CreatedAt;
            ProblemTextBox.Text = request.ProblemDescription;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (request == null)
            {
                RequestAdd();
            }
            else
            {
                RequestEdit();
            }
        }

        private void RequestAdd()
        {
        }

        private void RequestEdit()
        {
        }
    }
}
