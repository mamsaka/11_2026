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
            this.PlaceholderLabel = new System.Windows.Forms.Label();
            this.HeaderPanel.SuspendLayout();
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
            // PlaceholderLabel
            // 
            this.PlaceholderLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlaceholderLabel.AutoSize = true;
            this.PlaceholderLabel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.PlaceholderLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.PlaceholderLabel.Location = new System.Drawing.Point(190, 210);
            this.PlaceholderLabel.Name = "PlaceholderLabel";
            this.PlaceholderLabel.Size = new System.Drawing.Size(420, 23);
            this.PlaceholderLabel.TabIndex = 1;
            this.PlaceholderLabel.Text = "Главный экран: список заявок будет добавлен на следующем этапе.";
            this.PlaceholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PlaceholderLabel);
            this.Controls.Add(this.HeaderPanel);
            this.MinimumSize = new System.Drawing.Size(600, 350);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Учёт заявок на ремонт оборудования";
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.Label UserInfoLabel;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.Button LogoutButton;
        private System.Windows.Forms.Label PlaceholderLabel;
    }
}
