namespace WF_Udvoitel
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
            this.btnCommand1 = new System.Windows.Forms.Button();
            this.btnCommand2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblNumber = new System.Windows.Forms.Label();
            this.captionGuessNumber = new System.Windows.Forms.Label();
            this.captionNumber = new System.Windows.Forms.Label();
            this.captionActionsCount = new System.Windows.Forms.Label();
            this.lblActionsCount = new System.Windows.Forms.Label();
            this.menuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.btnCancelLastStep = new System.Windows.Forms.Button();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCommand1
            // 
            this.btnCommand1.Location = new System.Drawing.Point(306, 44);
            this.btnCommand1.Name = "btnCommand1";
            this.btnCommand1.Size = new System.Drawing.Size(75, 23);
            this.btnCommand1.TabIndex = 0;
            this.btnCommand1.Text = "+1";
            this.btnCommand1.UseVisualStyleBackColor = true;
            this.btnCommand1.Click += new System.EventHandler(this.btnCommand1_Click);
            // 
            // btnCommand2
            // 
            this.btnCommand2.Location = new System.Drawing.Point(306, 73);
            this.btnCommand2.Name = "btnCommand2";
            this.btnCommand2.Size = new System.Drawing.Size(75, 23);
            this.btnCommand2.TabIndex = 1;
            this.btnCommand2.Text = "x2";
            this.btnCommand2.UseVisualStyleBackColor = true;
            this.btnCommand2.Click += new System.EventHandler(this.btnCommand2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(306, 115);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Сброс";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblNumber.Location = new System.Drawing.Point(151, 95);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(26, 29);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "1";
            // 
            // captionGuessNumber
            // 
            this.captionGuessNumber.AutoSize = true;
            this.captionGuessNumber.Location = new System.Drawing.Point(20, 44);
            this.captionGuessNumber.Name = "captionGuessNumber";
            this.captionGuessNumber.Size = new System.Drawing.Size(86, 13);
            this.captionGuessNumber.TabIndex = 5;
            this.captionGuessNumber.Text = "Получите число";
            // 
            // captionNumber
            // 
            this.captionNumber.AutoSize = true;
            this.captionNumber.Location = new System.Drawing.Point(20, 73);
            this.captionNumber.Name = "captionNumber";
            this.captionNumber.Size = new System.Drawing.Size(133, 13);
            this.captionNumber.TabIndex = 7;
            this.captionNumber.Text = "Ваше текущее значение:";
            // 
            // captionActionsCount
            // 
            this.captionActionsCount.AutoSize = true;
            this.captionActionsCount.Location = new System.Drawing.Point(20, 145);
            this.captionActionsCount.Name = "captionActionsCount";
            this.captionActionsCount.Size = new System.Drawing.Size(135, 13);
            this.captionActionsCount.TabIndex = 8;
            this.captionActionsCount.Text = "Количество ваших ходов:";
            // 
            // lblActionsCount
            // 
            this.lblActionsCount.AutoSize = true;
            this.lblActionsCount.Location = new System.Drawing.Point(158, 145);
            this.lblActionsCount.Name = "lblActionsCount";
            this.lblActionsCount.Size = new System.Drawing.Size(13, 13);
            this.lblActionsCount.TabIndex = 9;
            this.lblActionsCount.Text = "0";
            // 
            // menuItemPlay
            // 
            this.menuItemPlay.Name = "menuItemPlay";
            this.menuItemPlay.Size = new System.Drawing.Size(57, 20);
            this.menuItemPlay.Text = "Играть";
            this.menuItemPlay.Click += new System.EventHandler(this.menuItemPlay_Click);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPlay});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(405, 24);
            this.MainMenu.TabIndex = 4;
            this.MainMenu.Text = "Отменить";
            // 
            // btnCancelLastStep
            // 
            this.btnCancelLastStep.Location = new System.Drawing.Point(306, 156);
            this.btnCancelLastStep.Name = "btnCancelLastStep";
            this.btnCancelLastStep.Size = new System.Drawing.Size(75, 23);
            this.btnCancelLastStep.TabIndex = 10;
            this.btnCancelLastStep.Text = "Отменить";
            this.btnCancelLastStep.UseVisualStyleBackColor = true;
            this.btnCancelLastStep.Click += new System.EventHandler(this.btnCancelLastStep_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 194);
            this.Controls.Add(this.btnCancelLastStep);
            this.Controls.Add(this.lblActionsCount);
            this.Controls.Add(this.captionActionsCount);
            this.Controls.Add(this.captionNumber);
            this.Controls.Add(this.captionGuessNumber);
            this.Controls.Add(this.lblNumber);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCommand2);
            this.Controls.Add(this.btnCommand1);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Удвоитель";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCommand1;
        private System.Windows.Forms.Button btnCommand2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label captionGuessNumber;
        private System.Windows.Forms.Label captionNumber;
        private System.Windows.Forms.Label captionActionsCount;
        private System.Windows.Forms.Label lblActionsCount;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlay;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.Button btnCancelLastStep;
    }
}

