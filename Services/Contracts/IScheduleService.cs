using BusTicketingSystem.Entities;

namespace BusTicketingSystem.Services.Contracts;

public interface IScheduleService
{
    bool AddSchedule(Schedule schedule);
    List<Schedule> GetSchedule();
    Schedule GetScheduleById(int Id);
    
}