namespace BusTicketingSystem;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetUsers();
}