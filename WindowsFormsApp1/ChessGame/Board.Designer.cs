using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessGame
{
    partial class Piece
    {
        string name;
    }

    partial class Case : Form
    {
        public Case(int i , int j)
        {
            row = i;
            column = j;
            piece = null;

        }

        public int row;
        public int column;
        public Rectangle rectangle;
        public Piece piece;
    }

    partial class Board
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();

            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            this.Size = new Size(800, 800);
            this.WindowState = FormWindowState.Normal;

            this.Text = "Board";
            this.Paint += PaintBoard;
            this.Click += Board_Click;
            cases = new Case[length, length];
            for (int i = 0; i < length; ++i) // rows
            {
                for (int j = 0; j < length; ++j) // column
                {
                    cases[i, j] = new Case(i, j);
                    Case slot = cases[i, j];
                    slot.Location = new Point(i * 100 , j * 100);
                    slot.Width = 100;
                    slot.Height = 100;

                    Rectangle rec = new Rectangle(slot.row * 100, slot.column * 100, 100, 100);
                    slot.rectangle = rec;

                    slot.Paint += Slot_Paint;
                    slot.MouseClick += Slot_Click;

                }
            }
            ResumeLayout(false);
            PerformLayout();
        }

        private void Board_Click(object sender, EventArgs e)
        {
            Board board = (Board)sender;
            int colPosition = (MousePosition.X - this.Location.X)/100;
            int rowPosition = (MousePosition.Y - this.Location.Y)/100;

            if( (0 <= colPosition && colPosition < length) && (0 <= rowPosition && rowPosition < length))
                Slot_Click(cases[rowPosition, colPosition], e);

        }

        private void Slot_Paint(object sender, PaintEventArgs e)
        {
            Case slot = (Case)sender;

            Brush whiteBrush = new SolidBrush(Color.White);
            Brush brownBrush = new SolidBrush(Color.SaddleBrown);

            if ( (slot.row % 2 == 0 && slot.column % 2 == 0) || (slot.row % 2 == 1 && slot.column % 2 == 1))
            {
                e.Graphics.FillRectangle(brownBrush, slot.rectangle);
            }
            else
            {
                e.Graphics.FillRectangle(whiteBrush, slot.rectangle);
            }
        }

        private void Slot_Click(object sender, EventArgs e)
        {
            Case slot = (Case)(sender);
            MessageBox.Show("Position ligne " + slot.row + "colonne" + slot.column);
        }

        private void PaintBoard(object sender, PaintEventArgs e)
        {

            for (int i = 0; i < length; ++i) // rows
            {
                for (int j = 0; j < length; ++j) // column
                {
                    Slot_Paint(cases[i, j], e);
                }
            }
        }

        private static Case[,] cases;
        private static int length = 8;
    }
}

