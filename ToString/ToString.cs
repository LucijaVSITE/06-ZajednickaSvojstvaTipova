using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Vsite.CSharp
{
    struct KompleksniBroj
    {
        public KompleksniBroj(double realni, double imaginarni)
        {
            Realni = realni;
            Imaginarni = imaginarni;
        }

        public double Realni;
        public double Imaginarni;

        // TODO: Implementirati metodu ToString tako da vraća niz u obliku: "2+3j"
        // (ako je implementacija ispravna, metoda Main bi se trebala izvesti bez problema)
        public override string ToString()
        {
            if(Realni>0 && Imaginarni>0)   return string.Format("{0}+{1}j",Realni,Imaginarni);
            else
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            KompleksniBroj kb = new KompleksniBroj(2, 3);
            Debug.Assert(kb.ToString() == "2+3j");

            kb.Imaginarni = -3;
            Debug.Assert(kb.ToString() == "2-3j");

            kb.Realni = 0;
            Debug.Assert(kb.ToString() == "-3j");

            kb.Imaginarni = 0;
            Debug.Assert(kb.ToString() == "0");

            kb.Realni = -2;
            Debug.Assert(kb.ToString() == "-2");
        }
    }
}
