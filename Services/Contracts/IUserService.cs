using BusTicketingSystem.Entities;
namespace BusTicketingSystem.Services.Contracts;
public interface IUserService
{
    bool AddUser(User user);
    List<User> GetUsers();
}