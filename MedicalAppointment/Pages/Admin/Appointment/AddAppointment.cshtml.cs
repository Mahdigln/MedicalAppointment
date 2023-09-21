using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MedicalAppointment.Pages.Admin.Appointment;
[Authorize(Roles = "Admin")]
public class AddAppointmentModel : PageModel
{
    private IAppointmentService _appointmentService;

    public AddAppointmentModel(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [BindProperty]
    public AppointmentViewModel appointment { get; set; }


    public void OnGet()
    {
        var dayOfAppointment = _appointmentService.GetdayOfAppointment();
        ViewData["dayOfAppointment"] = new SelectList(dayOfAppointment, "Value", "Text");
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        DateTime start = DateTime.Today.AddDays(appointment.Day);

        int hourStartFrom = appointment.StartFrom;
        int minutesStartFrom = appointment.MinutesStartFrom;
        int countAppointment = appointment.NumberOfAppointment;
        int duration = appointment.Duration;
        DateTime StartTime = start.AddHours(hourStartFrom).AddMinutes(minutesStartFrom);


        for (int i = 0; i < countAppointment; i++)
        {
            Timing timing = new Timing()
            {
                StartTime = StartTime,
                EndTime = StartTime.AddMinutes(duration),
                Duration = duration,
            };
            StartTime = StartTime.AddMinutes(duration);

            _appointmentService.SetAppointment(timing);
            ViewData["IsSuccess"] = true;
        }

        return RedirectToPage("index");

    }


}

