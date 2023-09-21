using System.Linq;
using System.Security.Claims;
using Core.Convertors;
using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Context;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;

namespace Core.Services;

public class UserService : IUserService
{
    private AppointmentContext _context;

    public UserService(AppointmentContext context)
    {
        _context = context;
    }
    public bool IsExistPhoneNumber(string phoneNumber)
    {
        return _context.Users.Any(u => u.Phone == phoneNumber);
    }

    public int AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        return user.UserId;

    }

    public User LoginUserByPhone(RegisterAndLoginViewModel rl)
    {
        string phone = FixedText.FiXPhone(rl.Phone);
        return _context.Users.SingleOrDefault(u => u.Phone== phone);
    }

    public int GetUserIdByUserName(string username)
    {
        return _context.Users.Single(u => u.Phone == username).UserId;
    }
}