namespace BusTicketingSystem.Presentation;
using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;
public class BusUI
{
    private readonly IBusService _busService;

    public BusUI(IBusService busService)
    {
        _busService = busService;
    }

    public void CreateBus()
    {
        Bus bus = new Bus();

        Console.WriteLine("---Create Bus---");
        
        Console.WriteLine("Enter Coach Number (1 - 100) : ");
        bus.CoachNumber = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter Bus Class (B/E) : ");
        bus.BusClass = Console.ReadLine();

        bool flag = _busService.AddBus(bus);

        if (flag)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[SUCCESS] Bus Added Successfully");
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] Invalid Coach Number");
        }
        
        Console.ResetColor();
        
    }

    public void ShowBus()
    {
        var Buses = _busService.GetBuses();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{"ID",-4} {"Bus Class",-10} {"Coach",-10} {"Seats",-6} ");
        Console.WriteLine(new string('─',40));
        Console.ResetColor();
        foreach (var y in Buses)
        {
            Console.WriteLine($"{y.Id,-4} {y.BusClass,-10} {y.CoachNumber,-10} {y.Seats,-6} ");
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('─',40));
        Console.ResetColor();
        
    }
 
}