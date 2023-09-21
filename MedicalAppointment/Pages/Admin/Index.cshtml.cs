using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedicalAppointment.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
           return RedirectToPage("/Admin/Appointment/Index");
        }
    }
}
