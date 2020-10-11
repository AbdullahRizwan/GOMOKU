using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gomoku.Classes
{
    class Board
    {
        public Gomoku gomoku { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Cell[,] Cells { get; set; }

        public int turn;

        public Board(Gomoku p, int width, int height)
        {
            this.gomoku = p;
            this.Width = width;
            this.Height = height;
            this.Cells = new Cell[width, height];
            this.turn = 0;
        }

        public void SetupBoard()
        {
            for (var x = 1; x <= Width; x++)
            {
                for (var y = 1; y <= Height; y++)
                {
                    var c = new Cell
                    {
                        XLoc = x - 1,
                        YLoc = y - 1,
                        CellSize = 30,
                        Board = this
                    };
                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;
                    this.Cells[x - 1, y - 1] = c;
                    this.gomoku.Controls.Add(c);
                }
            }
        }
        public int CheckForWin() {
            int bxpath = 0;
            int bypath = 0;
            int bdiagonalPath = 0;
            int rxpath = 0;
            int rypath = 0;
            int rdiagonalPath = 0;
            for (int i=0; i<Height; i++)
            {
                for(int j=0; j<Width; j++)
                {
                    bxpath = 0;
                    bypath = 0;
                    bdiagonalPath = 0;
                    rxpath = 0;
                    rypath = 0;
                    rdiagonalPath = 0;

                    for (int k=0; k<5; k++)
                    {
                        if(i+k <Height)
                        if(Cells[i+k,j].inCell == ObjectInCell.Blue)
                        {
                            bxpath++;
                            
                            
                        }
                        if ( j + k < Width)
                        if (Cells[i , j + k].inCell == ObjectInCell.Blue)
                        {
                            
                            bypath++;
                            
                        }
                        if (i + k < Height && j+ k< Width)
                        if (Cells[i+k, j + k].inCell == ObjectInCell.Blue)
                        {
                            
                            bdiagonalPath++;
                        }
                        if (i + k < Height)
                        if (Cells[i + k, j].inCell == ObjectInCell.Red)
                        {
                            rxpath++;
                            

                        }
                        if ( j + k < Width)
                        if (Cells[i, j + k].inCell == ObjectInCell.Red)
                        {
                          
                            rypath++;
                          
                        }
                        if (i + k < Height && j + k < Width)
                        if (Cells[i + k, j + k].inCell == ObjectInCell.Red)
                        {
                           
                            rdiagonalPath++;
                        }
                    }
                    if (bxpath == 5 || bypath == 5 || bdiagonalPath == 5)
                        return 0;
                    if (rxpath == 5 || rypath == 5 || rdiagonalPath == 5)
                        return 1;

                }
            }

            


            return -1;
        }
        void changeTurn()
        {
            turn = 1 - turn;
        }

        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            //0 for blue 1 for red
            var cell = (Cell)sender;

            // Cell is already opened
            if (cell.CellState == CellState.Opened)
                return;

            
            cell.OnClick(turn);
            changeTurn();
            int winner = CheckForWin();
            string message="";
            if (winner == 0)
            {
                message = "Blue Player Won";
                
            }
            else if(winner == 1)
            {
               message = "Red Player Won";
                
            }
            message = message + "\nDo you want to exit?";
            if (winner != -1)
            {
                
                string title = "Winner";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    gomoku.Close();
                }
                else
                {
                    // Do something  
                }
            }
        }
    }
}
