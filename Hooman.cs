using System.Text;

namespace Planeta;

public class Hooman
{
    private String name;
    private readonly bool gender;
    private int age;
    private bool plodnost;

    public bool Gender => gender;
    public string Name => name;
    public int Age => age;
    public bool Plodnost => plodnost;

    public Hooman(int age)
    {
        name = randomMeno(3);
        gender = new Random().NextSingle() > 0.5;
        this.age = age;
        plodnost = true;
    }
    
    public Hooman()
    {
        name = randomMeno(3);
        gender = new Random().NextSingle() > 0.5;
        this.age = new Random().Next(0, 99);
        plodnost = new Random().NextSingle() > 0.5;
    }
    
    private string randomMeno(int wordSize)
    {
        string ven = "";
        StringBuilder borek = new StringBuilder();
        Random random = new Random();

        borek.Append((char)(random.NextDouble() * (90 - 65) + 65));
        for (int j = 0; j < wordSize; j++)
        {
            borek.Append((char)(random.NextDouble() * (122 - 97) + 97));
        }

        ven = borek.ToString();

        return ven;
    }

    public bool BdayMoment()
    {
        age++;
        if (new Random().NextSingle() * age / 100 > 0.75)
        {
            plodnost = false;
        }
        
        return new Random().NextSingle() * age / 100 > 0.05;
    }
}