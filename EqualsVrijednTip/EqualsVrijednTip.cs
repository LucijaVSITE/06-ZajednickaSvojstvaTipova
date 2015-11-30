using System;
using System.Diagnostics;

namespace Vsite.CSharp
{
    struct Osoba 
    {
        public Osoba(string ime, int matičniBroj)
        {
            m_ime = ime;
            m_matičniBroj = matičniBroj;
        }

        string m_ime;
        int m_matičniBroj;

        
        public override bool Equals(object obj)
        {
            if (!(obj is Osoba))
                return false;
            // poziva tipski sigurnu implementaciju:
            return this.Equals((Osoba)obj);
        }

        // tipski sigurna (type-safe) implementacija
        public bool Equals(Osoba obj)
        {
            // Implementirati tipski sigurnu usporedbu tako da metoda Main prođe bez problema
            if (this.GetType() != obj.GetType())
                return false;
            Osoba a = (Osoba)obj;
            if ((Osoba.Equals(this.m_ime, a.m_ime)) == false)
                return false;
            return m_matičniBroj.Equals(a.m_matičniBroj);
        }

        public override string ToString()
        {
            return string.Format("'{0}, {1}'", m_ime, m_matičniBroj);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // dvije osobe s različitim imenima i MB
            Osoba osobaA = new Osoba("Janko", 1);
            Osoba osobaB = new Osoba("Darko", 2);
            Debug.Assert(osobaA.Equals(osobaB) == false);

            // preslika osobe A
            osobaB = osobaA;
            Debug.Assert(osobaA.Equals(osobaB) == true);

            // novi "Janko" s istim matičnim brojem
            osobaB = new Osoba("Janko", 1);
            Debug.Assert(osobaA.Equals(osobaB) == true);

            // "Janko", ali s drugim matičnim brojem
            osobaB = new Osoba("Janko", 2);
            Debug.Assert(osobaA.Equals(osobaB) == false);


            Console.ReadLine();
        }
    }
}
