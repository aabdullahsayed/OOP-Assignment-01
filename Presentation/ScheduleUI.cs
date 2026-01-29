using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;
namespace BusTicketingSystem.Presentation;

public class ScheduleUI
{

    private readonly IScheduleService _scheduleService;

    public ScheduleUI(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }
    
    public void CreateSchedule()
    {
        Schedule schedule = new Schedule();
        Console.WriteLine("Enter Bus Id: ");
        schedule.BusId = Convert.ToInt32(Console.ReadLine());
        
        Console.WriteLine("Enter Departure City: ");
        schedule.DCity = Console.ReadLine();
        
        Console.WriteLine("Enter Arrival City");
        schedule.ACity = Console.ReadLine();
        
        
        Console.Write("Enter Date (YYYY-MM-DD): ");
        schedule.Date = Console.ReadLine();
        
        Console.Write("Enter Time (HH:MM - 24hr format): ");
        schedule.Time = Console.ReadLine();
        
        
        Console.WriteLine("Enter Price");
        schedule.Price = Convert.ToInt32(Console.ReadLine());

        bool flag = _scheduleService.AddSchedule(schedule);

        if (flag)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n[SUCCESS] Schedule Added Successfully");
        }

        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[ERROR] Invalid ");
        }
        
        Console.ResetColor();
    }


    public void ShowSchedule()
    {
        var schedule = _scheduleService.GetSchedule();
      
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{"ID",-4} {"BusID",-8} {"Route",-22} {"Date",-12} {"Time",-8} {"Price",-8}");
        Console.WriteLine(new string('─', 70));
        Console.ResetColor();

        foreach (var z in schedule)
        {
            string route = $"{z.DCity} -> {z.ACity}";
            
            Console.WriteLine($"{z.Id,-4} {z.BusId,-8} {route,-22} {z.Date,-12} {z.Time,-8} {z.Price,-8}");
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('─', 70));
        Console.ResetColor();

    }

    public void ScheduleDetails()
    {
        Console.WriteLine("Enter Schedule ID: ");
        int ScheduleId = Convert.ToInt32(Console.ReadLine());

        var schedule = _scheduleService.GetScheduleById(ScheduleId);
       

        if (schedule == null || schedule.seats == null)
        {
            Console.WriteLine("Schedule or Seats not found");
            return;
        }


        Console.WriteLine("Id: " + schedule.Id + " | BusId: " + schedule.BusId + " | CoachNumber: " + schedule.bus.CoachNumber + " | Class: " + schedule.bus.BusClass + " | Seats: " + schedule.bus.Seats + " | Route: " + schedule.DCity + " -> " + schedule.ACity + " | Date: " + schedule.Date + " | Time: " + schedule.Time + " | Price: " + schedule.Price);



        Console.WriteLine();
        Console.WriteLine("SEAT AVAILABILITY");
        Console.WriteLine("-------------------------------");
        Console.WriteLine("Available: [1A]   Booked: [X]");
        Console.WriteLine();

        
        Console.WriteLine("--------------------------------");

        for (int i = 0; i < schedule.seats.GetLength(0); i++)
        {
            Console.Write(" Row "+(i + 1)+ " |   ");

            for (int j = 0; j < schedule.seats.GetLength(1); j++)
            {
                string status = null;
                string SeatNo = null;
                char? c = null;

                if (j == 0) c = 'A';
                if (j == 1) c = 'B';
                if (j == 2) c = 'C';
                if (j == 3) c = 'D';

                if (schedule.seats[i, j] == 0)
                {
                    int x = i + 1;
                    SeatNo = x.ToString() + c;
                    status = "[" + SeatNo + "]";
                }
                else if (schedule.seats[i, j] == 1)
                {
                    status = "[ X ]";
                }

                Console.Write(status.PadRight(7));
            }

            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine("-------------------------------");
    }

}