using System;

namespace Vsite.CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Pokrenuti program i ispis preslikati u datoteku GetHashCodeString.txt pridruženu projektu
            // U datoteci navesti koja dva znakovan niza daju najbliže brojeve

            Console.WriteLine("cat".GetHashCode());
            Console.WriteLine("cta".GetHashCode());
            Console.WriteLine("cap".GetHashCode());
            Console.WriteLine("car".GetHashCode());
            Console.WriteLine("cut".GetHashCode());

            object o1 = new object();
            object o2 = new object();
            object o3 = o1;
            Console.WriteLine(o1.GetHashCode());
            Console.WriteLine(o2.GetHashCode());
            Console.WriteLine(o3.GetHashCode());

            Console.ReadKey();
        }
    }
}
