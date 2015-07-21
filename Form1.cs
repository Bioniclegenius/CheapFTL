using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapFTL {
  public partial class Form1:Form {
    public drawingpanel p;
    public string savefilepath="\\Ships";
    public Form1() {
      InitializeComponent();
    }
    private void Form1_Load(object sender,EventArgs e) {
      int scrWidth=1200,scrHeight=900;
      this.ClientSize=new Size(scrWidth,scrHeight+menu.Height);
      p=new drawingpanel(scrWidth,scrHeight);
      p.Location=new Point(0,menu.Height);
      this.Controls.Add(p);
    }
    private void saveShipToolStripMenuItem_Click(object sender,EventArgs e) {
      string[] lines= { p.pl.ToString() };
      SaveFileDialog sfd=new SaveFileDialog();
      sfd.InitialDirectory=Environment.CurrentDirectory+savefilepath;
      sfd.Filter="Ship files (*.shp)|*.shp";
      sfd.FilterIndex=1;
      sfd.RestoreDirectory=true;
      if(sfd.ShowDialog()==DialogResult.OK) {
        try {
          string path=sfd.FileName;
          File.WriteAllLines(path,lines);
        }
        catch(Exception E) {
          MessageBox.Show(E.ToString(),"Error",MessageBoxButtons.OK);
        }
      }
    }

    private void openShipToolStripMenuItem_Click(object sender,EventArgs e) {
      OpenFileDialog ofd=new OpenFileDialog();
      ofd.InitialDirectory=Environment.CurrentDirectory+savefilepath;
      ofd.Filter="Ship files (*.shp)|*.shp";
      ofd.FilterIndex=1;
      ofd.RestoreDirectory=true;
      if(ofd.ShowDialog()==DialogResult.OK) {
        try {
          string filename=ofd.FileName;
          string line=File.ReadAllLines(filename)[0];
          p.pl=PlayerShip.BackToObj(line);
        }
        catch(Exception E) {
          MessageBox.Show(E.ToString(),"Error",MessageBoxButtons.OK);
        }
      }
    }
  }
}
