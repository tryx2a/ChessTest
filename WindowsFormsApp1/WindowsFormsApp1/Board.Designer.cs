using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class Pieces : Form
    {
        public Pieces()
        {
            tabPieces = new Piece[8, 8];
        }

        public Piece[,] tabPieces;
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
            //board = new System.Windows.Forms.TableLayoutPanel();
            pieces = new Pieces();
            SuspendLayout();
            //board.ColumnCount = board.RowCount = 8;
            /*int widthPiece = (int)(600 * 0.125);
            int heightPiece = widthPiece;

            for (int i = 0; i < board.RowCount; ++i)
            {
                board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
                for(int j = 0; j < board.ColumnCount; ++j)
                {
                    board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
                }
            }*/
            //Controls.Add(this.pieces);
            ResumeLayout(false);
            PerformLayout();
        }


        //private System.Windows.Forms.TableLayoutPanel board;
        private Pieces pieces;
    }
}

