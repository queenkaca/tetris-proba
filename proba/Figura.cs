using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    public abstract class Figura
    {
        public int[,,] Shapes { get; set; } // 3D matrix for all rotations
        public int RotationIndex { get; set; } // Current rotation
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; } // Color of the figure

        public int[,] Shape
        {
            get
            {
                int size = Shapes.GetLength(1);
                int[,] shape = new int[size, size];
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        shape[i, j] = Shapes[RotationIndex, i, j];
                    }
                }
                return shape;
            }
        }

        public void Rotate()
        {
            RotationIndex = (RotationIndex + 1) % 4;
        }

        protected static Color GetRandomColor()
        {
            Random rand = new Random();
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
    public class FiguraI : Figura
    {
        public FiguraI() : base()
        {
            Shapes = new int[4, 4, 4]
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
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }

    public class FiguraJ : Figura
    {
        public FiguraJ() : base()
        {
            Shapes = new int[4, 3, 3]
            {
            {
                { -1, 0, 0 },
                { -1, -1, -1 },
                { 0, 0, 0 }
            },
            {
                { 0, -1, -1 },
                { 0, -1, 0 },
                { 0, -1, 0 }
            },
            {
                { 0, 0, 0 },
                { -1, -1, -1 },
                { 0, 0, -1 }
            },
            {
                { 0, -1, 0 },
                { 0, -1, 0 },
                { -1, -1, 0 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }


    public class FiguraL : Figura
    {
        public FiguraL() : base()
        {
            Shapes = new int[4, 3, 3]
            {
            {
                { 0, 0, -1 },
                { -1, -1, -1 },
                { 0, 0, 0 }
            },
            {
                { 0, -1, 0 },
                { 0, -1, 0 },
                { 0, -1, -1 }
            },
            {
                { 0, 0, 0 },
                { -1, -1, -1 },
                { -1, 0, 0 }
            },
            {
                { -1, -1, 0 },
                { 0, -1, 0 },
                { 0, -1, 0 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }


    public class FiguraO : Figura
    {
        public FiguraO() : base()
        {
            Shapes = new int[1, 2, 2]
            {
            {
                { -1, -1 },
                { -1, -1 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }


    public class FiguraS : Figura
    {
        public FiguraS() : base()
        {
            Shapes = new int[4, 3, 3]
            {
            {
                { 0, -1, -1 },
                { -1, -1, 0 },
                { 0, 0, 0 }
            },
            {
                { 0, -1, 0 },
                { 0, -1, -1 },
                { 0, 0, -1 }
            },
            {
                { 0, 0, 0 },
                { 0, -1, -1 },
                { -1, -1, 0 }
            },
            {
                { -1, 0, 0 },
                { -1, -1, 0 },
                { 0, -1, 0 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }


    public class FiguraT : Figura
    {
        public FiguraT() : base()
        {
            Shapes = new int[4, 3, 3]
            {
            {
                { 0, -1, 0 },
                { -1, -1, -1 },
                { 0, 0, 0 }
            },
            {
                { 0, -1, 0 },
                { 0, -1, -1 },
                { 0, -1, 0 }
            },
            {
                { 0, 0, 0 },
                { -1, -1, -1 },
                { 0, -1, 0 }
            },
            {
                { 0, -1, 0 },
                { -1, -1, 0 },
                { 0, -1, 0 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }

    public class FiguraZ : Figura
    {
        public FiguraZ() : base()
        {
            Shapes = new int[4, 3, 3]
            {
            {
                { -1, -1, 0 },
                { 0, -1, -1 },
                { 0, 0, 0 }
            },
            {
                { 0, 0, -1 },
                { 0, -1, -1 },
                { 0, -1, 0 }
            },
            {
                { 0, 0, 0 },
                { -1, -1, 0 },
                { 0, -1, -1 }
            },
            {
                { 0, -1, 0 },
                { -1, -1, 0 },
                { -1, 0, 0 }
            }
            };
            RotationIndex = 0;
            X = 0;
            Y = 0;
            Color = GetRandomColor();

        }
    }
}