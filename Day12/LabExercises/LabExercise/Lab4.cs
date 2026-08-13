using System;

// -----------------------------------------
// IVehicle Interface
// -----------------------------------------

public interface IVehicle
{
    string Model { get; }

    void Drive();
}


// -----------------------------------------
// IElectric Interface
// -----------------------------------------

public interface IElectric
{
    int BatteryPercent { get; set; }

    void Charge();
}


// -----------------------------------------
// Combined Interface
// -----------------------------------------

public interface IElectricVehicle : IVehicle, IElectric
{
}


// -----------------------------------------
// ElectricCar Implementation
// -----------------------------------------

public class ElectricCar : IElectricVehicle
{
    private int _batteryPercent;

    // Can only be assigned during object creation
    public string Model { get; init; }

    // Battery is restricted to 0-100
    public int BatteryPercent
    {
        get
        {
            return _batteryPercent;
        }

        set
        {
            if (value < 0)
            {
                _batteryPercent = 0;
            }
            else if (value > 100)
            {
                _batteryPercent = 100;
            }
            else
            {
                _batteryPercent = value;
            }
        }
    }

    // Reduce battery by 10%
    public void Drive()
    {
        BatteryPercent -= 10;

        if (BatteryPercent < 0)
        {
            BatteryPercent = 0;
        }
    }

    // Fully charge the battery
    public void Charge()
    {
        BatteryPercent = 100;
    }
}


// -----------------------------------------
// Lab Driver
// -----------------------------------------

public class Lab4
{
    public static void Run()
    {
        // Create ElectricCar
        ElectricCar car = new ElectricCar
        {
            Model = "Tesla Model 3",
            BatteryPercent = 100
        };

        // -----------------------------------------
        // Drive three times
        // -----------------------------------------

        car.Drive();
        Console.WriteLine(
            $"Battery after drive 1: {car.BatteryPercent}%"
        );

        car.Drive();
        Console.WriteLine(
            $"Battery after drive 2: {car.BatteryPercent}%"
        );

        car.Drive();
        Console.WriteLine(
            $"Battery after drive 3: {car.BatteryPercent}%"
        );

        // -----------------------------------------
        // Charge
        // -----------------------------------------

        car.Charge();

        Console.WriteLine(
            $"Battery after charge: {car.BatteryPercent}%"
        );


        // -----------------------------------------
        // IVehicle reference
        // -----------------------------------------

        IVehicle vehicle = car;

        Console.WriteLine(
            $"As IVehicle - Model: {vehicle.Model}"
        );


        // -----------------------------------------
        // IElectric reference
        // -----------------------------------------

        IElectric electric = car;

        Console.WriteLine(
            $"As IElectric - BatteryPercent: " +
            $"{electric.BatteryPercent}"
        );
    }
}