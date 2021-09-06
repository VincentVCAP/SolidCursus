using System;
using System.Collections.Generic;

namespace SOLID_Start
{
    class Program
    {
        static void Main(string[] args)
        {
            //Demo-Application

            List<Klant> klanten = new List<Klant>();
            Klant k = new Klant("Peeters");

            k.AddMovie(new Huur(new Movie("Godfather", 1), 3));
            klanten.Add(k);

            Klant k2 = new Klant("Vandeperre");
            k2.AddMovie(new Huur(new Movie("Lion King", 2), 2));
            klanten.Add(k2);


            Klant k3 = new Klant("Verlinden");
            k3.AddMovie(new Huur(new Movie("Rundskop", 1), 4));
            klanten.Add(k3);


            Klant k4 = new Klant("Dams");
            k4.AddMovie(new Huur(new Movie("Top Gun", 3), 1));
            klanten.Add(k4);

            foreach (Klant klant in klanten)
            {
                Console.WriteLine(klant.GetRekening());
            }

            Console.ReadLine();
        }
    }
}
