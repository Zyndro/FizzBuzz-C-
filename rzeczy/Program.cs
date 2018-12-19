using System;
using System.IO;

namespace rzeczy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Menu();
            }
            catch
            {
                Console.WriteLine("cos zepsules, albo ja zepsulem");
                Console.ReadLine();
            }
        }

        public static void Menu()
        {
            Console.WriteLine("1.FizzBuzz");
            Console.WriteLine("2.DeepDive");
            Console.WriteLine("3.DrownItDown");
            Console.WriteLine("4.exit");
            string i = Console.ReadLine();

            switch (i)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Fizzbuzz");
                    Fzbz();
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Deepdive");
                    Deep();
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("Drownitin");
                    Drown();
                    break;
                case "4":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidlwa opcja");
                    Console.WriteLine(" ");
                    Menu();
                    break;
            }
        }

        public static void Fzbz()
        {
            Console.Clear();
            Console.WriteLine("Podaj Liczbę w przedziale 0-1000:");
            try
            {
                int fz = int.Parse(Console.ReadLine());
                if (fz >= 1 && fz <= 1000)
                {
                    bool fizz = fz % 2 == 0;
                    bool buzz = fz % 3 == 0;
                    if (fizz && buzz)
                    {
                        Console.Clear();
                        Console.WriteLine("FizzBuzz");
                    }
                    else if (fizz)
                    {
                        Console.Clear();
                        Console.WriteLine("Fizz");
                    }
                    else if (buzz)
                    {
                        Console.Clear();
                        Console.WriteLine("Buzz");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Liczba niepodzielna przez 2 ani 3");
                    }
                    Console.ReadLine();
                    Console.Clear();
                    Menu();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podana liczba przekracza zakres");
                    Console.ReadLine();
                    Fzbz();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Wpisano nieprawidlowa wartosc");
                Console.ReadLine();
                Fzbz();
            }
        }

        public static void Deep()
        {

            string[] foldery;
            string dd = "DeepDive";
            foldery = new string[5];
            string pulpit = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string pulpitdd = Path.Combine(pulpit, dd);
            if (Directory.Exists(pulpitdd))
                Directory.Delete(pulpitdd, true);
            Console.Clear();
            Console.WriteLine("Ile folderow zagniezdzic(max 5)");
            Console.WriteLine("Folder bazowy zostanie utworzony na pulpicie");
            try
            {
                Guid g;
                Guid d;
                g = Guid.NewGuid();
                int ilosc = int.Parse(Console.ReadLine());
                if (ilosc >= 1 && ilosc <= 5)
                {
                    Directory.CreateDirectory(pulpitdd + Path.DirectorySeparatorChar + g);
                    string directory = Path.Combine(pulpitdd, g.ToString());
                    g = Guid.NewGuid();
                    string deeper = Path.Combine(directory, g.ToString());
                    foldery[0] = directory;
                    for (int i = 0; i < ilosc - 1; i++)
                    {
                        Directory.CreateDirectory(deeper);
                        d = Guid.NewGuid();
                        foldery[i + 1] = deeper;
                        deeper = Path.Combine(deeper, d.ToString());
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("nieprawidlowa wartosc");
                    Console.WriteLine(" ");
                    Menu();
                }
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Wpisano nieprawidlowa wartosc");
                Console.WriteLine(" ");
                Menu();
            }
            Console.Clear();
            Console.WriteLine("Utworzono foldery:");
            Console.WriteLine(foldery[0]);
            Console.WriteLine(foldery[1]);
            Console.WriteLine(foldery[2]);
            Console.WriteLine(foldery[3]);
            Console.WriteLine(foldery[4]);
            Console.WriteLine(" ");
            Menu();
        }

        public static void Drown()
        {
            Console.Clear();
            string dd = "DeepDive";
            string pulpit = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string pulpitdd = Path.Combine(pulpit, dd);
            try
            {
                string[] folders = System.IO.Directory.GetDirectories(pulpitdd, "*", System.IO.SearchOption.AllDirectories);
                Console.WriteLine("Na ktorym poziomie umiescic plik?:");
                int poziom = int.Parse(Console.ReadLine());
                if (File.Exists(folders[poziom - 1] + "/pusty.plik"))
                {
                    Console.Clear();
                    Console.WriteLine("Plik istnieje");
                    Console.WriteLine("nadpisac?");
                    Console.WriteLine("1.tak 2.nie");
                    int pytanie = int.Parse(Console.ReadLine());
                    if (pytanie == 1)
                    {
                        File.AppendAllText(folders[poziom - 1] + "/pusty.plik", "");
                        Console.Clear();
                        Console.WriteLine("Zapisano");
                        Console.WriteLine(" ");
                        Menu();
                    }
                    if (pytanie == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Niedokonano zmian");
                        Console.WriteLine(" ");
                        Menu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz prawidlowa opcje");
                        Console.WriteLine(" ");
                        Menu();
                    }
                }
                else
                {
                    File.AppendAllText(folders[poziom - 1] + "/pusty.plik", "");
                    Console.Clear();
                    Console.WriteLine("Utworzono plik");
                    Console.WriteLine(" ");
                    Menu();
                }
            }
            catch (System.IndexOutOfRangeException)
            {
                Console.Clear();
                Console.WriteLine("Nie istnieje tak głęboka struktura");
                Console.WriteLine("Stworz glebsza modulem DeepDive");
                Console.WriteLine(" ");
                Menu();
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Skozystaj najpierw z DeepDive");
                Console.WriteLine(" ");
                Menu();
            }
        }
    }
}


