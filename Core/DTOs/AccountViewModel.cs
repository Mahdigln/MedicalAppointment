using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class SetPhoneNumberViewModel
{
    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
    [RegularExpression(@"(\+98|0)?9\d{9}",ErrorMessage = "شماره تلفن وارد شده معتبر نیست")]
    public string Phone { get; set; }
}

public class RegisterAndLoginViewModel
{
    [Display(Name = "شماره تلفن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    [MaxLength(11, ErrorMessage = "{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
    public string Phone { get; set; }
    /// <summary>
    /// ConfirmCode = A code that the user enters
    /// </summary>

    [Required]
    [MinLength(5,ErrorMessage = "{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
    [MaxLength(5, ErrorMessage = "{0}نمیتواند بیشتر از {1} کاراکتر باشد.")]
    public string ConfirmCode { get; set; }

    [Display(Name = "مرا به خاطر بسپار")]
    public bool RememberMe { get; set; }


    /// <summary>
    /// A code that sms panel send
    /// </summary>
    [Required]
    public string Code { get; set; }
    public DateTime RegisterDate { get; set; }

    public object ReturnUrl { get; set; }
}