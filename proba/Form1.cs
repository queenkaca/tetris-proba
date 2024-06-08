using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proba
{
    public partial class Form1 : Form
    {
        private Igra igra;
        private Rezultat rezultat;
        private const int boardWidth = 10;
        private const int boardHeight = 20;
        private const int cellSize = 30;
        private SoundPlayer soundPlayer;
        public Form1()
        {
            InitializeComponent();
            igra = new Igra(boardWidth, boardHeight);
            timer1.Interval = 600;
            timer1.Start();
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.ClientSize = new Size(600, 600);
            rezultat = new Rezultat();
            this.Text = "Lo-Fi Tetris";
            this.BackgroundImage = Properties.Resources.lofi1; // Ovde zamenite sa stvarnim imenom slike
            this.BackgroundImageLayout = ImageLayout.Center; // Prilagodite po potrebi (Stretch, Tile, Center, Zoom, None)
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Focus();

            // Initialize the SoundPlayer with the path to the audio filee
            soundPlayer = new SoundPlayer(@"music.wav");

            // Play the sound in a loop
            soundPlayer.PlayLooping();
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
                    igra.PomeriTrenutnuFiguruDole();
                    break;
                case Keys.Up:
                    igra.RotateCurrentFigure();
                    break;
            }
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!igra.IsGameOver())
            {
                igra.PomeriTrenutnuFiguruDole();
                label5.Text = igra.TrenutniRezultat.ToString();

            }

            else           
            {
                rezultat.ProveriNajRezultat(igra.TrenutniRezultat);
                label3.Text = rezultat.NajRezultat.ToString();
                
                // Igra je završena, zaustavljamo tajmer
                timer1.Stop();
                

                // Prikazujemo dugme za ponovno pokretanje
                button1.Visible = true;
            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Boje pozadine, grida i figura
            Color backgroundColor = ColorTranslator.FromHtml("#A08EB9");
            Color gridColor = ColorTranslator.FromHtml("#FCE6C1");
            Color fallenFigureColor = ColorTranslator.FromHtml("#584E66");

            // Crtanje pozadine
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), 0, 0, boardWidth * cellSize, boardHeight * cellSize);
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
            int[,] board = igra.ProveriStanjeTable();
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
            if (igra.TrenutnaFigura != null)
            {
                var shape = igra.TrenutnaFigura.Oblik;
                var color = igra.TrenutnaFigura.Boja;
                for (int x = 0; x < shape.GetLength(0); x++)
                {
                    for (int y = 0; y < shape.GetLength(1); y++)
                    {
                        if (shape[x, y] != 0)
                        {
                            e.Graphics.FillRectangle(new SolidBrush(color), (igra.TrenutnaFigura.Y + y) * cellSize, 
                                (igra.TrenutnaFigura.X + x) * cellSize, cellSize, cellSize);
                            e.Graphics.DrawRectangle(new Pen(gridColor), (igra.TrenutnaFigura.Y + y) * cellSize,
                                (igra.TrenutnaFigura.X + x) * cellSize, cellSize, cellSize);
                        }
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            igra = new Igra(boardWidth, boardHeight);
            timer1.Interval = 500;
            timer1.Start();
            // Ukloni dugme za ponovno pokretanje
            button1.Visible = false;
            this.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
