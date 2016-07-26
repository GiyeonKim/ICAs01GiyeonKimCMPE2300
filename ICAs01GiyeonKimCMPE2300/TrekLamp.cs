using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace ICAs01GiyeonKimCMPE2300
{
    class TrekLamp
    {
        private Color _LampColor; //Type of color
        private byte _toggle;//type of toggle turn on or off
        private byte _byTick =0; // type of ticks which iterates over the allowed byte range
        private int _border; //type of int



        public TrekLamp(byte toggle, Color ColorofLamp, int Border =2) 
        {
            //default parametter of 2 for border argument
            //In the body, initialize their respective corresponding member values
            //byte[] rand = new byte[1];
            _border = Border; 
            _toggle = toggle;
            
            Random random = new Random(); //making new random generator
             
            _byTick = (byte)random.Next(byte.MaxValue+1);//assign _bytick to start at a random
            _LampColor = ColorofLamp;//random generage color

       
        }

        public TrekLamp() : this(64, RandColor.GetColor(),6)
        {
            // private TrekLamp() : this(64) //child of drives from whatever what's after the colon
            //  {
            //add a default constructor, using leverage your custom constructor with a 
            //threshold value of 64
            //  }
        }
       
        public void Tick()
        {

            _byTick += 3;
            // increment tick by 3

        }

        public void RenderLamp(CDrawer Drawing, int values)
        {
            

            if (values <= 180 && _byTick > _toggle)
            {
                int Col = values % 18; // it's 18 x 10 not 16 x 12
                int row = values / 18;
                Drawing.AddRectangle(Col, row, 1 /*Drawing.Scale*/, 1/*Drawing.Scale*/, _LampColor, _border, Color.Black);
            }
                    
            
            
        }

    }
}



