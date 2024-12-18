namespace _02_ZakladySyntaxe
{
    class Program
    {
        static void Main(string[] args)
        {
            // jednoradkovy komentar

            /*
            viceradkovy
            komentar
            */

            Console.WriteLine("Výpis s ukončeným řádkem.");
            Console.Write("Výpis s neukončeným řádkem.");
            Console.WriteLine("Tohle bude přilepené k předchozímu výpisu.");

            // DATOVE TYPY
            Console.WriteLine("ABC"); // string (retezec znaku)
            Console.WriteLine('A'); // char (character, jednotlivy znak)

            Console.WriteLine(true); // bool (pravdivost)
            Console.WriteLine(false); // taky bool

            Console.WriteLine(3.14); // double (float se zdvojenou presnosti)
            Console.WriteLine(3.14f); // float (obycejny, v C# malo pouzivany)

            Console.WriteLine(123); // int (integer, cele cislo, rozsah cca +- 2 mld.)
            Console.WriteLine(6868546544842984268L); // long (dlouhy integer, 16 exa moznosti)
            Console.WriteLine(45u); // uint (unsigned integer, nezaporne cele cislo)

            // PROMENNE
            int x; // deklarace
            x = 5; // inicializace
            Console.WriteLine(x); // pouziti

            string y = "ahoj"; // deklarace + inicializace
            bool u, v; // obe promenne jsou typu bool

            // OPERATORY
            // + - * /
            // % je zbytek po deleni
            // pozor na obycejne deleni
            Console.WriteLine(x / 2); // 5 / 2 => 2
            // booleovske operatory...
            u = true; v = false;
            Console.WriteLine(u && v); // and
            Console.WriteLine(u || v); // or
            Console.WriteLine(!u); // not

            // DATOVE STRUKTURY

            // pole
            int[] poleCisel; // deklarace
            poleCisel = new int[10]; // vytvoreni (objektu)

            int[] jinePoleCisel = new int[] { 2, 9, -1 }; // stanoveni prvku pole
            int[] jesteJinePoleCisel = { 0, 1, 2 }; // zkraceny zapis

            // poleCisel je nyni plne nul
            Console.WriteLine(poleCisel); // neuzitecne
            Console.WriteLine(poleCisel[0]); // indexovani pole
            Console.WriteLine(poleCisel[6]);
            Console.WriteLine(poleCisel[9]); // posledni prvek

            // struct (pouziti)
            Osoba o; // deklarace
            o.Jmeno = "Jakub"; // definice prvku
            o.Prijmeni = "Šenkýř"; // definice prvku
            o.Vek = 40; // definice prvku

            Console.WriteLine(o.Jmeno + " " + o.Prijmeni);

            // seznam
            List<int> seznamCisel; // deklarace
            seznamCisel = new List<int>(); // vytvoreni

            // seznam je nyni prazdny

            seznamCisel.Add(15);
            seznamCisel.Add(20);
            seznamCisel.Add(30);

            Console.WriteLine(seznamCisel); // neuzitecne
            Console.WriteLine(seznamCisel[1]); // indexovani seznamu

            // pole i seznam znaji pocet svych prvku
            Console.WriteLine(poleCisel.Length);
            Console.WriteLine(seznamCisel.Count);

            // RIDICI STRUKTURY
            u = v = true;
            v = !u;

            // vetveni
            if (u == v)
            {
                Console.WriteLine("u se rovná v");
                Console.WriteLine("rovný rovného si hledá");
            }
            else if (u != v)
            {
                Console.WriteLine("u se nerovná v");
            }
            else
            {
                Console.WriteLine("toto se nikdy nevypíše");
            }

            // podmineny cyklus s podminkou na zacatku
            while (x > 0)
            {
                Console.WriteLine(x);
                // x = x - 1
                // x -= 1
                // x--;
                // --x;

                x -= 1;
            }

            Console.WriteLine();
            x = 0;

            // podmineny cyklus s podminkou na konci
            do
            {
                Console.WriteLine(x);
                x -= 1;
            } while (x > 0); // <-- hle! strednik

            // cyklus for (zkraceny cyklus while)

            int w = 0;
            while (w < 10)
            {
                Console.WriteLine("ahoj");
                w += 1;
            }

            for (int z = 0; z < 10; z++) // for jako pocitany cyklus
            {
                Console.WriteLine("ahoj");
            }

            for (int z = 0; z < 10; z++) // for pro indexaci pole
            {
                Console.WriteLine(poleCisel[z]);
            }

            for (int z = 0; z < seznamCisel.Count; z++)
            {
                Console.WriteLine(seznamCisel[z]);
            }

            // cyklus foreach

            foreach (int cislo in poleCisel) // pro prochazeni pole
            {
                Console.WriteLine(cislo);
            }

            foreach (int cislo in seznamCisel) // pro prochazeni seznamu
            {
                Console.Write(cislo);
                Console.Write(' ');
            }
            Console.WriteLine();

            // spusteni podprogramu
            Pozdrav();
            Pozdrav("pane");
            Console.WriteLine(Faktorial(5));

            // NACITANI HODNOT OD UZIVATELE

            // nacteni vseho az do stisku Enteru
            string zadani = Console.ReadLine();
            Console.WriteLine(zadani);

            // konverze typu
            Console.Write("Zadej celé číslo: ");
            zadani = Console.ReadLine();

            int zadaneCislo;
            zadaneCislo = Convert.ToInt32(zadani);

            Console.WriteLine("Číslo následující za tvým číslem je " + (zadaneCislo + 1));

            // PRACE SE SOUBORY
            // nacteni obsahu souboru
            string obsahSouboru = File.ReadAllText(@"data\uzivatele.txt");
            Console.WriteLine(obsahSouboru);
            // nacteni obsahu souboru po radcich
            string[] radkySouboru = File.ReadAllLines(@"data\uzivatele.txt");

            // uprava radku
            radkySouboru[1] = "Jakub Lattenberg";

            // zpracovani po radcich
            foreach (string radek in radkySouboru)
            {
                // rozebrani radku na prvky oddelene mezerou
                string[] jmenoPrijmeni = radek.Split(' ');
                // upraveny vypis do konzoly
                Console.WriteLine($"Jméno: {jmenoPrijmeni[0]} | Příjmení: {jmenoPrijmeni[1]}");
            }

            // zapis vsech radku do souboru (do jeho pracovni kopie)
            File.WriteAllLines(@"data\uzivatele.txt", radkySouboru);

            // jak udelat nahodu
            Random mojeNahoda = new Random();

            // vygenerujeme tisic nahodnych cisel
            for(int i = 0; i < 1000; i++)
            {
                // nahodne cislo od 1 do 9
                int nahodneCislo = mojeNahoda.Next(1, 10);

                // vypis do radku
                Console.Write(nahodneCislo + " ");
            }
            Console.WriteLine();
        }

        // struct (definice)
        struct Osoba
        {
            public string Jmeno;
            public string Prijmeni;
            public uint Vek;
        }

        // PODPROGRAMY

        // procedura (nevraci hodnotu, navratovy typ "void")
        // bez parametru
        static void Pozdrav()
        {
            Console.WriteLine("Dobrý den!");
        }
        // s parametrem
        static void Pozdrav(string osloveni)
        {
            Console.WriteLine($"Dobrý den, {osloveni}!");
        }

        // funkce (maji navratovou hodnotu a tedy i typ)
        static long Faktorial(long n)
        {
            if(n == 0)
            {
                return 1;
            }
            else
            {
                return n * Faktorial(n - 1);
            }
        }
    }
}
