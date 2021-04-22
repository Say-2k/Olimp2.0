
namespace Olimp2._0
{
    partial class uprav
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
            this.выселениеКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОПостоянныхКлиентахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётОбИностранныхКлиентахToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выселениеКлиентовToolStripMenuItem,
            this.отчётОПостоянныхКлиентахToolStripMenuItem,
            this.отчётОбИностранныхКлиентахToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(591, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выселениеКлиентовToolStripMenuItem
            // 
            this.выселениеКлиентовToolStripMenuItem.Name = "выселениеКлиентовToolStripMenuItem";
            this.выселениеКлиентовToolStripMenuItem.Size = new System.Drawing.Size(134, 20);
            this.выселениеКлиентовToolStripMenuItem.Text = "Выселение клиентов";
            this.выселениеКлиентовToolStripMenuItem.Click += new System.EventHandler(this.выселениеКлиентовToolStripMenuItem_Click);
            // 
            // отчётОПостоянныхКлиентахToolStripMenuItem
            // 
            this.отчётОПостоянныхКлиентахToolStripMenuItem.Name = "отчётОПостоянныхКлиентахToolStripMenuItem";
            this.отчётОПостоянныхКлиентахToolStripMenuItem.Size = new System.Drawing.Size(184, 20);
            this.отчётОПостоянныхКлиентахToolStripMenuItem.Text = "Отчёт о постоянных клиентах";
            this.отчётОПостоянныхКлиентахToolStripMenuItem.Click += new System.EventHandler(this.отчётОПостоянныхКлиентахToolStripMenuItem_Click);
            // 
            // отчётОбИностранныхКлиентахToolStripMenuItem
            // 
            this.отчётОбИностранныхКлиентахToolStripMenuItem.Name = "отчётОбИностранныхКлиентахToolStripMenuItem";
            this.отчётОбИностранныхКлиентахToolStripMenuItem.Size = new System.Drawing.Size(198, 20);
            this.отчётОбИностранныхКлиентахToolStripMenuItem.Text = "Отчёт об иностранных клиентах";
            this.отчётОбИностранныхКлиентахToolStripMenuItem.Click += new System.EventHandler(this.отчётОбИностранныхКлиентахToolStripMenuItem_Click);
            // 
            // uprav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 96);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "uprav";
            this.Text = "Управляющий";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выселениеКлиентовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОПостоянныхКлиентахToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётОбИностранныхКлиентахToolStripMenuItem;
    }
}