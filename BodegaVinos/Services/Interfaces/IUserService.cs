using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services.Interfaces
{
    public interface IUserService
    {
        bool validateUser(LoginDTO loginData);
        void CreateUser(CreateUserDTO createUserDTO);
    }
}
