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

        static void UjDolgozo()
{
    Console.Clear();
    Console.WriteLine("=== ÚJ DOLGOZÓ FELVÉTELE ===");

    if (db >= dolgozok.Length)
    {
        Console.WriteLine("Megtelt a nyilvántartás.");
        Console.ReadKey();
        return;
    }

    Dolgozo uj = new Dolgozo();

    Console.Write("Azonosító: ");
    string azon = Console.ReadLine();

    if (azon == "")
    {
        Console.WriteLine("Az azonosító nem lehet üres!");
        Console.ReadKey();
        return;
    }

    if (LetezikAzonosito(azon))
    {
        Console.WriteLine("Ez az azonosító már létezik!");
        Console.ReadKey();
        return;
    }

    uj.Azonosito = azon;

    Console.Write("Név: ");
    string nev = Console.ReadLine();

    if (nev == "")
    {
        Console.WriteLine("A név nem lehet üres!");
        Console.ReadKey();
        return;
    }

    uj.Nev = nev;

    Console.Write("Részleg: ");
    string reszleg = Console.ReadLine();

    if (reszleg == "")
    {
        Console.WriteLine("A részleg nem lehet üres!");
        Console.ReadKey();
        return;
    }

    uj.Reszleg = reszleg;

    try
    {
        Console.Write("Fizetés: ");
        uj.Fizetes = int.Parse(Console.ReadLine());

        if (uj.Fizetes < 0)
        {
            Console.WriteLine("A fizetés nem lehet negatív!");
            Console.ReadKey();
            return;
        }
    }
    catch
    {
        Console.WriteLine("Hibás fizetés adat!");
        Console.ReadKey();
        return;
    }

    try
    {
        Console.Write("Életkor: ");
        uj.Eletkor = int.Parse(Console.ReadLine());

        if (uj.Eletkor < 16 || uj.Eletkor > 100)
        {
            Console.WriteLine("Az életkor nem megfelelő!");
            Console.ReadKey();
            return;
        }
    }
    catch
    {
        Console.WriteLine("Hibás életkor adat!");
        Console.ReadKey();
        return;
    }

    dolgozok[db] = uj;
    db++;

    Console.WriteLine("Dolgozó sikeresen felvéve.");
    Console.WriteLine("Nyomjon egy gombot a folytatáshoz...");
    Console.ReadKey();
}
        

    }
}
