using BodegaVinos.Data.Repository;
using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;
        public UserService(UserRepository userRepository) {
            _userRepository = userRepository;
        }

        public bool validateUser(LoginDTO loginData)
        {
            var user = _userRepository.GetUserByUsername(loginData.Username);
            return user != null && user.Password == loginData.Password;
        }
    }
}
