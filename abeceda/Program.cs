using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Zadejte slova:");
        string input = Console.ReadLine();
        string[] slova = input.Split(' ');

        List<char> znaky = new List<char>();
        foreach (var slovo in slova)
        {
            foreach (var znak in slovo)
            {
                if (!znaky.Contains(znak))
                {
                    znaky.Add(znak);
                }
            }
        }

        Dictionary<char, List<char>> graf = new Dictionary<char, List<char>>();
        Dictionary<char, int> stupen = new Dictionary<char, int>();

        foreach (char znak in znaky)
        {
            graf[znak] = new List<char>();
            stupen[znak] = 0;
        }

        for (int i = 0; i < slova.Length - 1; i++)
        {
            string slovo1 = slova[i];
            string slovo2 = slova[i + 1];

            for (int j = 0; j < Math.Min(slovo1.Length, slovo2.Length); j++)
            {
                if (slovo1[j] != slovo2[j])
                {
                    char u = slovo1[j];
                    char v = slovo2[j];

                    if (!graf[u].Contains(v))
                    {
                        graf[u].Add(v);
                        stupen[v]++;
                    }
                    break;
                }
            }
        }

        Queue<char> fronta = new Queue<char>();
        List<char> poradi = new List<char>();

        foreach (var znak in stupen.Keys)
        {
            if (stupen[znak] == 0)
            {
                fronta.Enqueue(znak);
            }
        }

        while (fronta.Count > 0)
        {
            char u = fronta.Dequeue();
            poradi.Add(u);

            foreach (var v in graf[u])
            {
                stupen[v]--;
                if (stupen[v] == 0)
                {
                    fronta.Enqueue(v);
                }
            }
        }

        if (poradi.Count == znaky.Count)
        {
            Console.WriteLine("Pořadí znaků: " + string.Join(" -> ", poradi));
        }
        else
        {
            Console.WriteLine("Není možné určit jednoznačné pořadí znaků.");
        }
    }
}
