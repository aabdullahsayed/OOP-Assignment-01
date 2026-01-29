using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;

namespace BusTicketingSystem.Services.Implementations;

public class ScheduleService:IScheduleService
{
    
    private List<Schedule> Schedules = new List<Schedule>();

    private readonly IBusService _busService;

    public ScheduleService(IBusService busService)
    {
        _busService = busService;
    }
    
    
    public bool AddSchedule(Schedule schedule)
    {
        
        Bus foundBus = null;

        foreach (var b in _busService.GetBuses())
        {
            if (b.Id == schedule.BusId)
            {
                foundBus = b;
                break;
            }
            
        }

        if (foundBus == null)
        {
            return false;
        }
        
        if (DateTime.TryParse(schedule.Date , out DateTime parsedDate))
        {
            if (!(parsedDate >= DateTime.Today))
            {
                return false;
            }
        }
        
        
        if (schedule.Time.Length != 5 || !schedule.Time.Contains(":"))
        {
            return false;
        }

        
        string[] parts = schedule.Time.Split(':');
    
        
        if (int.TryParse(parts[0], out int hours) && int.TryParse(parts[1], out int minutes))
        {
            
            if (!(hours >= 0 && hours < 24 && minutes >= 0 && minutes < 60))
            {
                return false;
            }
        }
        else
        {
            return false;
        }


        if (schedule.Price <= 0)
        {
            return false;
        }
        
        schedule.bus = foundBus;
        
        if(schedule.bus.BusClass == "Business"){
            
            schedule.seats = new int[9,3];
        }
        else{
            
            schedule.seats = new int[9,4];
        }
        
        schedule.Id = Schedules.Count + 1;
        Schedules.Add(schedule);

        return true;
    }

    public List<Schedule> GetSchedule() 
    
    {
        return Schedules;
    }
    

    public Schedule GetScheduleById(int Id)
    {
        foreach (var x in Schedules)
        {
            if (x.Id == Id)
            {
                return x;
            }
        }

        return null;
    }
}