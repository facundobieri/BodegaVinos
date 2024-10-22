using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Interfaces;

namespace BodegaVinos.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool validateUser(LoginDTO loginData)
        {
            var user = _userRepository.GetUserByUsername(loginData.Username);
            return user != null && user.Password == loginData.Password;
        }

        public void CreateUser(CreateUserDTO createUserDTO)
        {
            var user = new User
            {
                Username = createUserDTO.Username,
                Password = createUserDTO.Password
            };
            _userRepository.CreateUser(user);
        }
    }
}
