namespace BusTicketingSystem;

class Program
{
    static void Main(string[] args)
    {
        IUserService user = new UserService();
        UserUI userUi = new UserUI(user);
        bool running = true;

        while (running)
        {
            
            
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show User");
            Console.WriteLine("3. Exit");
            Console.WriteLine();
        
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
                    running = false;
                    break;
            }
            
        }
        
        
    }
}