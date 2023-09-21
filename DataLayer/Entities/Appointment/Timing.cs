using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities.Appointment;

public class Timing
{
    [Key]
    public int TimingId { get; set; }

    
    public int? UserId { get; set; }

    [Required]
    public DateTime StartTime { get; set; }
    [Required]
    public DateTime EndTime { get; set; }
    [Required]
    public int Duration { get; set; }
    public DateTime? ReservationTime { get; set; }

    public bool IsReserved { get; set; }
    public bool IsDeleted { get; set; }
    
    #region Realtions
    //[ForeignKey("UserId")]
    public User.User User { get; set; }

    #endregion
}