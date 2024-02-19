using System.Runtime.CompilerServices;

public class Car
{
    public string Colour;
    public string Make;
    public int Year;
    public bool Works;
    public int Speed;

    public void SetDetails()
    {
        SetColour();
        SetMake();
        SetYear();
    }

    private void StartEngine()
    {
        if (this.Works)
        {
            Console.WriteLine($"The {this.Make} from {this.Year} goes vroom vroom");
            this.Speed = 10;
        }
        if (!this.Works)
        {
            Console.WriteLine($"The {this.Make} from {this.Year} goes KABOOM!!!!");
            this.Speed = 0;
        }
    }

    private void Accelerate()
    {
        if (!this.Works) 
        {
            Console.WriteLine($"The {this.Make} is broken");
            CarBrokenTree();
        }
        this.Speed += 10;
        Console.WriteLine($"The {this.Make} is speeding up...");
        Console.WriteLine($"Current speed is {this.Speed}kph");
        if (this.Speed > 40)
        {
            Console.WriteLine($"The {this.Make} was going too fast and damaged the engine");
            this.Works = false;
            CarBrokenTree();
        }
        AccelerateBrakeTree();
    }

    private void Brake()
    {
        this.Speed -= 10;
        Console.WriteLine($"The {this.Make} is slowing down...");
        Console.WriteLine($"Current speed is {this.Speed}kph");
        if (this.Speed == 0)
        {
            Console.WriteLine($"The {this.Make} is stopped");
        }
        AccelerateBrakeTree();
    }

    private void FixCar()
    {
        this.Works = true;
    }

    private void AccelerateBrakeTree()
    {
        Console.WriteLine("Would you like to speed up or slow down?");
        Console.WriteLine("Type 1 for Accelerate");
        Console.WriteLine("Type 2 for Brake");
        var decision = Console.ReadLine();
        if (decision == "1") this.Accelerate();
        else if (decision == "2") this.Brake();
        else
        {
            Console.WriteLine("That isn't a valid input!");
            AccelerateBrakeTree();
        }
    }

    private void CarBrokenTree()
    {
        Console.WriteLine($"This {this.Make} is broken!");
        Console.WriteLine("Would you like to fix it? Y/N");
        var fix = Console.ReadLine();
        if (fix.ToLower() == "y")
        {
            this.FixCar();
            StartDrivingTree();
        }
        else
        {
            Console.WriteLine("OK! Let me know if you'd like to fix it");
            CarBrokenTree();
        }

    }

    private void SetColour()
    {
        Console.WriteLine("What colour is your car");
        this.Colour = Console.ReadLine();
        if (this.Colour != String.Empty)
        {
            return;
        }
        Console.WriteLine("You need to select a colour!");
        SetColour();
    }

    private void SetMake()
    {
        Console.WriteLine("What make is your car?");
        this.Make = Console.ReadLine();
        if (this.Make != String.Empty)
        {
            return;
        }
        Console.WriteLine("You need to select a make!");
        SetMake();
    }

    private void SetYear()
    {
        Console.WriteLine("What year is your car?");
        Int32.TryParse(Console.ReadLine(), out this.Year);
        if (this.Year != null && this.Year <= DateTime.Today.Year && this.Year > 1900)
        {
            return;
        }
        Console.WriteLine("You need to select a valid year!");
        SetYear();
    }

    public void StartDrivingTree()
    {
        Console.WriteLine("Would you like to start driving?");
        Console.WriteLine("Type Y/N");
        var driving = Console.ReadLine();
        if (driving.ToLower() == "n")
        {
            Console.WriteLine("Ok, let me know when you would like to start driving");
            this.StartDrivingTree();
        }
        else if (driving.ToLower() != "y")
        {
            Console.WriteLine("That wasn't a Y/N!");
            this.StartDrivingTree();
        }
        this.StartEngine();
        if (this.Works) AccelerateBrakeTree();
        else { CarBrokenTree(); }
    }
}