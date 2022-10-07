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
        Random random = new Random();
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
            for (int j = i + 1; j < populace.Count; j++)
            {
                // strašně moc nested ifů kvůli optimalizaci
                if (random.NextSingle() > 0.97)
                {
                    if (random.NextSingle() > 0.97)
                    {
                        if (populace[j].Plodnost && populace[i].Plodnost)
                        {
                            if (populace[j].Gender != populace[i].Gender)
                            {
                                if (populace[i].Age > 18 && populace[j].Age > 18)
                                {
                                    //Hooman babi = new Hooman(0);
                                    // Console.WriteLine(k.Name + " (" + k.Age + ") a " + h.Name + " (" + h.Age + ") se narodilo " + babi.Name + "(" + babi.Gender + ")");
                                    //deti.Add(babi);
                                    deti.Add(new Hooman(0));
                                }
                            }
                        }
                    }
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
        }catch{}

        try
        {
            Console.WriteLine("Chlapů je " + getChlapCount() + " a žen je " + getZenaCount() + ". Celkem je jich " +
                              populace.Count);
        }catch{}

        try
        {
            Console.WriteLine("Lidijo se průměrně dožívaj " + deathAges.Average());
        }catch{}

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