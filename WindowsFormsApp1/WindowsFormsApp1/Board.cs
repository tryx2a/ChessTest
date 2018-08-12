using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Piece : Form
    {
        public Piece(int i, int j, System.Drawing.Rectangle rec)
        {
            row = i;
            column = j;
            rectangle = rec;
        }

        public Rectangle rectangle;
        public int row;
        public int column;
    }

    public partial class Board : Form
    {
        public Board()
        {
            InitializeComponent();
            this.Size = new Size(600, 600);
            
            /*PictureBox pb1 = new PictureBox();
            pb1.ImageLocation = "C:\\Users\\Yannick\\source\\repos\\WindowsFormsApp1\\WindowsFormsApp1\\pion.png";
            pb1.BackgroundImageLayout = ImageLayout.Center;
            this.board.Controls.Add(pb1, 1, 1);*/
        }

        private void board_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            SolidBrush brownBrush = new SolidBrush(Color.SaddleBrown);
            SolidBrush whiteBrush = new SolidBrush(Color.White);
            int widthPiece = (int)(600 * 0.125);
            int heightPiece = widthPiece;

            for (int i = 0; i < 8; ++i)
            {
                for(int j = 0; j < 8; ++j)
                {
                    pieces.tabPieces[i, j] = new Piece(i, j, new Rectangle(i * widthPiece, j * heightPiece, widthPiece, heightPiece));
                    pieces.tabPieces[i, j].Click += MovePiece;
                    if ( (i % 2 == 0 && j % 2 == 0) || (i % 2 == 1 && j % 2 == 1))
                    {
                       e.Graphics.FillRectangle(brownBrush, this.pieces.tabPieces[i, j].rectangle);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(whiteBrush, this.pieces.tabPieces[i, j].rectangle);
                    }
                }
            }
        }

        private void MovePiece(object sender, EventArgs e)
        {
            Piece p = (Piece)sender;
            System.Windows.Forms.MessageBox.Show("Current position : " + p.row + ";" + p.column);            
        }
    }
}
