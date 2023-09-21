using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Context;
using DataLayer.Entities.Appointment;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace Core.Services;

public class AppointmentService : IAppointmentService
{
    private AppointmentContext _context;
    private IUserService _userService;
    public AppointmentService(AppointmentContext context, IUserService userService)
    {
        _context = context;
        _userService = userService;
    }

    public int SetAppointment(Timing timing)
    {
        _context.Timings.Add(timing);
        timing.ReservationTime = null;
        timing.UserId = null;
        _context.SaveChanges();
        return timing.TimingId;
    }

    public List<SelectListItem> GetdayOfAppointment()
    {
        return _context.DayOfAppointments
            .Select(g => new SelectListItem()
            {
                Text = g.DayAppointment,
                Value = g.DayOfAppointmentId.ToString()
            }).ToList();
    }

    public List<Timing> GetAppoinmentlistByDay(long day)
    {
       return _context.Timings.AsEnumerable().Where(t => t.StartTime.Date.ToBinary() == day).ToList();
    }
   
    public List<SetDayViewModel> GetAppoinmentDays()
    {
        var today = DateTime.Today.Date;
        return _context.Timings.Where(t=>t.StartTime.Date >= today).Select(t => new SetDayViewModel
        {
            StartTime = t.StartTime.Date,
        }).AsEnumerable().DistinctBy(t => t.StartTime).OrderBy(t => t.StartTime).ToList();
    }
    public List<SetDayViewModel> GetAppoinmentDaysByAdmin(DateTime startFrom)
    {
        if (startFrom == DateTime.MinValue)
        {
           
            var today = DateTime.Today.Date;
            return _context.Timings.Where(t => t.StartTime.Date >= today).Select(t => new SetDayViewModel
            {
                StartTime = t.StartTime.Date,
            }).AsEnumerable().DistinctBy(t => t.StartTime).OrderBy(t => t.StartTime).ToList();
        }
        else
        {
            return _context.Timings.Where(t => t.StartTime.Date >= startFrom).Select(t => new SetDayViewModel
            {
                StartTime = t.StartTime.Date,
            }).AsEnumerable().DistinctBy(t => t.StartTime).OrderBy(t => t.StartTime).ToList();
        }


    }

    public void ReserveAppointment(int id, string userName)
    {
        Timing timing= GetATimingById(id);
        timing.IsReserved = true;
        timing.ReservationTime = DateTime.Now;
        timing.UserId = _userService.GetUserIdByUserName(userName);
        UpdateTiming(timing);
    }

   

    public void UpdateTiming(Timing timing)
    {
        _context.Timings.Update(timing);
        _context.SaveChanges();
    }

    public Timing GetATimingById(int id)
    {
        return _context.Timings.Find(id);
    }
   

    public List<ShowAppointmentListForAdmin> ShowDataForAdmin(long day)
    {
        return _context.Timings.AsEnumerable().Where(t => t.StartTime.Date.ToBinary() == day)
            .Select(t=>new ShowAppointmentListForAdmin()
            {
                TimingId = t.TimingId, 
                UserId = t.UserId,
                Duration = t.Duration,
                IsDeleted = t.IsDeleted,
                ReservationTime = t.ReservationTime,
                EndTime = t.EndTime,
                IsReserved = t.IsReserved,
                StartTime = t.StartTime,
            } ).ToList();
    }

    public void DeleteTime(int timingId)
    {
        Timing timing = GetATimingById(timingId);
        timing.IsDeleted = true;
        timing.IsReserved = false;
        timing.ReservationTime = null;
        UpdateTiming(timing);
    }

    public void RemoveReservation(int timingId)
    {
        Timing timing = GetATimingById(timingId);
        timing.IsReserved = false;
        timing.ReservationTime = null;
        timing.UserId = null;
        UpdateTiming(timing);
    }

    public void DeleteTimeByDay(long dayTime)
    {
        List<Timing> timings = GetAppoinmentlistByDay(dayTime);
        var dateFromBinaryToNormal = DateTime.FromBinary(dayTime).Date;
        foreach (var item in timings)
        {
            item.StartTime= dateFromBinaryToNormal;
            item.IsDeleted = true;
            item.ReservationTime = null;
            UpdateTiming(item);
        }
    }

    public ShowDetailOfAppointmentForAdmin GetDetailOfAppointment(int timingId)
    {
      return  _context.Timings.Where(t => t.TimingId == timingId)
            .Select(t => new ShowDetailOfAppointmentForAdmin
            {
                TimingId = t.TimingId,
                UserId = t.UserId,
                Phone = t.User.Phone,
                ReservationTime = t.ReservationTime,
               // StartTime = t.StartTime,
                //Duration = t.Duration,
                //EndTime = t.EndTime,
                //IsDeleted = t.IsDeleted,
               // IsReserved = t.IsReserved

            }).FirstOrDefault();
    }

   
    public void UpdateAppointmentByAdmin(ShowDetailOfAppointmentForAdmin detail)
    {

        //User user = _context.Users.Find(detail.Phone);
        var isExistPhoneNumber = _userService.IsExistPhoneNumber(detail.Phone);
        if (!isExistPhoneNumber)
        {
            User newUser = new User()
            {
                Phone = detail.Phone,
                RegisterDate = DateTime.Now,
                Roles = Roles.patient
            };
            _userService.AddUser(newUser);

        }

        var userId = _context.Users.First(u => u.Phone == detail.Phone)?.UserId;

        Timing timing = GetATimingById(detail.TimingId);
        timing.UserId = userId;
        _context.Timings.Update(timing);
        _context.SaveChanges();
    }
}