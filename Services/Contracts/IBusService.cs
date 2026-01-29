using BusTicketingSystem.Entities;
using System;
using System.Collections.Generic;
namespace BusTicketingSystem.Services.Contracts;
using BusTicketingSystem.Entities;
using System;
using System.Collections.Generic;

public interface IBusService
{
    bool AddBus(Bus bus);
    List<Bus> GetBuses();
    
}