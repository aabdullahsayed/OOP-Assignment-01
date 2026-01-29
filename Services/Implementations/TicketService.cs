using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;
namespace BusTicketingSystem.Services.Implementations;
public class TicketService : ITicketService
{
    private List<Ticket> _confirmedTickets = new List<Ticket>();
    private List<Ticket> _pendingInvoices = new List<Ticket>();
    private readonly IScheduleService _scheduleService;

    public TicketService(IScheduleService scheduleService)
    {
        _scheduleService = scheduleService;
    }

    public int CreateInvoice(int userId, int scheduleId, string seatNumber)
    {
        
        foreach (var t in _pendingInvoices)
        {
            
            if (t.ScheduleId == scheduleId && t.SeatNumber == seatNumber)
            {
                TimeSpan timePassed = DateTime.Now - t.createdAt;
                if (!t.IsPaid && timePassed.TotalMinutes < 5)
                {
                    return -1; 
                }
            }
        }
        
        var schedule = _scheduleService.GetScheduleById(scheduleId);
        if (schedule == null) return -1;

        Ticket invoice = new Ticket {
            UserId = userId,
            ScheduleId = scheduleId,
            SeatNumber = seatNumber,
            schedule = schedule,
            TotalAmount = schedule.Price,
            createdAt = DateTime.Now,
            IsPaid = false,
            TicketId = _pendingInvoices.Count + 1000 
        };

        _pendingInvoices.Add(invoice);
        return invoice.TicketId;
    }

    public List<Ticket> GetInvoice()
    {
        return _pendingInvoices;
    }

    public Ticket GetInvoiceById(int id)
    {
        
        foreach (Ticket ticket in _pendingInvoices)
        {
            if (ticket.TicketId == id)
            {
                return ticket;
            }
        }
        
        return null;
    }

    public bool ConfirmPayment(int invoiceId)
    {
        var inv = GetInvoiceById(invoiceId);
        if (inv == null) return false;

        
        int row = Convert.ToInt32(inv.SeatNumber.Substring(0, inv.SeatNumber.Length - 1)) - 1;
        int col = inv.SeatNumber[inv.SeatNumber.Length - 1] - 'A';
        
        if (inv.schedule.seats[row, col] != 0) return false;

        
        inv.schedule.seats[row, col] = inv.UserId;
        inv.IsPaid = true;
        inv.TicketId = _confirmedTickets.Count + 1; 

        _confirmedTickets.Add(inv);
        _pendingInvoices.Remove(inv); 
        return true;
    }

    public List<Ticket> GetConfirmedTickets()
    {
        return _confirmedTickets;
    }
}