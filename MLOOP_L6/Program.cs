using System;

public class NumberPair
{
    protected double first;
    protected double second;

    public NumberPair()
    {
        first = 0.0;
        second = 0.0;
    }

    public NumberPair(double first, double second)
    {
        this.first = first;
        this.second = second;
    }

    public double First
    {
        get { return first; }
        set { first = value; }
    }

    public double Second
    {
        get { return second; }
        set { second = value; }
    }

    public void SetValues(double first, double second)
    {
        this.first = first;
        this.second = second;
    }

    public virtual double GetProduct()
    {
        return first * second;
    }

    public virtual void Display()
    {
        Console.WriteLine($"Перше число: {first}, Друге число: {second}");
    }
}

public class RightTriangle : NumberPair
{
    public RightTriangle() : base()
    {
    }

    public RightTriangle(double cathetus1, double cathetus2) : base(cathetus1, cathetus2)
    {
        if (cathetus1 <= 0 || cathetus2 <= 0)
        {
            throw new ArgumentException("Катети трикутника повинні бути додатними числами!");
        }
    }

    public double Cathetus1
    {
        get { return first; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Катет повинен бути додатним числом!");
            first = value;
        }
    }

    public double Cathetus2
    {
        get { return second; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Катет повинен бути додатним числом!");
            second = value;
        }
    }

    public double GetHypotenuse()
    {
        return Math.Sqrt(first * first + second * second);
    }

    public double GetArea()
    {
        return (first * second) / 2.0;
    }

    public override void Display()
    {
        Console.WriteLine($"Прямокутний трикутник:");
        Console.WriteLine($"Катет 1: {first}");
        Console.WriteLine($"Катет 2: {second}");
        Console.WriteLine($"Гіпотенуза: {GetHypotenuse():F2}");
        Console.WriteLine($"Площа: {GetArea():F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Демонстрація роботи з класом NumberPair ===");

        NumberPair pair = new NumberPair(5.0, 3.0);
        pair.Display();
        Console.WriteLine($"Добуток чисел: {pair.GetProduct()}");

        pair.SetValues(7.0, 2.0);
        Console.WriteLine("\nПісля зміни значень:");
        pair.Display();
        Console.WriteLine($"Добуток чисел: {pair.GetProduct()}");

        Console.WriteLine("\n=== Демонстрація роботи з класом RightTriangle ===");

        try
        {
            RightTriangle triangle = new RightTriangle(3.0, 4.0);
            triangle.Display();

            Console.WriteLine("\nЗміна розмірів трикутника:");
            triangle.Cathetus1 = 5.0;
            triangle.Cathetus2 = 12.0;
            triangle.Display();

            Console.WriteLine($"\nДобуток катетів: {triangle.GetProduct()}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }
}