using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    public class Igra
    {
        private int[,] tabla;
        public Figura TrenutnaFigura { get; private set; }
        private Random random;
        public int TrenutniRezultat { get; private set; }

        public Igra(int width, int height)
        {
            tabla = new int[height, width];
            random = new Random();
            GenerisiNovuFiguru();
            TrenutniRezultat = 0;
        }

        public int[,] ProveriStanjeTable()
        {
            int[,] stanje = (int[,])tabla.Clone();
            if (TrenutnaFigura != null)
            {
                var figura = TrenutnaFigura.Oblik;
                for (int x = 0; x < figura.GetLength(0); x++)
                {
                    for (int y = 0; y < figura.GetLength(1); y++)
                    {
                        if (figura[x, y] != 0)
                        {
                            stanje[TrenutnaFigura.X + x, TrenutnaFigura.Y + y] = 1;
                        }
                    }
                }
            }
            return stanje;
        }

        public void GenerisiNovuFiguru()
        {
            switch (random.Next(7))
            {
                case 0:
                    TrenutnaFigura = new FiguraI();
                    break;
                case 1:
                    TrenutnaFigura = new FiguraJ();
                    break;
                case 2:
                    TrenutnaFigura = new FiguraL();
                    break;
                case 3:
                    TrenutnaFigura = new FiguraO();
                    break;
                case 4:
                    TrenutnaFigura = new FiguraS();
                    break;
                case 5:
                    TrenutnaFigura = new FiguraT();
                    break;
                case 6:
                    TrenutnaFigura = new FiguraZ();
                    break;
            }
        }

        public void PomeriTrenutnuFiguruDole()
        {
            if (TrenutnaFigura != null)
            {
                TrenutnaFigura.X += 1;
                if (!IsValidPosition(TrenutnaFigura))
                {
                    TrenutnaFigura.X -= 1;
                    ZalepiTrenutnuFiguru();
                    GenerisiNovuFiguru();
                    TrenutniRezultat += 4; // Dodajemo 4 poena kada figura dodje do dna
                }
            }
        }

        public void MoveCurrentFigureLeft()
        {
            if (TrenutnaFigura != null)
            {
                TrenutnaFigura.Y -= 1;
                if (!IsValidPosition(TrenutnaFigura))
                {
                    TrenutnaFigura.Y += 1;
                }
            }
        }

        public void MoveCurrentFigureRight()
        {
            if (TrenutnaFigura != null)
            {
                TrenutnaFigura.Y += 1;
                if (!IsValidPosition(TrenutnaFigura))
                {
                    TrenutnaFigura.Y -= 1;
                }
            }
        }

        public void RotateCurrentFigure()
        {
            if (TrenutnaFigura != null)
            {
                TrenutnaFigura.Rotate(); 
                if (!IsValidPosition(TrenutnaFigura))
                {
                    // Rollback rotation
                    for (int i = 0; i < 3; i++) TrenutnaFigura.Rotate();
                }
            }
        }
        public bool IsGameOver()
        {
            return !IsValidPosition(TrenutnaFigura);
        }
        private bool IsValidPosition(Figura figure)
        {
            var shape = figure.Oblik;
            for (int x = 0; x < shape.GetLength(0); x++)
            {
                for (int y = 0; y < shape.GetLength(1); y++)
                {
                    if (shape[x, y] != 0)
                    {
                        int newX = figure.X + x;
                        int newY = figure.Y + y;
                        if (newX < 0 || newX >= tabla.GetLength(0) || newY < 0 || newY >= tabla.GetLength(1) || tabla[newX, newY] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void ZalepiTrenutnuFiguru()
        {
            var figura = TrenutnaFigura.Oblik;
            for (int x = 0; x < figura.GetLength(0); x++)
            {
                for (int y = 0; y < figura.GetLength(1); y++)
                {
                    if (figura[x, y] != 0)
                    {
                        tabla[TrenutnaFigura.X + x, TrenutnaFigura.Y + y] = 1;
                    }
                }
            }
            ClearFullLines();
        }

        private void ClearFullLines()
        {
            for (int x = 0; x < tabla.GetLength(0); x++)
            {
                bool isFull = true;
                for (int y = 0; y < tabla.GetLength(1); y++)
                {
                    if (tabla[x, y] == 0)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    // Clear the line
                    for (int i = x; i > 0; i--)
                    {
                        for (int j = 0; j < tabla.GetLength(1); j++)
                        {
                            tabla[i, j] = tabla[i - 1, j];
                        }
                    }
                    for (int j = 0; j < tabla.GetLength(1); j++)
                    {
                        tabla[0, j] = 0;
                    }
                    TrenutniRezultat += 10; // Dodajemo 10 poena kada se izbrise red
                    x++; // Ponovo proveravamo istu liniju jer smo je pomerili
                }
            }
        }
    }
}
