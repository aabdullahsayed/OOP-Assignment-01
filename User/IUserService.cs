namespace BusTicketingSystem.Bus;

public interface IUserService
{
    void AddUser(User user);
    List<User> GetUsers();
}