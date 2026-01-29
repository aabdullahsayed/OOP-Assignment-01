namespace BusTicketingSystem.Entities;
public class Ticket
{
    public int TicketId { get; set; }
   public int ScheduleId { get; set; }
   public int UserId { get; set; }
   public string SeatNumber { get; set; }
   public bool IsPaid { get; set; } = false;
   public decimal TotalAmount { get; set; } 
   
   public Schedule schedule { get; set; }
   
}