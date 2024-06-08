using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    internal class Tabla
    {
        private int[,] tabla;
        private int redovi;
        private int kolone;

        public Tabla(int redovi, int kolone)
        {
            this.redovi = redovi;
            this.kolone = kolone;
            tabla = new int[redovi, kolone];
        }

        public bool DaLiJePozicijaIspravna(Figura figura, int xOffset, int yOffset)
        {
            for (int x = 0; x < figura.Oblik.GetLength(0); x++)
            {
                for (int y = 0; y < figura.Oblik.GetLength(1); y++)
                {
                    if (figura.Oblik[x, y] != 0)
                    {
                        int tablaX = figura.X + x + xOffset;
                        int tablaY = figura.Y + y + yOffset;

                        if (tablaX < 0 || tablaX >= redovi || tablaY < 0 || tablaY >= kolone)
                        {
                            return false;
                        }
                        if (tabla[tablaX, tablaY] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void DodajFiguruNaTablu(Figura figura)
        {
            for (int x = 0; x < figura.Oblik.GetLength(0); x++)
            {
                for (int y = 0; y < figura.Oblik.GetLength(1); y++)
                {
                    if (figura.Oblik[x, y] != 0)
                    {
                        tabla[figura.X + x, figura.Y + y] = figura.Oblik[x, y];
                    }
                }
            }
        }

        public void UkloniPuneRedove()
        {
            for (int i = redovi - 1; i >= 0; i--)
            {
                bool pun = true;
                for (int j = 0; j < kolone; j++)
                {
                    if (tabla[i, j] == 0)
                    {
                        pun = false;
                        break;
                    }
                }
                if (pun)
                {
                    UkloniRed(i);
                    i++;
                }
            }
        }

        private void UkloniRed(int red)
        {
            for (int i = red; i > 0; i--)
            {
                for (int j = 0; j < kolone; j++)
                {
                    tabla[i, j] = tabla[i - 1, j];
                }
            }
            for (int j = 0; j < kolone; j++)
            {
                tabla[0, j] = 0;
            }
        }

        public int[,] GetBoard()
        {
            return tabla;
        }
    }
}
