using System;
using System.Diagnostics;

namespace Vsite.CSharp
{
    class Osoba
    {
        public Osoba(string ime, int matičniBroj)
        {
            m_ime = ime;
            m_matičniBroj = matičniBroj;
        }

        string m_ime;       // član referentnog tipa
        int m_matičniBroj;  // član vrijednosnog tipa


        public override bool Equals(object obj)
        {
            if (obj == null) // ako neko prosljedi 0 pointer
                return false;
            if (this.GetType() != obj.GetType()) //ako je prosljeđen krivi tip "kruške i jabuke"
                return false;
            // implementirati metodu Equals tako da za osobe s istim imenom i matičnim brojem rezultat bude true
            // (ako je metoda dobro implementirana, metoda Main bi se trebala izvesti bez problema)
            Osoba a = (Osoba)obj;

            if ((Osoba.Equals(this.m_ime,a.m_ime)) == false) //Kod uspoređivanja paziti da nije null string
                return false;

            return m_matičniBroj.Equals(a.m_matičniBroj);
            //if ((this.m_ime != a.m_ime) || (this.m_matičniBroj != a.m_matičniBroj))
                //return false;
            //return true;  // ako je sve prošlo – objekti su jednaki
        }

        public override string ToString()
        {
            return string.Format("'{0}, {1}'", m_ime, m_matičniBroj);
        }

        public Osoba other { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // dvije osobe s različitim imenima i MB
            Osoba osobaA = new Osoba("Janko", 1);
            Osoba osobaB = new Osoba("Darko", 2);
            Debug.Assert(osobaA.Equals(osobaB) == false);

            // novi "Janko" s drugim matičnim brojem
            osobaB = new Osoba("Janko", 2);
            Debug.Assert(osobaA.Equals(osobaB) == false);

            // novi "Janko" s istim matičnim brojem
            osobaB = new Osoba("Janko", 1);
            Debug.Assert(osobaA.Equals(osobaB) == true);

            osobaB = osobaA;
            Debug.Assert(osobaA.Equals(osobaB) == true);

            Console.ReadLine();
        }
    }
}
