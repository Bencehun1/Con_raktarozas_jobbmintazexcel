using System;
using System.IO;

namespace DolgozoiNyilvantarto
{
    class Program
    {
        static Dolgozo[] dolgozok = new Dolgozo[100];
        static int db = 0;
        static string fajlNev = "dolgozok.txt";

        static void Main(string[] args)
        {
            Betoltes();

            bool kilepes = false;

            while (!kilepes)
            {
                Console.Clear();
                Console.WriteLine("=== DOLGOZOI NYILVANTARTO RENDSZER ===");
                Console.WriteLine("Jelenleg " + db + " dolgozó van az adatbázisban.");
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("1. Dolgozók listázása");
                Console.WriteLine("2. Új dolgozó felvétele");
                Console.WriteLine("3. Dolgozó keresése");
                Console.WriteLine("4. Dolgozó módosítása");
                Console.WriteLine("5. Dolgozó törlése");
                Console.WriteLine("6. Statisztika");
                Console.WriteLine("7. Mentés és kilépés");
                Console.WriteLine("--------------------------------------");
                Console.Write("Válasszon menüpontot: ");

                string valasz = Console.ReadLine();

                if (valasz == "1")
                {
                    Listazas();
                }
                else if (valasz == "2")
                {
                    UjDolgozo();
                }
                else if (valasz == "3")
                {
                    Kereses();
                }
                else if (valasz == "4")
                {
                    Modositas();
                }
                else if (valasz == "5")
                {
                    Torles();
                }
                else if (valasz == "6")
                {
                    Statisztika();
                }
                else if (valasz == "7")
                {
                    Mentes();
                    kilepes = true;
                    Console.WriteLine("Sikeres mentés!");
                }
                else
                {
                    Console.WriteLine("Hibás menüpont!");
                    Console.WriteLine("Nyomjon egy gombot a folytatáshoz...");
                    Console.ReadKey();
                }
            }
        }


    }
}