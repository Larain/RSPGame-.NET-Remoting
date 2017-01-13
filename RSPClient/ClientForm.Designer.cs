namespace RSPClient
{
    partial class ClientForm
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
            this.btEnterName = new System.Windows.Forms.Button();
            this.btChoose = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.запуститьСерверToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ввестиПортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запуститьСерверToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rtbServerOutput = new System.Windows.Forms.RichTextBox();
            this.closeClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEnterName
            // 
            this.btEnterName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEnterName.Location = new System.Drawing.Point(18, 362);
            this.btEnterName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btEnterName.Name = "btEnterName";
            this.btEnterName.Size = new System.Drawing.Size(525, 62);
            this.btEnterName.TabIndex = 1;
            this.btEnterName.Text = "Ввести имя";
            this.btEnterName.UseVisualStyleBackColor = true;
            this.btEnterName.Click += new System.EventHandler(this.btEnterName_Click);
            // 
            // btChoose
            // 
            this.btChoose.BackColor = System.Drawing.SystemColors.Control;
            this.btChoose.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btChoose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btChoose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChoose.ForeColor = System.Drawing.SystemColors.InfoText;
            this.btChoose.Location = new System.Drawing.Point(18, 437);
            this.btChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(525, 62);
            this.btChoose.TabIndex = 2;
            this.btChoose.Text = "Выбрать фигуру";
            this.btChoose.UseVisualStyleBackColor = false;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запуститьСерверToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(561, 35);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // запуститьСерверToolStripMenuItem
            // 
            this.запуститьСерверToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ввестиПортToolStripMenuItem,
            this.запуститьСерверToolStripMenuItem1,
            this.closeClientsToolStripMenuItem});
            this.запуститьСерверToolStripMenuItem.Name = "запуститьСерверToolStripMenuItem";
            this.запуститьСерверToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.запуститьСерверToolStripMenuItem.Text = "Настройки";
            // 
            // ввестиПортToolStripMenuItem
            // 
            this.ввестиПортToolStripMenuItem.Name = "ввестиПортToolStripMenuItem";
            this.ввестиПортToolStripMenuItem.Size = new System.Drawing.Size(303, 30);
            this.ввестиПортToolStripMenuItem.Text = "Подключиться к серверу";
            this.ввестиПортToolStripMenuItem.Click += new System.EventHandler(this.ввестиПортToolStripMenuItem_Click);
            // 
            // запуститьСерверToolStripMenuItem1
            // 
            this.запуститьСерверToolStripMenuItem1.Name = "запуститьСерверToolStripMenuItem1";
            this.запуститьСерверToolStripMenuItem1.Size = new System.Drawing.Size(303, 30);
            this.запуститьСерверToolStripMenuItem1.Text = "Запустить сервер";
            this.запуститьСерверToolStripMenuItem1.Click += new System.EventHandler(this.запуститьСерверToolStripMenuItem1_Click);
            // 
            // rtbServerOutput
            // 
            this.rtbServerOutput.BackColor = System.Drawing.SystemColors.MenuText;
            this.rtbServerOutput.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbServerOutput.Location = new System.Drawing.Point(0, 32);
            this.rtbServerOutput.Name = "rtbServerOutput";
            this.rtbServerOutput.Size = new System.Drawing.Size(561, 481);
            this.rtbServerOutput.TabIndex = 4;
            this.rtbServerOutput.Text = "";
            this.rtbServerOutput.Visible = false;
            // 
            // closeClientsToolStripMenuItem
            // 
            this.closeClientsToolStripMenuItem.Name = "closeClientsToolStripMenuItem";
            this.closeClientsToolStripMenuItem.Size = new System.Drawing.Size(303, 30);
            this.closeClientsToolStripMenuItem.Text = "Close Clients";
            this.closeClientsToolStripMenuItem.Click += new System.EventHandler(this.closeClientsToolStripMenuItem_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(561, 512);
            this.Controls.Add(this.rtbServerOutput);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.btEnterName);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ClientForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEnterName;
        private System.Windows.Forms.Button btChoose;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem запуститьСерверToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ввестиПортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запуститьСерверToolStripMenuItem1;
        private System.Windows.Forms.RichTextBox rtbServerOutput;
        private System.Windows.Forms.ToolStripMenuItem closeClientsToolStripMenuItem;
    }
}

