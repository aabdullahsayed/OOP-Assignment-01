using BusTicketingSystem.Services.Contracts;
using BusTicketingSystem.Entities;

namespace BusTicketingSystem.Presentation;

public class TicketUI
{
    private readonly ITicketService _ticketService;
    private readonly IScheduleService _scheduleService;


    public TicketUI(ITicketService ticketService, IScheduleService scheduleService)
    {
        _ticketService = ticketService;
        _scheduleService = scheduleService;
    }

    public void BookTicket()
    {
        Console.Write("Enter User ID: ");
        int uId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Schedule ID: ");
        int sId = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter Seat (e.g. 1A): ");
        string seat = Console.ReadLine().ToUpper();

        int invId = _ticketService.CreateInvoice(uId, sId, seat);

        if (invId != -1)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nInvoice #{invId} generated! Go to 'Pay Invoice' to confirm.");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] Error generating invoice/Seat Locked");
            Console.ResetColor();
        }
 
    }

    public void ShowInvoices()
    {
        var invoices = _ticketService.GetInvoice();

        string status;
        

        foreach (var V in invoices)
        {
            if (V.IsPaid) status = "Paid";
            else status = "Pending";
            Console.WriteLine("Invoice id : "+V.TicketId+ " User ID: "+V.UserId+" Schedule ID: "+V.ScheduleId+" Seat No: "+V.SeatNumber+" Amount: "+V.TotalAmount+" Status : "+status);
        }
    }
    
    public void ShowInvoice()
    {
        Console.Write("Enter Invoice ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        var inv = _ticketService.GetInvoiceById(id);

        if (inv == null) { Console.WriteLine("Not found."); return; }

        Console.WriteLine($"\n--- INVOICE {inv.TicketId} ---");
        Console.WriteLine($"Route: {inv.schedule.DCity} -> {inv.schedule.ACity} | Seat: {inv.SeatNumber} | Amount: {inv.TotalAmount}");
    }

    public void PayInvoice()
    {
        Console.Write("Enter Invoice ID to Pay: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        var inv = _ticketService.GetInvoiceById(id);
        if (inv == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] Seat taken or invalid ID");
            Console.ResetColor();
            return;
        }

        Console.Write($"Confirm payment of {inv.schedule.Price}? (yes/no): ");
        if (Console.ReadLine().ToLower() == "yes")
        {
            if (_ticketService.ConfirmPayment(id))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success! Ticket confirmed.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Payment failed: Seat taken or invalid ID.");
                Console.ResetColor();
            }
        }
    }
    
    public void ShowTickets()
    {
        Console.WriteLine("\n--- CONFIRMED TICKETS ---");
        Console.WriteLine("ID\tSeat\tRoute");
        Console.WriteLine("------------------------------------------");
        foreach (var t in _ticketService.GetConfirmedTickets())
        {
            Console.WriteLine($"{t.TicketId}\t{t.SeatNumber}\t{t.schedule.DCity} -> {t.schedule.ACity}");Console.WriteLine($"{t.TicketId}\t{t.SeatNumber}\t{t.schedule.DCity} -> {t.schedule.ACity}");
        }
    }
    
    public void ShowTicketById()
    {
        Console.Write("Enter Ticket ID: ");

        int id = Convert.ToInt32(Console.ReadLine());

        Ticket t = _ticketService.GetTicketById(id);

        if (t != null)
        {
            Console.WriteLine($"\nID: {t.TicketId}\tSeat: {t.SeatNumber}\tRoute: {t.schedule.DCity} -> {t.schedule.ACity}");
        }
        else
        {
            Console.WriteLine("Ticket not found.");
        }
    }
    
    
}