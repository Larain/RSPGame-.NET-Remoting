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
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btEnterName
            // 
            this.btEnterName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btEnterName.Location = new System.Drawing.Point(12, 235);
            this.btEnterName.Name = "btEnterName";
            this.btEnterName.Size = new System.Drawing.Size(350, 40);
            this.btEnterName.TabIndex = 1;
            this.btEnterName.Text = "Ввести имя";
            this.btEnterName.UseVisualStyleBackColor = true;
            this.btEnterName.Click += new System.EventHandler(this.btEnterName_Click);
            // 
            // btChoose
            // 
            this.btChoose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btChoose.Location = new System.Drawing.Point(12, 284);
            this.btChoose.Name = "btChoose";
            this.btChoose.Size = new System.Drawing.Size(350, 40);
            this.btChoose.TabIndex = 2;
            this.btChoose.Text = "Выбрать фигуру";
            this.btChoose.UseVisualStyleBackColor = true;
            this.btChoose.Click += new System.EventHandler(this.btChoose_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запуститьСерверToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // запуститьСерверToolStripMenuItem
            // 
            this.запуститьСерверToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ввестиПортToolStripMenuItem,
            this.запуститьСерверToolStripMenuItem1});
            this.запуститьСерверToolStripMenuItem.Name = "запуститьСерверToolStripMenuItem";
            this.запуститьСерверToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.запуститьСерверToolStripMenuItem.Text = "Настройки";
            // 
            // ввестиПортToolStripMenuItem
            // 
            this.ввестиПортToolStripMenuItem.Name = "ввестиПортToolStripMenuItem";
            this.ввестиПортToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.ввестиПортToolStripMenuItem.Text = "Подключиться к серверу";
            this.ввестиПортToolStripMenuItem.Click += new System.EventHandler(this.ввестиПортToolStripMenuItem_Click);
            // 
            // запуститьСерверToolStripMenuItem1
            // 
            this.запуститьСерверToolStripMenuItem1.Name = "запуститьСерверToolStripMenuItem1";
            this.запуститьСерверToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.запуститьСерверToolStripMenuItem1.Text = "Запустить сервер";
            this.запуститьСерверToolStripMenuItem1.Click += new System.EventHandler(this.запуститьСерверToolStripMenuItem1_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(374, 333);
            this.Controls.Add(this.btChoose);
            this.Controls.Add(this.btEnterName);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
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
    }
}

