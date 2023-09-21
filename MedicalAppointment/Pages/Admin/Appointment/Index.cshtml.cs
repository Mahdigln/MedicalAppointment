using System.Globalization;
using Core.Convertors;
using Core.DTOs;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Admin.Appointment;
[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private IAppointmentService _appointmentService;

    public IndexModel(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }
    [BindProperty]
    public List<SetDayViewModel> SetDayViewModels { get; set; }
    [TempData]
    [BindProperty]
    public DateTime Startfrom { get; set; }
    public void OnGet()
    {
        
       SetDayViewModels = _appointmentService.GetAppoinmentDaysByAdmin(Startfrom);
       
    }
    public IActionResult OnPost()
    {
        return RedirectToPage("Index", Startfrom);
        
    }
    public IActionResult OnGetDelete(long time)
    {
        _appointmentService.DeleteTimeByDay(time);
        return RedirectToPage("Index");
    }

}

