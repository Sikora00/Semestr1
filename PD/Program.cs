using System;
using System.Collections.Generic;
using System.IO;

namespace PD
{
    internal class Program
    {
        static int jeden(int[] tab)
        {
            int średnia = 0;
            for (int i = 0; i <= tab.Length - 1; i++)
            {
                średnia += tab[i];
            }
            Console.WriteLine(średnia + ", " + tab.Length);
            średnia = średnia / tab.Length;
            Console.WriteLine(średnia);
            int ile = 0;
            for (int d = 0; d < tab.Length - 1; d++)
            {
                if (tab[d] <= średnia) ile++;
            }
            return ile;
        }

        static void dwa(int[] tab)
        {
            int dwu = 0, czter = 0;
            int d = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                d = 0;
                while (tab[i] != 0)
                {
                    d++;
                    tab[i] = tab[i] / 10;
                }
                if (d == 2) dwu++;
                if (d == 4) czter++;
            }
            if (dwu > czter) Console.WriteLine("Więcej jest dwucyfrowych");
            if (dwu < czter) Console.WriteLine("Wiecej jest czterocyfrowych");
            if (dwu == czter) Console.WriteLine("Jest ich tyle samo");
        }

        static void trzy(string tekst)
        {
            int liter = 0, liczb = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if ((tekst[i] >= 'a' && tekst[i] <= 'z') || (tekst[i] >= 'A' && tekst[i] <= 'Z')) liter++;
                if (tekst[i] >= '0' && tekst[i] <= '9') liczb++;
            }
            if (liter > liczb) Console.WriteLine("Liter jest więcej");
            else if (liczb > liter) Console.WriteLine("Liczb jest więcej");
            else Console.WriteLine("jest Ich tyle samo");
        }

        static void cztery(int[] tab)
        {
            int średnia1 = 0, średnia2 = 0;
            for (int i = 0; i < tab.Length / 2; i++)
            {
                średnia1 += tab[i];
            }
            średnia1 = średnia1 / (tab.Length / 2);
            for (int i = tab.Length-1; i > tab.Length / 2; i--)
            {
                średnia2 += tab[i];
            }
            średnia2 = średnia2 / (tab.Length / 2);
            if(średnia1==średnia2) Console.WriteLine("Średnie są takie same");
            if(średnia1>średnia2) Console.WriteLine("średnia1 jest większa");
            if(średnia2>średnia1) Console.WriteLine("średnia2 jest większa");
        }

        static int piąte(int[] tab)
        {
            int ile = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                while (tab[i] > 10)
                {
                    tab[i] = tab[i] / 10;
                }
                if (tab[i] == 7) ile++;
            }
            return ile;
        }

        static bool czy_pierwsza(int liczba)
        {
            if (liczba == 0 || liczba == 1) return false;
            if (liczba == 2) return true;
            for (int i = 2; i < liczba; i++)
            {
                if (liczba % i == 0) return false;
            }
            return true;
        }

        static void dwunaste(int[] tab)
        {
            double średnia = 0, ile = 0;
            for (int i = 0; i < tab.Length; i++)
            {
                Console.WriteLine(czy_pierwsza(tab[i]));
                if (czy_pierwsza(tab[i]))
                {
                    średnia += (double)tab[i];
                    ile++;
                }
            }
            średnia = średnia / ile;
            Console.WriteLine("Liczb pierwszych jest: "+ile+", a ich średnia wynosi: "+średnia);
        }

        //Stwórz funkcję double Pomnoz2(double[] tab, int i), która dokonuje rekurencyjnego mnożenia elementów tablicy podzielnych przez 7 lub 3.
        static double Pomnoz2(double[] tab, int i)
        {
            double mnożenie;
            if (i == tab.Length) return 1;
            if (tab[i] % 3 == 0 || tab[i] % 7 == 0) mnożenie = tab[i] * Pomnoz2(tab, i + 1);
            else return 1;
            return mnożenie;
        }

        //Stwórz funkcję string Konwersja(int system1, int system2, string liczba), która dokonuje konwersji liczby z dowolnego systemu system1 (od 2 do 16)
        //na dowolny system system2 (od 2 do 16).
        //Liczbę należy wprowadzić i zwrócić w postaci string - bez zer wiodących, bez odstępów między znakami.
        static string Konwersja(int system1, int system2, string liczba)
        {
            int nowa;
            string pomoc = "";
            if (system1 != 10)
            {
                nowa = NaDziesiętny(system1, liczba);
            }
            else nowa = Convert.ToInt32(liczba);

            while (nowa != 0)
            {
                if (nowa % system2 < 10) pomoc += Convert.ToString(nowa % system2);
                else
                {
                    char pom = Convert.ToChar(nowa % system2 - 10 + 'A');
                    pomoc += Convert.ToString(pom);
                }
                nowa = nowa / system2;
            }
            liczba = Odwróć(pomoc);
            return liczba;
        }

        static string Odwróć(string liczba)
        {
            string liczba2="";
            for (int i = 1; i <= liczba.Length; i++)
            {
                liczba2 += liczba[liczba.Length - i];
            }
            return liczba2;
        }
        static int NaDziesiętny(int system, string liczba)
        {
            string nowa = "";
            int dziesiętna = 0;
            for (int i = 0; i < liczba.Length; i++)
            {
             if(liczba[i]<='9')   dziesiętna += (Convert.ToInt32(liczba[i])-'0') * (int)Math.Pow(system, liczba.Length - 1-i);
                if(liczba[i]>='A')  dziesiętna += (Convert.ToInt32(liczba[i])-'A' + 10) * (int)Math.Pow(system, liczba.Length - 1-i);
            }
            nowa = Convert.ToString(dziesiętna);
            return dziesiętna;
        }

        //Stwórz strukturę Adres o polach: ulica, numer, kod pocztowy. Stwórz strukturę Klient o polach:
        //Adres adres, string imię, string nazwisko.
        //Dodaj do obydwu struktur konstruktor, funkcję wyświetlającą informacje o strukturze na ekran oraz zapisującą i odczytującą dane do/z pliku.
      /*  struct Adres
        {
            public string ulica, kod_pocztowy, plik;
            public int numer;

            public Adres(string ulica, string kod_pocztowy, int numer)
            {
                this.ulica = ulica;
                this.kod_pocztowy = kod_pocztowy;
                this.numer = numer;
            }

            public void Wyświetl()
            {
                Console.WriteLine("Adres: Ulica : {0}, Kod pocztowy : {1}, Numer: {2}", this.ulica, this.kod_pocztowy, this.numer);
            }

            public void Zapisz(string plik)
            {
                StreamWriter sw = new StreamWriter(plik);
                this.plik = plik;
                sw.WriteLine(this.ulica);
                sw.WriteLine(this.kod_pocztowy);
                sw.WriteLine(this.numer);
                sw.Close();
            }

            public void Odczyt()
            {
                StreamReader sr = new StreamReader(this.plik);
                this.ulica = sr.ReadLine();
                this.kod_pocztowy = sr.ReadLine();
                this.numer = Convert.ToInt32(sr.ReadLine());
                sr.Close();
            }
        }
/*
        struct Klient
        {
            public string imię, nazwisko, plik;
            public Adres adres;

            public Klient(string imię, string nazwisko, Adres adres)
            {
                this.imię = imię;
                this.nazwisko = nazwisko;
                this.adres = adres;
            }

            public void Wyświetl()
            {
                Console.WriteLine("Klient: Imię : "+this.imię+", Nazwisko : "+this.nazwisko);
                this.adres.Wyświetl();
            }

            public void Zapisz(string plik)
            {
                StreamWriter sw = new StreamWriter(plik);
                this.plik = plik;
                sw.WriteLine(this.imię);
                sw.WriteLine(this.nazwisko);
                sw.WriteLine(adres.ulica);
                sw.WriteLine(adres.kod_pocztowy);
                sw.WriteLine(adres.numer);
                sw.Close();
            }

            public void Odczyt()
            {
                StreamReader sr = new StreamReader(this.plik);
                this.imię = sr.ReadLine();
                this.nazwisko = sr.ReadLine();
                string ulica = sr.ReadLine();
                string kod = sr.ReadLine();
                int numer = Convert.ToInt32(sr.ReadLine());
                this.adres = new Adres(ulica,kod,numer);
                sr.Close();
            }
        }
*/
        public static void Main(string[] args)
        {
            /*int[] tab = {10, 25, 30, 0, 100};
            Console.WriteLine("dla tablicy {10, 25, 30,0, 100} liczb mniejszych od średniej jest: "+jeden(tab));
            int[] tab = {12, 2323, 12, 23234, 1, 22, 2525, 12, 2222, 2222, 2222};
            dwa(tab);
            string tekst = "Tekst 123456";
            trzy(tekst);
            int[] tab = {2222, 2222, 2222, 2222, 2222, 1, 2222, 2222, 2222, 2222, 2222};
            cztery(tab);
            int[] tab = {7, 77, 457, 45567, 7000000};
            Console.WriteLine(piąte(tab));
            int[] tab = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
            dwunaste(tab);
            double[] tab = {3, 7, 6, 1, 3};
            Console.WriteLine(Pomnoz2(tab, 0));*/
            string liczba = "A";
            Console.WriteLine(Konwersja(16, 10, liczba));/*
            Adres adres1 = new Adres("Mickiewicza 2", "08-110", 64562487);
            Klient klient1 = new Klient("Maciej", "Sikorski", adres1);
            klient1.Wyświetl();*/
        }
    }
}