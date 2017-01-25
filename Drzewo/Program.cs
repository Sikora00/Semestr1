using System;
using System.Collections.Generic;

namespace Drzewo
{
    internal class Program
    {
        class Węzeł
        {
            public int wartość;
            public Węzeł prawy;
            public Węzeł lewy;

            public Węzeł(int wartość)
            {
                this.wartość = wartość;
            }

            public void Dodaj(int wartość)
            {
                if (wartość >= this.wartość)
                {
                    if (this.prawy == null) this.prawy = new Węzeł(wartość);
                    else this.prawy.Dodaj(wartość);
                }
                else
                {
                    if (this.lewy == null) this.lewy = new Węzeł(wartość);
                    else this.lewy.Dodaj(wartość);
                }
            }

            public void Wyświetl()
            {
                if (this.lewy != null) this.lewy.Wyświetl();
                Console.Write(" " + this.wartość);
                if (this.prawy != null) this.prawy.Wyświetl();
            }
        }

        class Drzewo
        {
            public Węzeł korzeń;

            public Drzewo()
            {
                korzeń = null;
            }

            public bool CzyJestKorzeń()
            {
                if (this.korzeń == null) return false;
                else return true;
            }

            public void Dorzuć(int dorzuć)
            {
                if (!CzyJestKorzeń()) korzeń = new Węzeł(dorzuć);
                else
                {
                    korzeń.Dodaj(dorzuć);
                }
            }

            public void Wyświetl()
            {
                korzeń.Wyświetl();
            }
        }

        public static void Main(string[] args)
        {
            Drzewo drzewo = new Drzewo();
            drzewo.Dorzuć(8);
            drzewo.Dorzuć(3);
            drzewo.Dorzuć(10);
            drzewo.Dorzuć(1);
            drzewo.Dorzuć(6);
            drzewo.Dorzuć(4);
            drzewo.Dorzuć(7);
            drzewo.Dorzuć(14);
            drzewo.Dorzuć(13);
            drzewo.Wyświetl();
        }
    }
}