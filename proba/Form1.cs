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
            this.ClientSize = new Size(400, 400);

            //this.BackgroundImage = Properties.Resources.slicica; // Ovde zamenite sa stvarnim imenom slike
            //this.BackgroundImageLayout = ImageLayout.Stretch; // Prilagodite po potrebi (Stretch, Tile, Center, Zoom, None)
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
            // Boje pozadine, grida i figura
            Color backgroundColor = ColorTranslator.FromHtml("#A08EB9");
            Color gridColor = ColorTranslator.FromHtml("#FCE6C1");
            Color fallenFigureColor = ColorTranslator.FromHtml("#584E66");

            // Crtanje pozadine
            e.Graphics.Clear(backgroundColor);

            // Crtanje grida
            for (int x = 0; x <= boardWidth; x++)
            {
                e.Graphics.DrawLine(new Pen(gridColor), x * cellSize, 0, x * cellSize, boardHeight * cellSize);
            }

            for (int y = 0; y <= boardHeight; y++)
            {
                e.Graphics.DrawLine(new Pen(gridColor), 0, y * cellSize, boardWidth * cellSize, y * cellSize);
            }

            // Crtanje trenutnog stanja table
            int[,] board = igra.GetBoardState();
            for (int x = 0; x < boardHeight; x++)
            {
                for (int y = 0; y < boardWidth; y++)
                {
                    if (board[x, y] != 0)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(fallenFigureColor), y * cellSize, x * cellSize, cellSize, cellSize);
                        e.Graphics.DrawRectangle(new Pen(gridColor), y * cellSize, x * cellSize, cellSize, cellSize);
                    }
                }
            }

            // Crtanje trenutne figure
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
                            e.Graphics.DrawRectangle(new Pen(gridColor), (igra.CurrentFigura.Y + y) * cellSize, (igra.CurrentFigura.X + x) * cellSize, cellSize, cellSize);
                        }
                    }
                }
            }
        }
    }
}
