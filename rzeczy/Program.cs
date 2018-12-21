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
            string input = (Console.ReadLine());
            bool res = int.TryParse(input, out int fz);
            if (res == false)
            {
                Console.Clear();
                Console.WriteLine("Prosze o wpisanie liczby calkowitej");
                Console.ReadLine();
                Fzbz();
            }
            else
            {
                if (fz >= 0 && fz <= 1000)
                {
                    bool fizz = fz % 2 == 0;
                    bool buzz = fz % 3 == 0;
                    if (fz == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Wpisano 0");
                    }
                    else if (fizz && buzz)
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
            Console.WriteLine("Ile folderow zagniezdzic(1-5)");
            Console.WriteLine("Folder bazowy zostanie utworzony na pulpicie");
            Guid g;
            Guid d;
            g = Guid.NewGuid();
            string input1 = (Console.ReadLine());
            if (int.TryParse(input1, out int ilosc))
                {
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
                        Console.WriteLine("Podaj liczbe calkowita z przedzialu 1-5");
                        Console.WriteLine(" ");
                        Menu();
                    }
                }
            else
                {
                    Console.Clear();
                    Console.WriteLine("Podaj liczbe calkowita z przedzialu 1-5");
                    Console.WriteLine(" ");
                    Menu();
                }
            Console.Clear();
            Console.WriteLine("Utworzono foldery:");
            string[] folders = System.IO.Directory.GetDirectories(pulpitdd, "*", System.IO.SearchOption.AllDirectories);
            int foldersLength = folders.Length;
            for (int i = 0; i < foldersLength; i++)
            {
                Console.WriteLine(foldery[i]);
            }
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
                string input1 = (Console.ReadLine());
                bool res = int.TryParse(input1, out int poziom);
                if (res == false)
                {
                    Console.Clear();
                    Console.WriteLine("Podaj liczbe calkowita");
                    Console.WriteLine(" ");
                    Menu();
                }
                if (poziom <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("Poziom musi byc wyzszy od 0");
                    Console.WriteLine(" ");
                    Menu();
                }
                if (File.Exists(folders[poziom - 1] + "/pusty.plik"))
                {
                    Console.Clear();
                    Console.WriteLine("Plik istnieje");
                    Console.WriteLine("nadpisac?");
                    Console.WriteLine("1.tak 2.nie");
                    string input = (Console.ReadLine());
                    bool res1 = int.TryParse(input, out int pytanie);
                    if (res1 == false)
                    {
                        Console.Clear();
                        Console.WriteLine("Wybierz prawidlowa opcje, niedokonano zmian");
                        Console.WriteLine(" ");
                        Menu();
                    }
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
                Console.WriteLine("Najpierw utworz strukture za pomoca DeepDive");
                Console.WriteLine(" ");
                Menu();
            }
        }
    }
}


