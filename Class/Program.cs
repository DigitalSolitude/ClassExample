using System.ComponentModel.DataAnnotations;

internal class Program
{
    private static void Main(string[] args)
    {
        Car myCar = new Car();
        myCar.SetDetails();

        Console.WriteLine($"Welcome to your new car, it is a {myCar.Make} " +
            $"from the year {myCar.Year} with the colour {myCar.Colour}");

        myCar.StartDrivingTree();
    }
}