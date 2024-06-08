using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proba
{
    internal class Rezultat
    {
        public int Poeni { get; private set; }

        int najRezultat;
        public Rezultat()
        {
            Poeni = 0;
            NajRezultat = 0;
        }
        public int NajRezultat
        {
            get { return najRezultat; }
            set { najRezultat = value; }
        }
        public void DodajPoene(int points)
        {
            Poeni += points;
        }
        public void ProveriNajRezultat(int rezultat)
        {
            if(rezultat > NajRezultat)
                NajRezultat = rezultat;
        }

    }
}
