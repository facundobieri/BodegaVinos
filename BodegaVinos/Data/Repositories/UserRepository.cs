using BodegaVinos.Data.Entities;
using BodegaVinos.Services.Interfaces;

namespace BodegaVinos.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BodegaDbContext _context;
        public UserRepository(BodegaDbContext context)
        {
            _context = context;
        }
        public List<User> GetUsers()
        {
            return _context.Users.ToList();
        }
        public User? GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }
        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
