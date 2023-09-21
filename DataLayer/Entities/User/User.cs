using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer.Entities.Appointment;

namespace DataLayer.Entities.User;

public class User
{
    [Key]
    public int UserId{ get; set; }
  //[Required]
    public string? Phone { get; set; }
    public DateTime RegisterDate { get; set; }

    #region Relations

    public List<Timing> Timings { get; set; }
    public Roles Roles { get; set; }

    #endregion
}
public enum Roles
{
    Admin,
    patient
}