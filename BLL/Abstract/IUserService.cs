using DataContract;
using Domain;


namespace BLL.Abstract
{
    public interface IUserService
    {
        void Signup(UserDto dto);
        User Login(UserDto dto);
        bool IsEmailUsed(UserDto user);
        bool IsValidEmail(string email);
        bool IsNameUsed(UserDto user);
    }
}
