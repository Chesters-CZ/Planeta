using System.Runtime.InteropServices.ComTypes;

namespace Planeta;

public class Zemnje
{
    private List<Hooman> populace = new List<Hooman>();
    private int age = 0;
    private List<int> deathAges = new List<int>();

    public int PopCount()
    {
        return populace.Count;
    }

    public Zemnje(int PopCount = 70000)
    {
        for (int i = 0; i < PopCount; i++)
        {
            populace.Add(new Hooman());
        }
    }

    public void Spin()
    {
        age++;
        List<Hooman> deti = new List<Hooman>();

        Console.WriteLine("Umírám lidi");
        int dead = 0;
        for (int i = 0; i < populace.Count; i++)
        {
            Hooman h = populace[i];
            if (h.BdayMoment())
            {
                // Console.WriteLine(h.Name + " umřel ve věku " + h.Age);
                deathAges.Add(h.Age);
                populace.Remove(h);
                dead++;
            }
        }

        Console.WriteLine("Umřelo " + dead + " lidí");

        Console.WriteLine("Pářim lidi...");
        for (int i = 0; i < populace.Count; i++)
        {
            Hooman h = populace[i];


            for (int j = 0; j < populace.Count; j++)
            {
                var k = populace[j];
                if (k.Gender != h.Gender && k.Plodnost && h.Plodnost && h.Age > 18 && k.Age > 18 &&
                    new Random().Next() > 0.999)
                {
                    Hooman babi = new Hooman(0);
                    // Console.WriteLine(k.Name + " (" + k.Age + ") a " + h.Name + " (" + h.Age + ") se narodilo " + babi.Name + "(" + babi.Gender + ")");
                    deti.Add(babi);
                }
            }
        }

        Console.WriteLine("Spářeno. Přidávám " + deti.Count + " do populace");
        foreach (Hooman dite in deti)
        {
            populace.Add(dite);
        }

        Console.WriteLine("Přidáno.");

        stats();
    }

    private void stats()
    {
        Console.WriteLine("Končí rok " + age);
        try
        {
            Console.WriteLine("Lidem je průměrně " + getAvgPopsAge() + " a průměrnému člověkovi je " + getMedPopsAge());
        }
        finally
        {
        }
        try
        {
            Console.WriteLine("Chlapů je " + getChlapCount() + " a žen je " + getZenaCount());
        }
        finally
        {
        }

        try
        {
            Console.WriteLine("Lidijo se průměrně dožívaj " + deathAges.Average());
        }
        finally
        {
        }

        Thread.Sleep(1500);
    }

    private double getAvgPopsAge()
    {
        List<int> ages = new List<int>();
        foreach (Hooman h in populace)
        {
            ages.Add(h.Age);
        }

        return ages.Average();
    }

    private int getMedPopsAge()
    {
        List<int> ages = new List<int>();
        foreach (Hooman h in populace)
        {
            ages.Add(h.Age);
        }

        ages.Sort();
        return ages[(int)ages.Count / 2];
    }

    private int getChlapCount()
    {
        int chlapu = 0;
        foreach (Hooman h in populace)
        {
            if (h.Gender)
            {
                chlapu++;
            }
        }

        return chlapu;
    }

    private int getZenaCount()
    {
        int zen = 0;
        foreach (Hooman h in populace)
        {
            if (!h.Gender)
            {
                zen++;
            }
        }

        return zen;
    }
}