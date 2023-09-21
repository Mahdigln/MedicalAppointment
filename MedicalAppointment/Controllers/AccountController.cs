using System.Security.Claims;
using Core.DTOs;
using Core.Generator;
using Core.Services.Interfaces;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Controllers;

public class AccountController : Controller
{
    private IUserService _userService;
    private ISMSService _smsService;
    public AccountController(IUserService userService, ISMSService smsService)
    {
        _userService = userService;
        _smsService = smsService;
    }


    #region Login

    [Route("Login")]
    public IActionResult SetPhoneNumber()
    {
        return View();
    }


    [HttpPost]
    [Route("Login")]
    public IActionResult SetPhoneNumber(SetPhoneNumberViewModel phoneNumberDto )
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        var code = NumberGenerator.RandomNumber();
        //var sms = _smsService.SendLookupSMS(phoneNumberDto.Phone, "ContactUsVerification", "کابر گرامی", code);

        

        TempData["PhoneNumber"] = phoneNumberDto.Phone;
        TempData["code"] = code;
     
        
        return RedirectToAction("RegisterAndLogin");
    }

    [HttpGet]
    public IActionResult RegisterAndLogin()
    {
        return View(new RegisterAndLoginViewModel
        {
            Phone = TempData["PhoneNumber"].ToString(),
            Code = TempData["code"].ToString(),
           
        });
    }

    [HttpPost]
    public IActionResult RegisterAndLogin(RegisterAndLoginViewModel rl)
    {
        if (!ModelState.IsValid)
        {
            return View(rl);
        }

        if (rl.Code == rl.ConfirmCode)
        {
            if (!_userService.IsExistPhoneNumber(rl.Phone))
            {
                //Register
                User newUser = new User()
                {
                    Phone = rl.Phone,
                    RegisterDate = DateTime.Now,
                    Roles = Roles.patient
                };

                _userService.AddUser(newUser);

            }
            //Login
            var user = _userService.LoginUserByPhone(rl);
            if (user != null)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Role,user.Roles.ToString()),
                    new Claim(ClaimTypes.Name, user.Phone),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = rl.RememberMe
                };
                HttpContext.SignInAsync(principal, properties);

                ViewBag.IsSuccess = true;

            }

            return View();

        }
        else
        {
            ViewData["Message"] = $"کد وارد شده برای شماره {rl.Phone} اشتباه است";
            return View(rl);
        }

    }

    #endregion


    #region Logout

    [Route("Logout")]
    public IActionResult Logout()
    {
        HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Redirect("/Login");
    }

    #endregion
}

