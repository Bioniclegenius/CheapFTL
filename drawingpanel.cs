using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheapFTL {
  public class drawingpanel:Panel {
    public PlayerShip pl;
    int mx,my;
    bool clicked=false;
    bool clicked2=false;
    bool click=false;
    bool click2=false;
    public drawingpanel(int scrWidth,int scrHeight) {
      this.Width=scrWidth;
      this.Height=scrHeight;
      this.Location=new Point(0,0);
      this.DoubleBuffered=true;
      this.Paint+=new System.Windows.Forms.PaintEventHandler(this.PaintEvent);
      this.MouseMove+=new System.Windows.Forms.MouseEventHandler(this.MouseMoveEvent);
      this.MouseDown+=new System.Windows.Forms.MouseEventHandler(this.MouseDownEvent);
      this.MouseUp+=new System.Windows.Forms.MouseEventHandler(this.MouseUpEvent);
      pl=new PlayerShip();
      Invalidate();
      mx=0;
      my=0;
    }
    private void PaintEvent(object sender,PaintEventArgs e) {
      Graphics g=e.Graphics;
      SolidBrush b=new SolidBrush(Color.FromArgb(0,0,0));
      g.FillRectangle(b,0,0,this.Width,this.Height);
      pl.render(g,b,60*this.Width/100,this.Height,mx,my,click,click2);
      if(click) {
        clicked=true;
        click=false;
      }
      if(click2) {
        clicked2=true;
        click2=false;
      }
      Invalidate();
    }
    private void MouseMoveEvent(object sender,MouseEventArgs e) {
      mx=e.X;
      my=e.Y;
    }
    private void MouseDownEvent(object sender,MouseEventArgs e) {
      if(e.Button==MouseButtons.Left&&!clicked)
        click=true;
      if(e.Button==MouseButtons.Right&&!clicked2)
        click2=true;
    }
    private void MouseUpEvent(object sender,MouseEventArgs e) {
      if(e.Button==MouseButtons.Left) {
        click=false;
        clicked=false;
      }
      if(e.Button==MouseButtons.Right) {
        click2=false;
        clicked2=false;
      }
    }
  }
}
