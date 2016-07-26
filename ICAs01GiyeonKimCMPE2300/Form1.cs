using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GDIDrawer;

namespace ICAs01GiyeonKimCMPE2300
{
    public partial class Form1 : Form
    {
        CDrawer Drawing = new CDrawer(900, 500);
        Random RandomNum = new Random();
        

        List<TrekLamp> Mylist = new List<TrekLamp>();
        
        public Form1()
        {
            InitializeComponent();
            Drawing.ContinuousUpdate = false;
            Drawing.Scale = 50; 
            timer1.Enabled = true; // don't stop the timer
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1 && Mylist.Count < 180)
            {
                
                Mylist.Add(new TrekLamp()); // set it as default
            }

            if(e.KeyCode == Keys.F2 && Mylist.Count < 180)
            {
                Mylist.Add(new TrekLamp(180,Color.Orange,4)); 
            }
            if(e.KeyCode == Keys.F3 && Mylist.Count < 180)
            {
                Mylist.Add(new TrekLamp((byte)RandomNum.Next(60,220), RandColor.GetColor(), 4));
            }
            if(e.KeyCode == Keys.Escape && Mylist.Count > 0)
            {
                Mylist.RemoveAt(Mylist.Count -1);  
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Drawing.Clear(); // clear the CDrawer first
            for (int i =0; i < Mylist.Count; i++ ) // list
            {
                Mylist[i].Tick();
                Mylist[i].RenderLamp(Drawing, i);
               
            }
            Drawing.Render();

        }
    }
}
