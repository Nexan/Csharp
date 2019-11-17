namespace WF_GuessNumber
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
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCaption = new System.Windows.Forms.Label();
            this.lblUserAnswer = new System.Windows.Forms.Label();
            this.textUserAnswer = new System.Windows.Forms.TextBox();
            this.lblStepsCount = new System.Windows.Forms.Label();
            this.panelPlay = new System.Windows.Forms.Panel();
            this.lblCurrentResult = new System.Windows.Forms.Label();
            this.mainMenu.SuspendLayout();
            this.panelPlay.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemPlay});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(288, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // menuItemPlay
            // 
            this.menuItemPlay.Name = "menuItemPlay";
            this.menuItemPlay.Size = new System.Drawing.Size(57, 20);
            this.menuItemPlay.Text = "Играть";
            this.menuItemPlay.Click += new System.EventHandler(this.menuItemPlay_Click);
            // 
            // lblCaption
            // 
            this.lblCaption.AutoSize = true;
            this.lblCaption.Location = new System.Drawing.Point(8, 14);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(259, 13);
            this.lblCaption.TabIndex = 1;
            this.lblCaption.Text = "Попробуйте угадать число от 1 до 100 за 6 ходов.";
            // 
            // lblUserAnswer
            // 
            this.lblUserAnswer.AutoSize = true;
            this.lblUserAnswer.Location = new System.Drawing.Point(8, 52);
            this.lblUserAnswer.Name = "lblUserAnswer";
            this.lblUserAnswer.Size = new System.Drawing.Size(75, 13);
            this.lblUserAnswer.TabIndex = 2;
            this.lblUserAnswer.Text = "Ваш вариант:";
            // 
            // textUserAnswer
            // 
            this.textUserAnswer.Location = new System.Drawing.Point(87, 49);
            this.textUserAnswer.MaxLength = 3;
            this.textUserAnswer.Name = "textUserAnswer";
            this.textUserAnswer.Size = new System.Drawing.Size(100, 20);
            this.textUserAnswer.TabIndex = 3;
            this.textUserAnswer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textUserAnswer_KeyUp);
            // 
            // lblStepsCount
            // 
            this.lblStepsCount.AutoSize = true;
            this.lblStepsCount.Location = new System.Drawing.Point(8, 91);
            this.lblStepsCount.Name = "lblStepsCount";
            this.lblStepsCount.Size = new System.Drawing.Size(203, 13);
            this.lblStepsCount.TabIndex = 4;
            this.lblStepsCount.Text = "Количество использованных попыток:";
            // 
            // panelPlay
            // 
            this.panelPlay.Controls.Add(this.lblCurrentResult);
            this.panelPlay.Controls.Add(this.lblCaption);
            this.panelPlay.Controls.Add(this.lblStepsCount);
            this.panelPlay.Controls.Add(this.lblUserAnswer);
            this.panelPlay.Controls.Add(this.textUserAnswer);
            this.panelPlay.Location = new System.Drawing.Point(5, 27);
            this.panelPlay.Name = "panelPlay";
            this.panelPlay.Size = new System.Drawing.Size(279, 150);
            this.panelPlay.TabIndex = 5;
            // 
            // lblCurrentResult
            // 
            this.lblCurrentResult.AutoSize = true;
            this.lblCurrentResult.Location = new System.Drawing.Point(16, 118);
            this.lblCurrentResult.Name = "lblCurrentResult";
            this.lblCurrentResult.Size = new System.Drawing.Size(0, 13);
            this.lblCurrentResult.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 181);
            this.Controls.Add(this.panelPlay);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Угадай число";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panelPlay.ResumeLayout(false);
            this.panelPlay.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem menuItemPlay;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.Label lblUserAnswer;
        private System.Windows.Forms.TextBox textUserAnswer;
        private System.Windows.Forms.Label lblStepsCount;
        private System.Windows.Forms.Panel panelPlay;
        private System.Windows.Forms.Label lblCurrentResult;
    }
}

