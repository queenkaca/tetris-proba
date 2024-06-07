using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    internal class Tabla
    {
        private int[,] board;
        private int rows;
        private int columns;

        public Tabla(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            board = new int[rows, columns];
        }

        public bool IsPositionValid(Figura figura, int xOffset, int yOffset)
        {
            for (int x = 0; x < figura.Shape.GetLength(0); x++)
            {
                for (int y = 0; y < figura.Shape.GetLength(1); y++)
                {
                    if (figura.Shape[x, y] != 0)
                    {
                        int boardX = figura.X + x + xOffset;
                        int boardY = figura.Y + y + yOffset;

                        if (boardX < 0 || boardX >= rows || boardY < 0 || boardY >= columns)
                        {
                            return false;
                        }
                        if (board[boardX, boardY] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void AddFiguraToBoard(Figura figura)
        {
            for (int x = 0; x < figura.Shape.GetLength(0); x++)
            {
                for (int y = 0; y < figura.Shape.GetLength(1); y++)
                {
                    if (figura.Shape[x, y] != 0)
                    {
                        board[figura.X + x, figura.Y + y] = figura.Shape[x, y];
                    }
                }
            }
        }

        public void ClearFullLines()
        {
            for (int i = rows - 1; i >= 0; i--)
            {
                bool isFull = true;
                for (int j = 0; j < columns; j++)
                {
                    if (board[i, j] == 0)
                    {
                        isFull = false;
                        break;
                    }
                }
                if (isFull)
                {
                    ClearLine(i);
                    i++;
                }
            }
        }

        private void ClearLine(int row)
        {
            for (int i = row; i > 0; i--)
            {
                for (int j = 0; j < columns; j++)
                {
                    board[i, j] = board[i - 1, j];
                }
            }
            for (int j = 0; j < columns; j++)
            {
                board[0, j] = 0;
            }
        }

        public int[,] GetBoard()
        {
            return board;
        }
    }
}
