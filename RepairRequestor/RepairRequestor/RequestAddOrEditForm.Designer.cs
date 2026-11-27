namespace RepairRequestor
{
    partial class RequestAddOrEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.EmployeeLabel = new System.Windows.Forms.Label();
            this.EmployeeTextBox = new System.Windows.Forms.TextBox();
            this.EquipmentLabel = new System.Windows.Forms.Label();
            this.EquipmentTextBox = new System.Windows.Forms.TextBox();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.SpecialistLabel = new System.Windows.Forms.Label();
            this.SpecialistTextBox = new System.Windows.Forms.TextBox();
            this.CreatedAtLabel = new System.Windows.Forms.Label();
            this.CreatedAtTextBox = new System.Windows.Forms.TextBox();
            this.ProblemLabel = new System.Windows.Forms.Label();
            this.ProblemTextBox = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EmployeeLabel
            // 
            this.EmployeeLabel.AutoSize = true;
            this.EmployeeLabel.Location = new System.Drawing.Point(20, 24);
            this.EmployeeLabel.Name = "EmployeeLabel";
            this.EmployeeLabel.Size = new System.Drawing.Size(77, 16);
            this.EmployeeLabel.TabIndex = 2;
            this.EmployeeLabel.Text = "Заявитель";
            // 
            // EmployeeTextBox
            // 
            this.EmployeeTextBox.Location = new System.Drawing.Point(160, 20);
            this.EmployeeTextBox.Name = "EmployeeTextBox";
            this.EmployeeTextBox.ReadOnly = true;
            this.EmployeeTextBox.Size = new System.Drawing.Size(460, 22);
            this.EmployeeTextBox.TabIndex = 3;
            this.EmployeeTextBox.TabStop = false;
            // 
            // EquipmentLabel
            // 
            this.EquipmentLabel.AutoSize = true;
            this.EquipmentLabel.Location = new System.Drawing.Point(20, 58);
            this.EquipmentLabel.Name = "EquipmentLabel";
            this.EquipmentLabel.Size = new System.Drawing.Size(130, 16);
            this.EquipmentLabel.TabIndex = 4;
            this.EquipmentLabel.Text = "Тип оборудования";
            // 
            // EquipmentTextBox
            // 
            this.EquipmentTextBox.Location = new System.Drawing.Point(160, 54);
            this.EquipmentTextBox.Name = "EquipmentTextBox";
            this.EquipmentTextBox.Size = new System.Drawing.Size(460, 22);
            this.EquipmentTextBox.TabIndex = 5;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(20, 92);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(53, 16);
            this.StatusLabel.TabIndex = 6;
            this.StatusLabel.Text = "Статус";
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Location = new System.Drawing.Point(160, 88);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(460, 22);
            this.StatusTextBox.TabIndex = 7;
            // 
            // SpecialistLabel
            // 
            this.SpecialistLabel.AutoSize = true;
            this.SpecialistLabel.Location = new System.Drawing.Point(20, 126);
            this.SpecialistLabel.Name = "SpecialistLabel";
            this.SpecialistLabel.Size = new System.Drawing.Size(94, 16);
            this.SpecialistLabel.TabIndex = 8;
            this.SpecialistLabel.Text = "Исполнитель";
            // 
            // SpecialistTextBox
            // 
            this.SpecialistTextBox.Location = new System.Drawing.Point(160, 122);
            this.SpecialistTextBox.Name = "SpecialistTextBox";
            this.SpecialistTextBox.Size = new System.Drawing.Size(460, 22);
            this.SpecialistTextBox.TabIndex = 9;
            // 
            // CreatedAtLabel
            // 
            this.CreatedAtLabel.AutoSize = true;
            this.CreatedAtLabel.Location = new System.Drawing.Point(20, 160);
            this.CreatedAtLabel.Name = "CreatedAtLabel";
            this.CreatedAtLabel.Size = new System.Drawing.Size(104, 16);
            this.CreatedAtLabel.TabIndex = 10;
            this.CreatedAtLabel.Text = "Дата создания";
            // 
            // CreatedAtTextBox
            // 
            this.CreatedAtTextBox.Location = new System.Drawing.Point(160, 156);
            this.CreatedAtTextBox.Name = "CreatedAtTextBox";
            this.CreatedAtTextBox.ReadOnly = true;
            this.CreatedAtTextBox.Size = new System.Drawing.Size(460, 22);
            this.CreatedAtTextBox.TabIndex = 11;
            this.CreatedAtTextBox.TabStop = false;
            // 
            // ProblemLabel
            // 
            this.ProblemLabel.AutoSize = true;
            this.ProblemLabel.Location = new System.Drawing.Point(20, 194);
            this.ProblemLabel.Name = "ProblemLabel";
            this.ProblemLabel.Size = new System.Drawing.Size(141, 16);
            this.ProblemLabel.TabIndex = 12;
            this.ProblemLabel.Text = "Описание проблемы";
            // 
            // ProblemTextBox
            // 
            this.ProblemTextBox.Location = new System.Drawing.Point(160, 190);
            this.ProblemTextBox.Multiline = true;
            this.ProblemTextBox.Name = "ProblemTextBox";
            this.ProblemTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProblemTextBox.Size = new System.Drawing.Size(460, 150);
            this.ProblemTextBox.TabIndex = 13;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(360, 466);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(120, 32);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(500, 466);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(120, 32);
            this.CloseButton.TabIndex = 19;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // RequestAddOrEditForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(640, 512);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ProblemTextBox);
            this.Controls.Add(this.ProblemLabel);
            this.Controls.Add(this.CreatedAtTextBox);
            this.Controls.Add(this.CreatedAtLabel);
            this.Controls.Add(this.SpecialistTextBox);
            this.Controls.Add(this.SpecialistLabel);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.EquipmentTextBox);
            this.Controls.Add(this.EquipmentLabel);
            this.Controls.Add(this.EmployeeTextBox);
            this.Controls.Add(this.EmployeeLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RequestAddOrEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заявка на ремонт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label EmployeeLabel;
        private System.Windows.Forms.TextBox EmployeeTextBox;
        private System.Windows.Forms.Label EquipmentLabel;
        private System.Windows.Forms.TextBox EquipmentTextBox;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.Label SpecialistLabel;
        private System.Windows.Forms.TextBox SpecialistTextBox;
        private System.Windows.Forms.Label CreatedAtLabel;
        private System.Windows.Forms.TextBox CreatedAtTextBox;
        private System.Windows.Forms.Label ProblemLabel;
        private System.Windows.Forms.TextBox ProblemTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CloseButton;
    }
}
