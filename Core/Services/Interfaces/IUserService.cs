using Core.DTOs;
using DataLayer.Entities.User;

namespace Core.Services.Interfaces;

public interface IUserService
{
    bool IsExistPhoneNumber(string phoneNumber);
    int AddUser(User user);
    User LoginUserByPhone(RegisterAndLoginViewModel rl);
    int GetUserIdByUserName(string username);


}