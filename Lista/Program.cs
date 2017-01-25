using System;
using System.Collections.Generic;

namespace Lista
{
    internal class Program
    {
        class Węzeł
        {
            public int wartość;
            public Węzeł następny;

            public Węzeł(int wartość)
            {
                this.wartość = wartość;
            }

            public void Wyświet()
            {
                    Console.WriteLine(this.wartość);
            }
        }

        class Lista
        {
            public Węzeł głowa;
            public Węzeł ogon;

            public Lista()
            {
                głowa = null;
                ogon = null;
            }

            public bool Puste()
            {
                if (this.głowa == null)
                    return true;
                return false;
            }

            public void Wyświetl()
            {
                if (Puste()) return;
                for (Węzeł temp = głowa; temp != null; temp = temp.następny)
                {
                    temp.Wyświet();
                }
            }

            public void WyświetlGłowęiOgon()
            {
                Console.WriteLine("Głowa: "+głowa.wartość+", Ogon: "+ogon.wartość);
            }

            public void Dorzuc(int wartość)
            {
                if (Puste()) głowa = new Węzeł(wartość);
                else
                {
                    Węzeł temp = głowa;
                    while (temp.następny != null)
                    {
                        temp = temp.następny;
                    }

                    ogon = temp.następny = new Węzeł(wartość);
                }
            }

            public void Dodaj(int wartość)
            {
                if (Puste()) głowa = new Węzeł(wartość);
                Węzeł temp = głowa;
                while (temp.następny != null)
                {
                    if (temp.następny.wartość > wartość) break;
                    temp = temp.następny;
                }
                if (temp.następny != null)
                {
                    Węzeł q = temp.następny;
                    temp.następny = new Węzeł(wartość);
                    temp.następny.następny = q;
                }
                else ogon = temp.następny = new Węzeł(wartość);
            }

            public void DodajDoGłowy(int wartość)
            {
                Węzeł tmp = głowa;
                głowa = new Węzeł(wartość);
                głowa.następny = tmp;
            }

            public void DodajDoOgona(int wartość)
            {
                Węzeł tmp = ogon;
                ogon = new Węzeł(wartość);
                tmp.następny = ogon;
            }
        }


        public static void Main(string[] args)
        {
            Lista lista = new Lista();

            lista.Dorzuc(1);
            lista.Dorzuc(2);
            lista.Dorzuc(5);
            lista.Dorzuc(10);
            lista.Dorzuc(1);
            lista.Dodaj(100);
            lista.Dodaj(3);
            lista.DodajDoGłowy(5);
            lista.DodajDoOgona(-1);
            lista.Wyświetl();
            lista.WyświetlGłowęiOgon();
        }
    }
}