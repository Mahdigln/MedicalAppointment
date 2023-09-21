using Core.Convertors;
using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Admin.Appointment;
[Authorize(Roles = "Admin")]
public class AppoinmentListAdminModel : PageModel
    {
        private IAppointmentService _appointmentService;

        public AppoinmentListAdminModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public List<ShowAppointmentListForAdmin> ShowAppointmentListForAdmins { get; set; }
        public void OnGet(long date)
        {
            //ViewData["date"] = date;
            ViewData["date"] = DateTime.FromBinary(date).Date.ToPersianDateString();
            ShowAppointmentListForAdmins = _appointmentService.ShowDataForAdmin(date);
        }

        public IActionResult OnGetDelete(int timeId)
        {
            _appointmentService.DeleteTime(timeId);
            return RedirectToPage("AppoinmentListAdmin");
        }
        public IActionResult OnGetRemoveReservation(int timeId)
        {
            _appointmentService.RemoveReservation(timeId);
            return RedirectToPage("AppoinmentListAdmin");
        }
        public IActionResult OnGetReservationAppointment(int timeId)
        {
            var user = User.Identity.Name;
            _appointmentService.ReserveAppointment(timeId, user);
            return RedirectToPage("AppoinmentListAdmin");
        }
       
    }

