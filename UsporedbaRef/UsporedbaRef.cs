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
            // Preslikati implementaciju metode iz EqualsRefTip1
            if (obj == null)
                return false;
            if (this.GetType() != obj.GetType())
                return false;
            Osoba a = (Osoba)obj;
            if ((Osoba.Equals(this.m_ime, a.m_ime)) == false)
                return false;
            return m_matičniBroj.Equals(a.m_matičniBroj);
        }

        // TODO: implementirati operatore == i != tako da se metoda Main izvede bez problema
        public static bool operator ==(Osoba a, Osoba b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.m_ime == b.m_ime && a.m_matičniBroj == b.m_matičniBroj;
        }

        public static bool operator !=(Osoba a, Osoba b)
        {
            return !(a == b);
        }

        // POGREŠNA IMPLEMENTACIJA (beskonačna rekurzija)
        /*
        public static bool operator ==(Osoba rt1, Osoba rt2)
        {
            if (rt1 == rt2) 
                return true; 
            if (rt1 == null || rt2 == null) 
                return false;
            // ...
            return true;
        }
        */
        
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
            Debug.Assert((osobaA == osobaB) == false);
            Debug.Assert(osobaA != osobaB);

            // novi "Janko" s drugim matičnim brojem
            osobaB = new Osoba("Janko", 2);
            Debug.Assert((osobaA == osobaB) == false);
            Debug.Assert(osobaA != osobaB);

            // novi "Janko" s istim matičnim brojem
            osobaB = new Osoba("Janko", 1);
            Debug.Assert(osobaA == osobaB);
            Debug.Assert((osobaA != osobaB) == false);

            osobaB = osobaA;
            Debug.Assert(osobaA == osobaB);
            Debug.Assert((osobaA != osobaB) == false);

            osobaB = null;
            Debug.Assert((osobaA == osobaB) == false);
            Debug.Assert(osobaA != osobaB);

            osobaA = null;
            Debug.Assert(osobaA == osobaB);
            Debug.Assert((osobaA != osobaB) == false);


            Console.ReadLine();
        }
    }
}
