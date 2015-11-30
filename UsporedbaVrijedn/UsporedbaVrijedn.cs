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
            return this.Equals((Osoba)obj);
        }

        public bool Equals(Osoba obj)
        {
            // Preslikati implementaciju metode Equals iz EqualsRefTip
            if (this.GetType() != obj.GetType())
                return false;
            Osoba a = (Osoba)obj;
            if ((Osoba.Equals(this.m_ime, a.m_ime)) == false)
                return false;
            return m_matičniBroj.Equals(a.m_matičniBroj);

  
        }

        // implementirati operatore == i != tako da se metoda Main izvede bez problema
        public static bool operator ==(Osoba o1, Osoba o2)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(o1, o2))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)o1 == null) || ((object)o2 == null))
            {
                return false;
            }

            // Return true if the fields match:
            return o1.m_ime == o2.m_ime && o1.m_matičniBroj== o2.m_matičniBroj;
        }

        public static bool operator !=(Osoba o1, Osoba o2)
        {

            return !(o1 == o2);
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

            // preslika osobe A
            osobaB = osobaA;
            Debug.Assert(osobaA == osobaB);
            Debug.Assert((osobaA != osobaB) == false);

            // novi "Janko" s istim matičnim brojem
            osobaB = new Osoba("Janko", 1);
            Debug.Assert(osobaA == osobaB);
            Debug.Assert((osobaA != osobaB) == false);

            // "Janko", ali s drugim matičnim brojem
            osobaB = new Osoba("Janko", 2);
            Debug.Assert((osobaA == osobaB) == false);
            Debug.Assert(osobaA != osobaB);

            Console.ReadLine();
        }
    }
}
