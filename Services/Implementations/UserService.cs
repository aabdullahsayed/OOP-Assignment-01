using System.ComponentModel.DataAnnotations;
using BusTicketingSystem.Entities;
using BusTicketingSystem.Services.Contracts;
namespace BusTicketingSystem.Services.Contracts;

public class UserService:IUserService
{
    List<User> users = new List<User>();


    public bool AddUser(User user)
    {

        if (user.Phone.ToString().Length != 11)
        {
            return false;
        }

        if (string.IsNullOrEmpty(user.Email) || user.Email.Contains(" ") || !user.Email.Contains("@") || !user.Email.Contains("."))
        {
            return false;
        }

        foreach (var u in users)
        {
            if (u.Phone == user.Phone) return false;
            else if (u.Email == user.Email) return false;
        }
        
        user.Id = users.Count + 1;
        users.Add(user);

        return true;

    }

    public List<User> GetUsers()
    {
        return users;
    }
    

}