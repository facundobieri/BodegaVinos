using BodegaVinos.Data.Entities;

namespace BodegaVinos.Data.Repository
{
    public class UserRepository
    {
        public List<User> Users { get; set; }

        public UserRepository()
        {
            Users = new List<User>()
            {
                new User { Id = 1, Username = "admin", Password = "admin" },
                new User { Id = 2, Username = "user", Password = "user" }
            };
        }
    }
}
