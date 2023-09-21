using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Appointment;

public class DayOfAppointment
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int DayOfAppointmentId { get; set; }
    public string DayAppointment { get; set; }
}