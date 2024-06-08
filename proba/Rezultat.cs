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
        public List<int> AllScores { get; private set; }

        public Rezultat()
        {
            Points = 0;
            AllScores = new List<int>();
        }

        public void AddPoints(int points)
        {
            Points += points;
        }
        public void AddScoreToList(int score)
        {
            AllScores.Add(score); // Dodajemo rezultat u listu rezultata
        }

        public int MaxScore()
        {
            return AllScores.Max(); // Vraćamo maksimalni rezultat
        }
    }
}
