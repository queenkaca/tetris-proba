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
        private int[,] board;
        public Figura CurrentFigura { get; private set; }
        private Random random;
        public int CurrentScore { get; private set; }

        public Igra(int width, int height)
        {
            board = new int[height, width];
            random = new Random();
            SpawnNewFigure();
            CurrentScore = 0;
        }

        public int[,] GetBoardState()
        {
            int[,] state = (int[,])board.Clone();
            if (CurrentFigura != null)
            {
                var shape = CurrentFigura.Shape;
                for (int x = 0; x < shape.GetLength(0); x++)
                {
                    for (int y = 0; y < shape.GetLength(1); y++)
                    {
                        if (shape[x, y] != 0)
                        {
                            state[CurrentFigura.X + x, CurrentFigura.Y + y] = 1;
                        }
                    }
                }
            }
            return state;
        }

        public void SpawnNewFigure()
        {
            switch (random.Next(7))
            {
                case 0:
                    CurrentFigura = new FiguraI();
                    break;
                case 1:
                    CurrentFigura = new FiguraJ();
                    break;
                case 2:
                    CurrentFigura = new FiguraL();
                    break;
                case 3:
                    CurrentFigura = new FiguraO();
                    break;
                case 4:
                    CurrentFigura = new FiguraS();
                    break;
                case 5:
                    CurrentFigura = new FiguraT();
                    break;
                case 6:
                    CurrentFigura = new FiguraZ();
                    break;
            }
        }

        public void MoveCurrentFigureDown()
        {
            if (CurrentFigura != null)
            {
                CurrentFigura.X += 1;
                if (!IsValidPosition(CurrentFigura))
                {
                    CurrentFigura.X -= 1;
                    MergeCurrentFigure();
                    SpawnNewFigure();
                    CurrentScore += 4; // Dodajemo 4 poena kada figura dodje do dna
                }
            }
        }

        public void MoveCurrentFigureLeft()
        {
            if (CurrentFigura != null)
            {
                CurrentFigura.Y -= 1;
                if (!IsValidPosition(CurrentFigura))
                {
                    CurrentFigura.Y += 1;
                }
            }
        }

        public void MoveCurrentFigureRight()
        {
            if (CurrentFigura != null)
            {
                CurrentFigura.Y += 1;
                if (!IsValidPosition(CurrentFigura))
                {
                    CurrentFigura.Y -= 1;
                }
            }
        }

        public void RotateCurrentFigure()
        {
            if (CurrentFigura != null)
            {
                CurrentFigura.Rotate();
                if (!IsValidPosition(CurrentFigura))
                {
                    // Rollback rotation
                    for (int i = 0; i < 3; i++) CurrentFigura.Rotate();
                }
            }
        }

        private bool IsValidPosition(Figura figure)
        {
            var shape = figure.Shape;
            for (int x = 0; x < shape.GetLength(0); x++)
            {
                for (int y = 0; y < shape.GetLength(1); y++)
                {
                    if (shape[x, y] != 0)
                    {
                        int newX = figure.X + x;
                        int newY = figure.Y + y;
                        if (newX < 0 || newX >= board.GetLength(0) || newY < 0 || newY >= board.GetLength(1) || board[newX, newY] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void MergeCurrentFigure()
        {
            var shape = CurrentFigura.Shape;
            for (int x = 0; x < shape.GetLength(0); x++)
            {
                for (int y = 0; y < shape.GetLength(1); y++)
                {
                    if (shape[x, y] != 0)
                    {
                        board[CurrentFigura.X + x, CurrentFigura.Y + y] = 1;
                    }
                }
            }
            ClearFullLines();
        }

        private void ClearFullLines()
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                bool isFull = true;
                for (int y = 0; y < board.GetLength(1); y++)
                {
                    if (board[x, y] == 0)
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
                        for (int j = 0; j < board.GetLength(1); j++)
                        {
                            board[i, j] = board[i - 1, j];
                        }
                    }
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        board[0, j] = 0;
                    }
                    CurrentScore += 10; // Dodajemo 10 poena kada se izbrise red
                    x++; // Ponovo proveravamo istu liniju jer smo je pomerili
                }
            }
        }
    }
}
