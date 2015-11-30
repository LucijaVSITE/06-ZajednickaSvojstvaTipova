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
            // prekopirati kod metode Equals iz zadatka EqualsRefTip1
            if (obj == null)
                return false;
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

    class Student : Osoba
    {
        public Student(string ime, int matičniBroj, string smjer, int godina) : base(ime, matičniBroj)
        {
            m_smjer = smjer;
            m_godina = godina;
        }

        string m_smjer;
        int m_godina;

        public override bool Equals(object obj) 
        {
            if (!base.Equals(obj)) // prvo pozivamo Equals baznog tipa
                return false;
            // dodati potrebne usporedbe da bi studenti bili jednaki samo ako su na istom smjeru i godini
            // (za ispravnu implementaciju bi metoda Main trebala proći bez problema)
            Student k = (Student)obj;
            if ((Osoba.Equals(this.m_smjer, k.m_smjer)) == false)
                return false;

            return m_godina.Equals(k.m_godina);
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} {2}.godina)", base.ToString(), m_smjer, m_godina);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // dva različita studenta
            Student studentA = new Student("Janko", 1, "Programiranje", 3);
            Student studentB = new Student("Darko", 2, "Administriranje", 2);
            Debug.Assert(Student.Equals(studentA, studentB) == false);

            // novi "Janko" s istim matičnim brojem, isti smjer i godina
            studentB = new Student("Janko", 1, "Programiranje", 3);
            Debug.Assert(Student.Equals(studentA, studentB) == true);

            // "Janko", ali na drugoj godini
            studentB = new Student("Janko", 1, "Programiranje", 2);
            Debug.Assert(Student.Equals(studentA, studentB) == false);

            studentA = studentB;
            Debug.Assert(Student.Equals(studentA, studentB) == true);

            Console.ReadLine();
        }
    }
}
