namespace CheapFTL {
  partial class Form1 {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components=null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing&&(components!=null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.menu = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.openShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.saveShipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menu.SuspendLayout();
      this.SuspendLayout();
      // 
      // menu
      // 
      this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menu.Location = new System.Drawing.Point(0, 0);
      this.menu.Name = "menu";
      this.menu.Size = new System.Drawing.Size(282, 28);
      this.menu.TabIndex = 0;
      this.menu.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openShipToolStripMenuItem,
            this.saveShipToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // openShipToolStripMenuItem
      // 
      this.openShipToolStripMenuItem.Name = "openShipToolStripMenuItem";
      this.openShipToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
      this.openShipToolStripMenuItem.Text = "Open Ship";
      this.openShipToolStripMenuItem.Click += new System.EventHandler(this.openShipToolStripMenuItem_Click);
      // 
      // saveShipToolStripMenuItem
      // 
      this.saveShipToolStripMenuItem.Name = "saveShipToolStripMenuItem";
      this.saveShipToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
      this.saveShipToolStripMenuItem.Text = "Save Ship";
      this.saveShipToolStripMenuItem.Click += new System.EventHandler(this.saveShipToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(282, 255);
      this.Controls.Add(this.menu);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.MainMenuStrip = this.menu;
      this.Name = "Form1";
      this.Text = "Form1";
      this.Load += new System.EventHandler(this.Form1_Load);
      this.menu.ResumeLayout(false);
      this.menu.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menu;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem openShipToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem saveShipToolStripMenuItem;
  }
}

