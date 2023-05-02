using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть кількість сторін: ");
        int sides = int.Parse(Console.ReadLine());

        Console.Write("Введіть довжину однієї сторони: ");
        double length = double.Parse(Console.ReadLine());

        RegularPolygon polygon = RegularPolygon.Create(sides, length);

        Console.WriteLine("{0}-сторони багатокутника: периметр={1}, площа={2}, внутрішній кут={3} градусів", sides, polygon.GetPerimeter(), polygon.GetArea(), polygon.GetInteriorAngle());
    }
}

abstract class RegularPolygon
{
    protected int numSides;
    protected double sideLength;

    public RegularPolygon(int numSides, double sideLength)
    {
        this.numSides = numSides;
        this.sideLength = sideLength;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();
    public virtual double GetInteriorAngle()
    {
        return (numSides - 2) * 180.0 / numSides;
    }

    public static RegularPolygon Create(int numSides, double sideLength)
    {
        RegularPolygon polygon = null;

        switch (numSides)
        {
            case 3:
                polygon = new Triangle(sideLength);
                break;
            case 4:
                polygon = new Square(sideLength);
                break;
            case 8:
                polygon = new Octagon(sideLength);
                break;
            default:
                Console.WriteLine("Ця фігура не прописана в програмі.");
                break;
        }


        return polygon;
    }
}

class Triangle : RegularPolygon
{
    public Triangle(double sideLength) : base(3, sideLength) { }

    public override double GetArea()
    {
        return (sideLength * sideLength * Math.Sqrt(3)) / 4;
    }

    public override double GetPerimeter()
    {
        return 3 * sideLength;
    }
}

class Square : RegularPolygon
{
    public Square(double sideLength) : base(4, sideLength) { }

    public override double GetArea()
    {
        return sideLength * sideLength;
    }

    public override double GetPerimeter()
    {
        return 4 * sideLength;
    }
}

class Octagon : RegularPolygon
{
    public Octagon(double sideLength) : base(8, sideLength) { }

    public override double GetArea()
    {
        return 2 * (1 + Math.Sqrt(2)) * sideLength * sideLength;
    }

    public override double GetPerimeter()
    {
        return 8 * sideLength;
    }
}
