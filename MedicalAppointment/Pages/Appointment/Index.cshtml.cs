using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Appointment;
[Authorize]
public class IndexModel : PageModel
    {
        private IAppointmentService _appointmentService;

        public IndexModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public List<SetDayViewModel> SetDayViewModels { get; set; }
        public void OnGet()
        {
            SetDayViewModels = _appointmentService.GetAppoinmentDays();
        }
        
    }

