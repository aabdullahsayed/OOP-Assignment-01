using BusTicketingSystem.Services.Contracts;
namespace BusTicketingSystem.Presentation;

public class MenuUI
{
    private readonly UserUI userUi;
    private readonly BusUI busUi;
    private readonly ScheduleUI scheduleUi;
    private readonly TicketUI ticketUi;

    public MenuUI(IUserService user, IBusService bus, IScheduleService schedule, ITicketService ticket)
    {
        this.userUi = new UserUI(user);
        this.busUi = new BusUI(bus);
        this.scheduleUi = new ScheduleUI(schedule);
        this.ticketUi = new TicketUI(ticket, schedule);
    }

    public void DisplayMenu()
    {
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("            ┌──────────────────────────────┐");
        Console.WriteLine("            │    BUS TICKETING SYSTEM      │");
        Console.WriteLine("            └──────────────────────────────┘");
        Console.ResetColor();

            
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write("[ ADMIN ]  ");
        Console.ResetColor();
        Console.WriteLine("1. Create User      2. List Users       3. Create Bus");
        Console.WriteLine("           4. List Buses       5. Create Schedule  6. List Schedules");
        Console.WriteLine("           7. View Seats");

        Console.WriteLine(); 

          
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("[ SALES ]  ");
        Console.ResetColor();
        Console.WriteLine("8. Book Ticket      9. Find Invoice     10. List All Invoices");
        Console.WriteLine("           11. Pay Invoice     12. View Tickets");

        Console.WriteLine(); 

          
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("[ SYSTEM ] ");
        Console.ResetColor();
        Console.WriteLine("0. Exit System");

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\nSelect Option > ");
        Console.ResetColor();
        Console.WriteLine(" ");
        
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            
            DisplayMenu();
            
            string s = Console.ReadLine();


            switch (s)
            {

                case "1":
                    userUi.CreateUser();

                    break;
                case "2":
                    userUi.ShowUsers();
                    break;

                case "3":
                    busUi.CreateBus();
                    break;

                case "4":
                    busUi.ShowBus();
                    break;

                case "5":
                    scheduleUi.CreateSchedule();
                    break;

                case "6":
                    scheduleUi.ShowSchedule();
                    break;

                case "7":
                    scheduleUi.ScheduleDetails();
                    break;
                case "8":
                    ticketUi.BookTicket();
                    break;

                case "9":
                    ticketUi.ShowInvoice();
                    break;

                case "10":
                    ticketUi.ShowInvoices();
                    break;

                case "11":
                    ticketUi.PayInvoice();
                    break;

                case "12":
                    ticketUi.ShowTickets();
                    break;

                case "0":
                    running = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid selection."); 
                    break;
            }

        }


    }
}
        
    
    
