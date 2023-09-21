using System.ComponentModel.DataAnnotations;

namespace Core.DTOs;

public class AppointmentViewModel
{
    public DateTime StartTime { get; set; }
   
    public DateTime EndTime { get; set; }

    [Display(Name = "ساعت شروع  نوبت دهی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int StartFrom { get; set; }

    [Display(Name = "دقیقه شروع  نوبت دهی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int MinutesStartFrom { get; set; }

    [Display(Name = "مدت زمان هر نوبت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Duration { get; set; }


    [Display(Name = "تعداد نوبت")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int NumberOfAppointment { get; set; }

    [Display(Name = "روز نوبت دهی")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public int Day { get; set; }
}

public class SetDayViewModel
{
   
    public DateTime StartTime { get; set; }
}

public class ShowAppointmentListForAdmin
{
    public int TimingId { get; set; }

    public int? UserId { get; set; }

    
    public DateTime StartTime { get; set; }
    
    public DateTime EndTime { get; set; }
    
    public int Duration { get; set; }
    public DateTime? ReservationTime { get; set; }

    public bool IsReserved { get; set; }
    public bool IsDeleted { get; set; }
    
    public string Phone { get; set; }

    
}

public class ShowDetailOfAppointmentForAdmin
{
    public int TimingId { get; set; }
    public int? UserId { get; set; }
    public DateTime? ReservationTime { get; set; }
    [Display(Name = "شماره تلفن")]
    public string Phone { get; set; }
    public bool IsReserved { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime StartTime { get; set; }
 
    public DateTime EndTime { get; set; }
    public int Duration { get; set; }
}