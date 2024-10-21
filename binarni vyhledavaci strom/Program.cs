using System;
using System.Collections.Generic;

namespace MyApp
{
    internal class Program
    {
        public static Vrchol Root = null;

        static void Main(string[] args)
        {
            Console.WriteLine("zadejte metodu");
            string metoda = Console.ReadLine();

            switch (metoda)
            {
                case "vlozit":
                    int hodnota = int.Parse(Console.ReadLine());
                    Novy(hodnota);
                    break;

                case "najdi":

                    break;
                case "odstran":

                    break;
                case "vypis":

                    break;
                case "minimum":

                    break;
                default:
                    Console.WriteLine("neplatna metoda");
                    break;
            }
        }

        public static void Novy(int hodnota)
        {
            Vrchol novyVrchol = new Vrchol(hodnota);

            if (Root == null)
            {
                Root = novyVrchol;
            }
            else
            {
                Insert(Root, novyVrchol);
            }
        }

        private static void Insert(Vrchol current, Vrchol newNode)
        {
            if (newNode.Hodnota < current.Hodnota)
            {
                if (current.children == null)
                {
                    current.children = newNode;
                    newNode.parent = current;
                }
                else
                {
                    Insert(current.children, newNode);
                }
            }
            else
            {
                if (current.parent == null)
                {
                    current.parent = newNode;
                    newNode.children = current;
                    Root = newNode;
                }
                else if (current.parent.Hodnota < newNode.Hodnota)
                {
                    if (current.parent.children == current)
                    {
                        current.parent.children = newNode;
                    }
                    else
                    {
                        current.parent.parent = newNode;
                    }
                    newNode.children = current;
                    newNode.parent = current.parent;
                    current.parent = newNode;
                }
                else
                {
                    Insert(current.parent, newNode);
                }
            }
        }
    }

    class Vrchol
    {
        public int Hodnota;
        public List<Vrchol> children;
        public Vrchol parent;

        public Vrchol(int hodnota)
        {
            Hodnota = hodnota;
        }
    }
}