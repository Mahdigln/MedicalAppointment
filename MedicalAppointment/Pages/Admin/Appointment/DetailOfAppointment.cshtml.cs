using Core.Convertors;
using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities.Appointment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Admin.Appointment;
[Authorize(Roles = "Admin")]
public class DetailOfAppointmentModel : PageModel
    {
        private IAppointmentService _appointmentService;

        public DetailOfAppointmentModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

      [BindProperty]
        public ShowDetailOfAppointmentForAdmin ShowDetailOfAppointmentForAdmin { get; set; }
       
        public void OnGet(int id)
        {
             ShowDetailOfAppointmentForAdmin= _appointmentService.GetDetailOfAppointment(id);
            
        }

        public IActionResult OnPost()
        {
            _appointmentService.UpdateAppointmentByAdmin(ShowDetailOfAppointmentForAdmin);
           
            ViewData["IsSuccess"] = true;
            
            return Page();
        }
    }

