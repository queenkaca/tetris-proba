using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    public abstract class Figura
    {
        public int[,,] Figure { get; set; } // 3D matrica za sve rotacije
        public int IndeksRotacije { get; set; } // Trenutna rotacija
        public int X { get; set; }
        public int Y { get; set; }
        public Color Boja { get; set; } // Boja figure

        public Figura()
        {
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
        public int[,] Oblik
        {
            get
            {
                int velicina = Figure.GetLength(1);
                int[,] oblik = new int[velicina, velicina];
                for (int i = 0; i < velicina; i++)
                {
                    for (int j = 0; j < velicina; j++)
                    {
                        oblik[i, j] = Figure[IndeksRotacije, i, j];
                    }
                }
                return oblik;
            }
        }

        public void Rotiraj()
        {
            IndeksRotacije = (IndeksRotacije  %3 + 1)%4 ;
        }

        protected static Color BirajRandomBoju()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
    public class FiguraI : Figura
    {
        public FiguraI() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, -1, -1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, -1, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, -1, -1 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraJ : Figura
    {
        public FiguraJ() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { -1, 0, 0, 0 },
                { -1, -1, -1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, -1, 0 },
                { 0, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { -1, -1, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraL : Figura
    {
        public FiguraL() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { 0, 0, -1, 0 },
                { -1, -1, -1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, -1, 0 },
                { -1, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { -1, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraO : Figura
    {
        public FiguraO() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { 0, 0, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraS : Figura
    {
        public FiguraS() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { 0, -1, -1, 0 },
                { -1, -1, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { 0, -1, -1, 0 },
                { -1, -1, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { -1, 0, 0, 0 },
                { -1, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraT : Figura
    {
        public FiguraT() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { 0, -1, 0, 0 },
                { -1, -1, -1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, -1, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            },
            
            {
                { 0, -1, 0, 0 },
                { -1, -1, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }

    public class FiguraZ : Figura
    {
        public FiguraZ() : base()
        {
            Figure = new int[4, 4, 4]
            {
            {
                { -1, -1, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, -1, 0 },
                { 0, -1, -1, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, 0, 0, 0 },
                { -1, -1, 0, 0 },
                { 0, -1, -1, 0 },
                { 0, 0, 0, 0 }
            },
            {
                { 0, -1, 0, 0 },
                { -1, -1, 0, 0 },
                { -1, 0, 0, 0 },
                { 0, 0, 0, 0 }
            }
            };
            IndeksRotacije = 0;
            X = 0;
            Y = 0;
            Boja = BirajRandomBoju();
        }
    }
}