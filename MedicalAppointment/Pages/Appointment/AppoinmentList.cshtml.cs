using Core.Convertors;
using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages;
[Authorize]
public class AppoinmentListModel : PageModel
    {
        private IAppointmentService _appointmentService;

        public AppoinmentListModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public List<Timing> Timings { get; set; }
        public void OnGet(long date)
        {

            //ViewData["date"] = DateTime.FromBinary(date).Date.ToShamsi();
            ViewData["date"] = DateTime.FromBinary(date).Date.ToPersianDateString();
            Timings = _appointmentService.GetAppoinmentlistByDay(date);
        }
    }

