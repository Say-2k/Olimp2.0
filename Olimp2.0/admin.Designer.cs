
namespace Olimp2._0
{
    partial class admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.регистрацияКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вселениеКлиентаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.регистрацияКлиентаToolStripMenuItem,
            this.вселениеКлиентаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(300, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // регистрацияКлиентаToolStripMenuItem
            // 
            this.регистрацияКлиентаToolStripMenuItem.Name = "регистрацияКлиентаToolStripMenuItem";
            this.регистрацияКлиентаToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.регистрацияКлиентаToolStripMenuItem.Text = "Регистрация клиента";
            this.регистрацияКлиентаToolStripMenuItem.Click += new System.EventHandler(this.регистрацияКлиентаToolStripMenuItem_Click);
            // 
            // вселениеКлиентаToolStripMenuItem
            // 
            this.вселениеКлиентаToolStripMenuItem.Name = "вселениеКлиентаToolStripMenuItem";
            this.вселениеКлиентаToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.вселениеКлиентаToolStripMenuItem.Text = "Вселение клиента";
            this.вселениеКлиентаToolStripMenuItem.Click += new System.EventHandler(this.вселениеКлиентаToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 122);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "admin";
            this.Text = "Администратор";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem регистрацияКлиентаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вселениеКлиентаToolStripMenuItem;
    }
}