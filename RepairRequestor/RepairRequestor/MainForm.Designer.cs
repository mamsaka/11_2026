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
            this.UserInfoLabel = new System.Windows.Forms.Label();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.RequestsGrid = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEquipment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProblem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSpecialist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(18, 40);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(50, 17);
            this.RoleLabel.TabIndex = 1;
            this.RoleLabel.Text = "Роль:";
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
            this.RequestsGrid.ReadOnly = true;
            this.RequestsGrid.RowHeadersVisible = false;
            this.RequestsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestsGrid.Size = new System.Drawing.Size(800, 382);
            this.RequestsGrid.TabIndex = 1;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id";
            this.colId.FillWeight = 40F;
            this.colId.HeaderText = "№";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colEmployee
            // 
            this.colEmployee.DataPropertyName = "EmployeeName";
            this.colEmployee.FillWeight = 120F;
            this.colEmployee.HeaderText = "Заявитель";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            // 
            // colEquipment
            // 
            this.colEquipment.DataPropertyName = "EquipmentTypeName";
            this.colEquipment.FillWeight = 90F;
            this.colEquipment.HeaderText = "Тип оборудования";
            this.colEquipment.Name = "colEquipment";
            this.colEquipment.ReadOnly = true;
            // 
            // colProblem
            // 
            this.colProblem.DataPropertyName = "ProblemDescription";
            this.colProblem.FillWeight = 220F;
            this.colProblem.HeaderText = "Описание проблемы";
            this.colProblem.Name = "colProblem";
            this.colProblem.ReadOnly = true;
            // 
            // colCreated
            // 
            this.colCreated.DataPropertyName = "CreatedAt";
            this.colCreated.FillWeight = 100F;
            this.colCreated.HeaderText = "Дата создания";
            this.colCreated.Name = "colCreated";
            this.colCreated.ReadOnly = true;
            // 
            // colSpecialist
            // 
            this.colSpecialist.DataPropertyName = "SpecialistName";
            this.colSpecialist.FillWeight = 120F;
            this.colSpecialist.HeaderText = "Исполнитель";
            this.colSpecialist.Name = "colSpecialist";
            this.colSpecialist.ReadOnly = true;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "StatusName";
            this.colStatus.FillWeight = 80F;
            this.colStatus.HeaderText = "Статус";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.PerformLayout();

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
    }
}
