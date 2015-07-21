﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheapFTL {
  public class Room {
    public int x,y,type;
    public int[] walls;
    public static int size=35;
    public Room() {
      walls=new int[4];
      for(int x=0;x<4;x++)
        walls[x]=1;
    }
    public Room(int xi,int yi,int typei=0) {
      x=xi;
      y=yi;
      type=typei;
      walls=new int[4];
      for(int z=0;z<4;z++)
        walls[z]=1;
    }
    public void render(Graphics g,SolidBrush b,int cx,int cy,int mx,int my,bool click) {
      int dx=x*size;
      int dy=y*size;
      b.Color=Color.FromArgb(255,255,255);
      g.FillRectangle(b,cx+dx,cy+dy,size,size);
      switch(type){
        case 1:
          b.Color=Color.FromArgb(127,127,127);
          g.FillRectangle(b,cx+dx,cy+dy,size,size);
          break;
        default:
          break;
      }
      b.Color=Color.FromArgb(0,0,0);
      int[] dispwalls=new int[4];
      for(int z=0;z<4;z++)
        dispwalls[z]=walls[z];
      if(type!=1) {
        if(mx>=cx+dx-4&&mx<=cx+dx+4&&my>=cy+dy+2&&my<=cy+dy+size-2)//0
          dispwalls[0]=(dispwalls[0]+1)%3;
        if(mx>=cx+dx+2&&mx<=cx+dx+size-2&&my>=cy+dy-4&&my<=cy+dy+4)//1
          dispwalls[1]=(dispwalls[1]+1)%3;
        if(mx>=cx+dx+size-4&&mx<=cx+dx+size+4&&my>=cy+dy+2&&my<=cy+dy+size-2)//2
          dispwalls[2]=(dispwalls[2]+1)%3;
        if(mx>=cx+dx+2&&mx<=cx+dx+size-2&&my>=cy+dy+size-4&&my<=cy+dy+size+4)//3
          dispwalls[3]=(dispwalls[3]+1)%3;
      }
      if(dispwalls[0]>0) 
        g.FillRectangle(b,cx+dx,cy+dy,2,size);
      if(dispwalls[0]==2) {
        b.Color=Color.FromArgb(0,0,0);
        g.FillRectangle(b,cx+dx-3,cy+dy+7,6,size-14);
        b.Color=Color.FromArgb(127,127,127);
        g.FillRectangle(b,cx+dx-2,cy+dy+8,4,size-16);
        b.Color=Color.FromArgb(0,0,0);
      }
      if(dispwalls[1]>0)
        g.FillRectangle(b,cx+dx,cy+dy,size,2);
      if(dispwalls[1]==2) {
        b.Color=Color.FromArgb(0,0,0);
        g.FillRectangle(b,cx+dx+7,cy+dy-3,size-14,6);
        b.Color=Color.FromArgb(127,127,127);
        g.FillRectangle(b,cx+dx+8,cy+dy-2,size-16,4);
        b.Color=Color.FromArgb(0,0,0);
      }
      if(dispwalls[2]>0)
        g.FillRectangle(b,cx+dx+size-2,cy+dy,2,size);
      if(dispwalls[2]==2) {
        b.Color=Color.FromArgb(0,0,0);
        g.FillRectangle(b,cx+dx+size-3,cy+dy+7,6,size-14);
        b.Color=Color.FromArgb(127,127,127);
        g.FillRectangle(b,cx+dx+size-2,cy+dy+8,4,size-16);
        b.Color=Color.FromArgb(0,0,0);
      }
      if(dispwalls[3]>0)
        g.FillRectangle(b,cx+dx,cy+dy+size-2,size,2);
      if(dispwalls[3]==2) {
        b.Color=Color.FromArgb(0,0,0);
        g.FillRectangle(b,cx+dx+7,cy+dy+size-3,size-14,6);
        b.Color=Color.FromArgb(127,127,127);
        g.FillRectangle(b,cx+dx+8,cy+dy+size-2,size-16,4);
        b.Color=Color.FromArgb(0,0,0);
      }
      if(click)
        for(int z=0;z<4;z++)
          walls[z]=dispwalls[z];
    }
    public string ToString() {
      string obj="";
      obj+=Convert.ToString(x)+" "+Convert.ToString(y)+" "+Convert.ToString(type)+" ";
      obj+=Convert.ToString(walls[0])+" ";
      obj+=Convert.ToString(walls[1])+" ";
      obj+=Convert.ToString(walls[2])+" ";
      obj+=Convert.ToString(walls[3])+" ";
      return obj;
    }
    public static Room BackToObj(string input) {
      Room r=new Room(0,0,0);
      string[] values=input.Split(' ');
      r.x=Convert.ToInt32(values[0]);
      r.y=Convert.ToInt32(values[1]);
      r.type=Convert.ToInt32(values[2]);
      r.walls[0]=Convert.ToInt32(values[3]);
      r.walls[1]=Convert.ToInt32(values[4]);
      r.walls[2]=Convert.ToInt32(values[5]);
      r.walls[3]=Convert.ToInt32(values[6]);
      return r;
    }
  }
}
