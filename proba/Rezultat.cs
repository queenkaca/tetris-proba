using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    internal class Rezultat
    {
        public int Points { get; private set; }

        public Rezultat()
        {
            Points = 0;
        }

        public void AddPoints(int points)
        {
            Points += points;
        }
    }
}
