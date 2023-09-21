using DataLayer.Entities.Appointment;
using DataLayer.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Context;

public class AppointmentContext : DbContext
{
    public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
    {

        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Timing>()
            .HasQueryFilter(u => !u.IsDeleted);

        base.OnModelCreating(modelBuilder);
    }

    #region Appointment

    // public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Timing> Timings { get; set; }
    public DbSet<DayOfAppointment> DayOfAppointments { get; set; }
    

    #endregion

    #region User

    public DbSet<User> Users { get; set; }

    #endregion
}