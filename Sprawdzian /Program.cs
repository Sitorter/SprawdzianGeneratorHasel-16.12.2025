namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====Generator Hasla====");
            Console.WriteLine();
            program();
        }

        static void program()
        {
            int dlugosc = podajDlugosc();

            int count = 0;

            sprawdzenie(dlugosc, count);
        }

        static void sprawdzenie(int dlugosc, int count)
        {
            Console.WriteLine("");
            bool czyMale = q1();
            bool czyDuze = q2();
            bool czyCyfry = q3();
            bool czySpec = q4();

            if (!czyMale && !czyDuze && !czyCyfry && !czySpec)
            {
                Console.WriteLine("Chociaz jedna opcja musi byc wybrana!");
                sprawdzenie(dlugosc, count);
            }
            else
            {
                if (czyMale)
                    count++;
                if (czyDuze)
                    count++;
                if (czyCyfry)
                    count++;
                if (czySpec) 
                    count++;
                
                string password = generujHaslo(dlugosc, czyMale, czyDuze, czyCyfry, czySpec);
                Console.WriteLine("====Twoje haslo====");
                ocenahasla(password, count);

                end();


            }
            
        }

        static void end()
        {
            Console.WriteLine("");
            Console.WriteLine("Czy chcesz wygenerowac kolejne haslo? t/n");
            string odp = Console.ReadLine();
            if (odp == "t")
                program();
            if (odp != "t" && odp != "n")
            {
                Console.WriteLine("");
                Console.WriteLine("Zla odpoweidz!");
                end();
            }
                
        }

        static void ocenahasla(string password, int count)
        {
            int score = 0;
            Console.WriteLine("Haslo: "+password);

            if (password.Length >= 10)
                score++;
            if (password.Length >= 16)
                score++;
            if (count > 2 )
                score++;
            if (count == 4)
                score++;

            switch (score)
            {
                case 1:
                    Console.WriteLine("Bardzo slabe haslo");
                    break;
                case 2:
                    Console.WriteLine("Slabe haslo");
                    break;
                case 3:
                    Console.WriteLine("Srednie haslo");
                    break;
                case 4:
                    Console.WriteLine("Silne haslo");
                    break;
                default:
                    Console.WriteLine("Bardzo slabe haslo");
                    break;
            }
        }

        static int podajDlugosc()
        {
            int dlugosc = 0;
            try
            {
                Console.WriteLine("Podaj dlugosc hasla (4-20): ");
                dlugosc = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine("Nie poprawny format, prosze wpisac cyfre!");
                return podajDlugosc();
            }
            
            if (dlugosc >= 4 && dlugosc <= 20)
            {
                return dlugosc;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Zly zakres!");
            }
                
            return podajDlugosc();
        }

        static bool q1()
        {
            Console.Write("Czy chcesz uzyc malych liter? t/n: ");
            string odp = Console.ReadLine();
            if (odp == "t")
                return true;
            if (odp != "t" && odp != "n")
            {
                Console.WriteLine("Nie ma takiej opcji!");
                q1();
            }
                
            
            return false;
        }
        static bool q2()
        {
            Console.Write("Czy chcesz uzyc duzych liter? t/n: ");
            string odp = Console.ReadLine();
            if (odp == "t")
                return true;
            if (odp != "t" && odp != "n")
            {
                Console.WriteLine("Nie ma takiej opcji!");
                q2();
            }
            
            return false;
        }
        static bool q3()
        {
            Console.Write("Czy chcesz uzyc cyfer? t/n: ");
            string odp = Console.ReadLine();
            if (odp == "t")
                return true;
            if (odp != "t" && odp != "n")
            {
                Console.WriteLine("Nie ma takiej opcji!");
                q3();
            }
            
            return false;
        }
        static bool q4()
        {
            Console.Write("Czy chcesz uzyc znakow specjalnych? t/n: ");
            string odp = Console.ReadLine();
            if (odp == "t")
                return true;
            if (odp != "t" && odp != "n")
            {
                Console.WriteLine("Nie ma takiej opcji!");
                q4();
            }
            
            return false;
        }

        static string generujHaslo(int dlugosc,bool czyMale, bool czyDuze, bool czyCyfry, bool czySpec)
        {
            string maleLitery = "abcdefghijklmnoprstuwz";
            string duzeLitery = maleLitery.ToUpper();
            string cyfry = "0123456789";
            string znakiSpec = "!@#$%^&*";

            string password = "";

            string alChars = "";

            if (czyMale)
                alChars += maleLitery;
            
            if (czyDuze)
                alChars += duzeLitery;
            if (czyCyfry)
                alChars += cyfry;
            if (czySpec)
                alChars += znakiSpec;

            for (int i = 1; i <= dlugosc; i++)
            {
                int index = new Random().Next(0, alChars.Length);
                password += alChars[index];
            }


            return password;
        }
    }
}