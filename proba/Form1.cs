using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proba
{
    public partial class Form1 : Form
    {
        Tabla tabla;
        private Igra igra;
        private Rezultat rezultat;
        private const int boardWidth = 10;
        private const int boardHeight = 20;
        private const int cellSize = 20;
        public Form1()
        {
            InitializeComponent();
            igra = new Igra(boardWidth, boardHeight);
            Timer timer = new Timer();
            timer.Interval = 500;
            timer.Tick += timer1_Tick;
            timer.Start();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.ClientSize = new Size(200, 400);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    igra.MoveCurrentFigureLeft();
                    break;
                case Keys.Right:
                    igra.MoveCurrentFigureRight();
                    break;
                case Keys.Down:
                    igra.MoveCurrentFigureDown();
                    break;
                case Keys.Up:
                    igra.RotateCurrentFigure();
                    break;
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            igra.MoveCurrentFigureDown();
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int[,] board = igra.GetBoardState();
            for (int x = 0; x < boardHeight; x++)
            {
                for (int y = 0; y < boardWidth; y++)
                {
                    if (board[x, y] != 0)
                    {
                        e.Graphics.FillRectangle(Brushes.Blue, y * cellSize, x * cellSize, cellSize, cellSize);
                        e.Graphics.DrawRectangle(Pens.Black, y * cellSize, x * cellSize, cellSize, cellSize);
                    }
                }
            }

            if (igra.CurrentFigura != null)
            {
                var shape = igra.CurrentFigura.Shape;
                var color = igra.CurrentFigura.Color;
                for (int x = 0; x < shape.GetLength(0); x++)
                {
                    for (int y = 0; y < shape.GetLength(1); y++)
                    {
                        if (shape[x, y] != 0)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(color), (igra.CurrentFigura.Y + y) * cellSize, (igra.CurrentFigura.X + x) * cellSize, cellSize, cellSize);
                            e.Graphics.DrawRectangle(Pens.Black, (igra.CurrentFigura.Y + y) * cellSize, (igra.CurrentFigura.X + x) * cellSize, cellSize, cellSize);
                        }
                    }
                }
            }
        }
    }
}
