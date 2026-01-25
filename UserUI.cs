namespace BusTicketingSystem;

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
        
        _userService.AddUser(u);
        
        Console.WriteLine("User Adder!");
    }

    public void ShowUsers()
    {
        var users = _userService.GetUsers();
        foreach (var x in users)
        {
            Console.WriteLine(x.Name+" "+x.Email+" "+x.Phone);
        }
    }
}