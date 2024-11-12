using BodegaVinos.Data.Entities;

namespace BodegaVinos.Services.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        //User? GetUserByUsername(string username);
        void CreateUser(User user);
        User? Authenticate(string username, string password);
    }
}
