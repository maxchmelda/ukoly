using System;
using System.Collections.Generic;

class Prvek
{
    public int Hodnota;
    public int Index;

    public Prvek(int hodnota, int index)
    {
        Hodnota = hodnota;
        Index = index;
    }
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Počet prvků?");
        string input = Console.ReadLine();
        int n = int.Parse(input);

        List<Prvek> X = new List<Prvek>();

        Console.WriteLine("Zadejte prvky");
        for (int i = 0; i < n; i++)
        {
            input = Console.ReadLine();
            int hodnota = int.Parse(input);

            Prvek novyPrvek = new Prvek(hodnota, i);
            X.Add(novyPrvek);
        }

        Console.WriteLine("Původní posloupnost:");
        for (int i = 0; i < X.Count; i++)
        {
            Console.Write(X[i].Hodnota + " ");
        }
        Console.WriteLine();

        QuickSort(X, 0, X.Count - 1);

        Console.WriteLine("Seřazená posloupnost:");
        for (int i = 0; i < X.Count; i++)
        {
            Console.Write(X[i].Hodnota + " ");
        }
    }

    static void QuickSort(List<Prvek> posloupnost, int min, int max)
    {
        if (min < max)
        {
            int p = Rozdel(posloupnost, min, max);
            QuickSort(posloupnost, min, p - 1);
            QuickSort(posloupnost, p + 1, max);
        }
    }

    static int Rozdel(List<Prvek> posloupnost, int min, int max)
    {
        Prvek pivot = posloupnost[max];
        int i = min - 1;

        for (int j = min; j < max; j++)
        {
            if (posloupnost[j].Hodnota < pivot.Hodnota)
            {
                i++;
                Prvek temp = posloupnost[i];
                posloupnost[i] = posloupnost[j];
                posloupnost[j] = temp;
            }
        }

        Prvek tempPivot = posloupnost[i + 1];
        posloupnost[i + 1] = posloupnost[max];
        posloupnost[max] = tempPivot;

        return i + 1;
    }
}
