using BusTicketingSystem.Entities;
namespace BusTicketingSystem.Services.Contracts;


public interface ITicketService
{
    
    int CreateInvoice(int userId, int scheduleId, string seatNumber);
    Ticket GetInvoiceById(int id);
    List<Ticket> GetInvoice();
    bool ConfirmPayment(int invoiceId);
    List<Ticket> GetConfirmedTickets();
}