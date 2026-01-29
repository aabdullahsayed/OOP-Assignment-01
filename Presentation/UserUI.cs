using BusTicketingSystem.Services.Contracts;
using BusTicketingSystem.Entities;


namespace BusTicketingSystem.Presentation;

public class UserUI
{
    private readonly IUserService _userService;

    public UserUI(IUserService userService)
    {
        _userService = userService;
    }
    
    public void CreateUser()
    {
        User u = new User();
        
        Console.WriteLine("Enter Name: ");
        u.Name = Console.ReadLine();
        
        Console.WriteLine("Enter Email Address: ");
        u.Email = Console.ReadLine();

        Console.WriteLine("Enter Phone Number");
        u.Phone = Console.ReadLine();
        
      bool flag =  _userService.AddUser(u);

      if (flag)
      {
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("User Adder!");
          Console.ResetColor();
      }

      else
      {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Invalid Input!/User Already Added");
          Console.ResetColor();
      }
    }

    public void ShowUsers()
    {
        var users = _userService.GetUsers();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"{"ID",-4} {"NAME",-18} {"EMAIL",-25} {"PHONE"} ");
        Console.WriteLine(new string('─', 60)); 
        Console.ResetColor();

        foreach (var x in users)
        {
            
            Console.WriteLine($"{x.Id,-4} {x.Name,-18} {x.Email,-25} {x.Phone}");
        }

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(new string('─', 60));
        Console.ResetColor();
    }
}