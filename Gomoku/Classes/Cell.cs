using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku.Classes
{

    public enum ObjectInCell
    {
        Red,Blue,Nothing
    }
    public enum CellState
    {
        Opened, Closed
    }

    class Cell:Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public Board Board { get; set; }
        public CellState CellState{ get; set; }

        public ObjectInCell inCell { get; set; }
        

        public void SetupDesign()
        {
            //this.BackColor = SystemColors.ButtonFace;
            this.Location = new Point(XLoc * CellSize, YLoc * CellSize);
            this.Size = new Size(CellSize, CellSize);
            this.UseVisualStyleBackColor = false;
            this.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
            this.CellState = CellState.Closed;
            this.inCell = ObjectInCell.Nothing;
            
        }

        public void OnClick(int turn)
        {
            this.CellState = CellState.Opened;
            //blue
            if(turn == 0)
            {
                this.inCell = ObjectInCell.Blue;
                this.BackColor= ColorTranslator.FromHtml("0x0000FF"); 
            }
            //red
            else
            {
                this.inCell = ObjectInCell.Red;
                this.BackColor = ColorTranslator.FromHtml("0xFF0000");
            }
            
        }

        
    }
}
