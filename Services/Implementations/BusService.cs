using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;

namespace BusTicketingSystem.Services.Implementations;

public class BusService:IBusService
{
    private List<Bus> Buses = new List<Bus>();
    
    public bool AddBus(Bus bus)
    {

        if (bus.CoachNumber <= 0 || bus.CoachNumber>100)
        {
            return false;
        }
        
        
        if (bus.BusClass == "B")
        {
            bus.Seats = 27;
            bus.BusClass = "Business";
        }
        else if (bus.BusClass == "E")
        {
            bus.Seats = 36;
            bus.BusClass = "Economy";
        }
        

        bus.Id = Buses.Count + 1;
        
        Buses.Add(bus);

        return true;
    }

    public List<Bus> GetBuses()
    {
        return Buses;
    }
}