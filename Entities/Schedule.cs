using System.Collections;
namespace BusTicketingSystem.Entities;
public class Schedule 
{
    public int Id { get; set; } = 0;
    public int BusId { get; set; }
    public string DCity { get; set; }
    public string ACity { get; set; }
    public string Date { get; set; }
    public string Time { get; set; }
    public decimal Price { get; set; }
    public Bus bus { get; set; } 
    public int[,] seats { get; set; } 
    
}