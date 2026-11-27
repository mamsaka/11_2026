namespace RepairRequestor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.RequestsGrid = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReserveCopyButton = new System.Windows.Forms.Button();
            this.RestoreButton = new System.Windows.Forms.Button();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.HeaderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HeaderPanel.Controls.Add(this.LogoutButton);
            this.HeaderPanel.Controls.Add(this.RoleLabel);
            this.HeaderPanel.Controls.Add(this.UserInfoLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(800, 68);
            this.HeaderPanel.TabIndex = 0;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoutButton.Location = new System.Drawing.Point(670, 18);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(110, 32);
            this.LogoutButton.TabIndex = 2;
            this.LogoutButton.Text = "Выйти";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(18, 40);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(42, 16);
            this.RoleLabel.TabIndex = 1;
            this.RoleLabel.Text = "Роль:";
            // 
            // UserInfoLabel
            // 
            this.UserInfoLabel.AutoSize = true;
            this.UserInfoLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.UserInfoLabel.Location = new System.Drawing.Point(16, 8);
            this.UserInfoLabel.Name = "UserInfoLabel";
            this.UserInfoLabel.Size = new System.Drawing.Size(60, 28);
            this.UserInfoLabel.TabIndex = 0;
            this.UserInfoLabel.Text = "ФИО";
            // 
            // RequestsGrid
            // 
            this.RequestsGrid.AllowUserToAddRows = false;
            this.RequestsGrid.AllowUserToDeleteRows = false;
            this.RequestsGrid.AllowUserToResizeRows = false;
            this.RequestsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.RequestsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RequestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colEmployee,
            this.colEquipment,
            this.colProblem,
            this.colCreated,
            this.colSpecialist,
            this.colStatus});
            this.RequestsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestsGrid.Location = new System.Drawing.Point(0, 68);
            this.RequestsGrid.MultiSelect = false;
            this.RequestsGrid.Name = "RequestsGrid";
            this.RequestsGrid.RowHeadersVisible = false;
            this.RequestsGrid.RowHeadersWidth = 51;
            this.RequestsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestsGrid.Size = new System.Drawing.Size(800, 382);
            this.RequestsGrid.TabIndex = 1;
            this.RequestsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RequestsGrid_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.FillWeight = 40F;
            this.colId.HeaderText = "№";
            this.colId.MinimumWidth = 6;
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colEmployee
            // 
            this.colEmployee.DataPropertyName = "EmployeeName";
            this.colEmployee.FillWeight = 120F;
            this.colEmployee.HeaderText = "Заявитель";
            this.colEmployee.MinimumWidth = 6;
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            // 
            // colEquipment
            // 
            this.colEquipment.DataPropertyName = "EquipmentTypeName";
            this.colEquipment.FillWeight = 90F;
            this.colEquipment.HeaderText = "Тип оборудования";
            this.colEquipment.MinimumWidth = 6;
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.ReadOnly = true;
            // 
            // colProblem
            // 
            this.colProblem.DataPropertyName = "ProblemDescription";
            this.colProblem.FillWeight = 220F;
            this.colProblem.HeaderText = "Описание проблемы";
            this.colProblem.MinimumWidth = 6;
            this.colProblem.Name = "colProblem";
            this.colProblem.ReadOnly = true;
            // 
            // colCreated
            // 
            this.colCreated.DataPropertyName = "CreatedAt";
            this.colCreated.HeaderText = "Дата создания";
            this.colCreated.MinimumWidth = 6;
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            // 
            // colSpecialist
            // 
            this.colSpecialist.DataPropertyName = "SpecialistName";
            this.colSpecialist.FillWeight = 120F;
            this.colSpecialist.HeaderText = "Исполнитель";
            this.colSpecialist.MinimumWidth = 6;
            this.colSpecialist.Name = "colSpecialist";
            this.colSpecialist.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "StatusName";
            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "Статус";
            this.colStatus.MinimumWidth = 6;
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // ReserveCopyButton
            // 
            this.ReserveCopyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ReserveCopyButton.Location = new System.Drawing.Point(586, 406);
            this.ReserveCopyButton.Name = "ReserveCopyButton";
            this.ReserveCopyButton.Size = new System.Drawing.Size(200, 32);
            this.ReserveCopyButton.TabIndex = 3;
            this.ReserveCopyButton.Text = "Резервное копирование";
            this.ReserveCopyButton.UseVisualStyleBackColor = true;
            this.ReserveCopyButton.Visible = false;
            this.ReserveCopyButton.Click += new System.EventHandler(this.ReserveCopyButton_Click);
            // 
            // RestoreButton
            // 
            this.RestoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RestoreButton.Location = new System.Drawing.Point(378, 406);
            this.RestoreButton.Name = "RestoreButton";
            this.RestoreButton.Size = new System.Drawing.Size(200, 32);
            this.RestoreButton.TabIndex = 4;
            this.RestoreButton.Text = "Восстановить из копии";
            this.RestoreButton.UseVisualStyleBackColor = true;
            this.RestoreButton.Visible = false;
            this.RestoreButton.Click += new System.EventHandler(this.RestoreButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RestoreButton);
            this.Controls.Add(this.ReserveCopyButton);
            this.Controls.Add(this.RequestsGrid);
            this.Controls.Add(this.HeaderPanel);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт заявок на ремонт оборудования";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RequestsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label UserInfoLabel;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.DataGridView RequestsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEquipment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProblem;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSpecialist;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Button ReserveCopyButton;
        private System.Windows.Forms.Button RestoreButton;
    }
}
