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

            
            static void Listazas()
{
    Console.Clear();
    Console.WriteLine("=== DOLGOZÓK LISTÁJA ===");

    if (db == 0)
    {
        Console.WriteLine("Nincs még dolgozó.");
    }
    else
    {
        int i = 0;
        while (i < db)
        {
            Console.WriteLine((i + 1) + ". dolgozó");
            Console.WriteLine("Azonosító: " + dolgozok[i].Azonosito);
            Console.WriteLine("Név: " + dolgozok[i].Nev);
            Console.WriteLine("Részleg: " + dolgozok[i].Reszleg);
            Console.WriteLine("Fizetés: " + dolgozok[i].Fizetes + " Ft");
            Console.WriteLine("Életkor: " + dolgozok[i].Eletkor);
            Console.WriteLine("----------------------------");
            i++;
        }
    }

    Console.WriteLine("Nyomjon egy gombot a folytatáshoz...");
    Console.ReadKey();
}

         static void Kereses()
 {
     Console.Clear();
     Console.WriteLine("=== DOLGOZÓ KERESÉSE ===");
     Console.Write("Adja meg az azonosítót: ");
     string azon = Console.ReadLine();

     int index = KeresIndex(azon);

     if (index == -1)
     {
         Console.WriteLine("Nincs ilyen dolgozó.");
     }
     else
     {
         Console.WriteLine("Azonosító: " + dolgozok[index].Azonosito);
         Console.WriteLine("Név: " + dolgozok[index].Nev);
         Console.WriteLine("Részleg: " + dolgozok[index].Reszleg);
         Console.WriteLine("Fizetés: " + dolgozok[index].Fizetes + " Ft");
         Console.WriteLine("Életkor: " + dolgozok[index].Eletkor);
     }

     Console.WriteLine("Nyomjon egy gombot a folytatáshoz...");
     Console.ReadKey();
 }

                static void Modositas()
        {
            Console.Clear();
            Console.WriteLine("=== DOLGOZÓ MÓDOSÍTÁSA ===");
            Console.Write("Adja meg a módosítandó dolgozó azonosítóját: ");
            string azon = Console.ReadLine();

            int index = KeresIndex(azon);

            if (index == -1)
            {
                Console.WriteLine("Nincs ilyen dolgozó.");
                Console.ReadKey();
                return;
            }

            Console.Write("Új név: ");
            string ujNev = Console.ReadLine();
            if (ujNev != "")
            {
                dolgozok[index].Nev = ujNev;
            }

            Console.Write("Új részleg: ");
            string ujReszleg = Console.ReadLine();
            if (ujReszleg != "")
            {
                dolgozok[index].Reszleg = ujReszleg;
            }

            Console.Write("Új fizetés: ");
            string fizetesSzoveg = Console.ReadLine();
            if (fizetesSzoveg != "")
            {
                try
                {
                    int ujFizetes = int.Parse(fizetesSzoveg);
                    if (ujFizetes >= 0)
                    {
                        dolgozok[index].Fizetes = ujFizetes;
                    }
                    else
                    {
                        Console.WriteLine("Negatív fizetés nem adható meg.");
                    }
                }
                catch
                {
                    Console.WriteLine("Hibás fizetés, a régi marad.");
                }
            }

            Console.Write("Új életkor: ");
            string eletkorSzoveg = Console.ReadLine();
            if (eletkorSzoveg != "")
            {
                try
                {
                    int ujEletkor = int.Parse(eletkorSzoveg);
                    if (ujEletkor >= 16 && ujEletkor <= 100)
                    {
                        dolgozok[index].Eletkor = ujEletkor;
                    }
                    else
                    {
                        Console.WriteLine("Hibás életkor, a régi marad.");
                    }
                }
                catch
                {
                    Console.WriteLine("Hibás életkor, a régi marad.");
                }
            }

            Console.WriteLine("Sikeres módosítás.");
            Console.WriteLine("Nyomjon egy gombot a folytatáshoz...");
            Console.ReadKey();
        }

    }
}
