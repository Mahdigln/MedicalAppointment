using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Appointment;

[Authorize]
public class ReserveAppointmentModel : PageModel
{
    private IAppointmentService _appointmentService;

    public ReserveAppointmentModel(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [BindProperty]
    public Timing Timing { get; set; }
    public IActionResult OnGet(int id)
    {
        Timing = _appointmentService.GetATimingById(id);
        DateTime reservetime = DateTime.Now;

        if (reservetime <= Timing.StartTime)
        {
            ViewData["color"] = "btn-mat";
            return Page();
        }
        ViewData["Error"] = true;
        ViewData["color"] = "btn-danger";
        ViewData["disabled"] = "disabled";
        return Page();

    }
    //public IActionResult OnPost(int id)
    //{

    //    if (Timing.IsReserved == false)
    //    {
    //        Timing = _appointmentService.GetATimingById(id);
    //        if (!ModelState.IsValid)
    //        {
    //            return Page();
    //        }
    //        var user = User.Identity.Name;
    //        _appointmentService.ReserveAppointment(id, user);
    //        ViewData["Success"] = true;
    //        ViewData["disabled"] = "disabled";
    //        return Page();
    //    }
    //    else
    //    {
    //        ViewData["IsFull"] = true;
    //        return Page();
    //    }

    //}
    public async Task<IActionResult>  OnPost(int id)
    {

        if (Timing.IsReserved == false)
        {
            Timing = _appointmentService.GetATimingById(id);
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = User.Identity.Name;
             _appointmentService.ReserveAppointment(id, user);
            ViewData["Success"] = true;
            ViewData["disabled"] = "disabled";
            return Page();
        }
        else
        {
            ViewData["IsFull"] = true;
            return Page();
        }

    }


}


