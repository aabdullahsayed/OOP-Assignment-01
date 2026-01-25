namespace BusTicketingSystem;

public class UserService:IUserService
{
    List<User> users = new List<User>();


    public void AddUser(User user)
    {
        users.Add(user);
        
    }

    public List<User> GetUsers()
    {
        return users;
    }
    

}