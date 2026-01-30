using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;
using BusTicketingSystem.Services.Implementations;
using BusTicketingSystem.Presentation;

namespace BusTicketingSystem;

class Program
{
    static void Main(string[] args)
    {
        IUserService user = new UserService();
        IBusService bus = new BusService();
        IScheduleService schedule = new ScheduleService(bus);
        ITicketService ticket = new TicketService(schedule);


        MenuUI menuUi = new MenuUI(user, bus, schedule, ticket);
        menuUi.Run();
    }
            
}
        
        
    
