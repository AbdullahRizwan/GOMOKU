using Gomoku.Classes;
using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gomoku
{
    public partial class Gomoku : Form {
        public Gomoku()
        {
            InitializeComponent();

            var board = new Board(this, 19, 19);
            board.SetupBoard();
            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Gomoku
            // 
            this.ClientSize = new System.Drawing.Size(572, 571);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Text = "Gomoku";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);

        }

        



    }
}
