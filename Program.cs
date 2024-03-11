using System;
using System.Collections.Generic;

// Клас, що представляє костюм
class Costume
{
    public string Name { get; set; }

    public void Dress()
    {
        Console.WriteLine($"Актор вдягнутий в костюм {Name}.");
    }
}

// Фабрика для створення костюмів
class CostumeFactory
{
    private readonly Dictionary<string, Costume> _costumes = new Dictionary<string, Costume>();

    public Costume GetCostume(string name)
    {
        if (!_costumes.ContainsKey(name))
        {
            _costumes[name] = new Costume { Name = name };
        }
        return _costumes[name];
    }
}

// Клас, що представляє актора
class Actor
{
    public string Name { get; set; }
    private List<Costume> _costumes = new List<Costume>();

    // Метод для додавання костюмів
    public void AddCostume(Costume costume)
    {
        _costumes.Add(costume);
    }

    // Метод для використання костюмів актором
    public void ParticipateInScene()
    {
        Console.WriteLine($"Виступ актора {Name}:");
        foreach (var costume in _costumes)
        {
            costume.Dress();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        CostumeFactory costumeFactory = new CostumeFactory();

        // Створення різних костюмів
        Costume cs1 = costumeFactory.GetCostume("Джульєтта");
        Costume cs2 = costumeFactory.GetCostume("Розалiна");

        // Створення акторів
        Actor Kate = new Actor { Name = "Катя" };
        Actor Anastasia = new Actor { Name = "Настя" };

        // Додавання костюмів для акторів
        Kate.AddCostume(cs1);
        Anastasia.AddCostume(cs2);
        Kate.AddCostume(cs2);

        // Актори беруть участь у сцені
        Kate.ParticipateInScene();
        Anastasia.ParticipateInScene();
    }
}