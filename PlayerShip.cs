using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapFTL {
  public class PlayerShip {
    List<Room> rooms;
    public PlayerShip() {
      rooms=new List<Room>();
    }
    public void render(Graphics g,SolidBrush b,int scrWidth,int scrHeight,int mx,int my,bool click,bool click2) {
      b.Color=Color.FromArgb(31,31,31);
      g.FillRectangle(b,0,0,scrWidth,scrHeight);
      b.Color=Color.FromArgb(63,63,63);
      g.FillRectangle(b,0,0,scrWidth,4);
      g.FillRectangle(b,0,scrHeight-4,scrWidth,4);
      g.FillRectangle(b,0,0,4,scrHeight);
      g.FillRectangle(b,scrWidth-4,0,4,scrHeight);
      int roomx=mx;
      roomx-=(scrWidth/2)%Room.size;
      roomx-=roomx%Room.size;
      if(roomx>=scrWidth/2&&(scrWidth/2)%Room.size!=0)
        roomx+=Room.size;
      roomx-=scrWidth/2;
      int roomy=my;
      roomy-=(scrHeight/2)%Room.size;
      roomy-=roomy%Room.size;
      if(roomy>=scrHeight/2&&(scrHeight/2)%Room.size!=0)
        roomy+=Room.size;
      roomy-=scrHeight/2;
      if(mx<0)
        roomx*=-1;
      if(my<0)
        roomy*=-1;
      if(my>0)
        roomy++;
      bool found=false;
      for(int x=0;x<rooms.Count;x++)
        if(mx>=rooms[x].x*Room.size+scrWidth/2&&mx<=rooms[x].x*Room.size+scrWidth/2+Room.size&&
           my>=rooms[x].y*Room.size+scrHeight/2&&my<=rooms[x].y*Room.size+scrHeight/2+Room.size) {
          found=true;
          if(!click2)
            break;
          else {
            rooms.RemoveAt(x);
            x--;
          }
        }
      if(roomx+scrWidth/2<=4||roomx+scrWidth/2>=scrWidth-Room.size-4||
         roomy+scrHeight/2<=4||roomy+scrHeight/2>=scrHeight-Room.size-4)
        found=true;
      if(!found) {
        roomx/=Room.size;
        roomy/=Room.size;
        Room temp=new Room(roomx,roomy,1);
        temp.render(g,b,scrWidth/2,scrHeight/2,mx,my,click);
        if(click) {
          rooms.Add(new Room(roomx,roomy,0));
          rooms.Sort(Room.Compare);
          for(int x=0;x<rooms.Count-1;x++) {
            if(rooms[x].x==roomx-1&&rooms[x].y==roomy)
              rooms[rooms.Count-1].walls[0]=rooms[x].walls[2];
            if(rooms[x].x==roomx+1&&rooms[x].y==roomy)
              rooms[rooms.Count-1].walls[2]=rooms[x].walls[0];
            if(rooms[x].y==roomy-1&&rooms[x].x==roomx)
              rooms[rooms.Count-1].walls[1]=rooms[x].walls[3];
            if(rooms[x].y==roomy+1&&rooms[x].x==roomx)
              rooms[rooms.Count-1].walls[3]=rooms[x].walls[1];
          }
        }
      }
      for(int x=0;x<rooms.Count;x++) {
        if(rooms[x].walls[0]==0) {
          rooms[x].walls[0]=1;
          for(int y=0;y<rooms.Count;y++)
            if(rooms[y].x==rooms[x].x-1&&rooms[y].y==rooms[x].y) {
              rooms[x].walls[0]=0;
              break;
            }
        }
        if(rooms[x].walls[1]==0) {
          rooms[x].walls[1]=1;
          for(int y=0;y<rooms.Count;y++)
            if(rooms[y].x==rooms[x].x&&rooms[y].y==rooms[x].y-1) {
              rooms[x].walls[1]=0;
              break;
            }
        }
        if(rooms[x].walls[2]==0) {
          rooms[x].walls[2]=1;
          for(int y=0;y<rooms.Count;y++)
            if(rooms[y].x==rooms[x].x+1&&rooms[y].y==rooms[x].y) {
              rooms[x].walls[2]=0;
              break;
            }
        }
        if(rooms[x].walls[3]==0) {
          rooms[x].walls[3]=1;
          for(int y=0;y<rooms.Count;y++)
            if(rooms[y].x==rooms[x].x&&rooms[y].y==rooms[x].y+1) {
              rooms[x].walls[3]=0;
              break;
            }
        }
      }
      for(int x=0;x<rooms.Count;x++)
        rooms[x].render(g,b,scrWidth/2,scrHeight/2,mx,my,click);
    }
    public override string ToString() {
      string obj="";
      for(int x=0;x<rooms.Count;x++) {
        obj+=rooms[x].ToString();
        if(x!=rooms.Count-1)
          obj+="\r\n";
      }
      return obj;
    }
    public static PlayerShip BackToObj(string[] input) {
      PlayerShip p=new PlayerShip();
      for(int x=0;x<input.Length;x++)
        p.rooms.Add(Room.BackToObj(input[x]));
      p.rooms.Sort(Room.Compare);
      return p;
    }
  }
}
