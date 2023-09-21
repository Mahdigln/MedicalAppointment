using System.Globalization;
using Core.DTOs;
using DataLayer.Entities.Appointment;
using DataLayer.Entities.User;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Services.Interfaces;

public interface IAppointmentService
{
    int SetAppointment(Timing timing);
    List<SelectListItem> GetdayOfAppointment();
    List<Timing> GetAppoinmentlistByDay(long day);
    List<SetDayViewModel> GetAppoinmentDays();
    List<SetDayViewModel> GetAppoinmentDaysByAdmin(DateTime startFrom);
    void ReserveAppointment(int id, string userName);
    Timing GetATimingById(int id);
    void UpdateTiming(Timing timing);
    List<ShowAppointmentListForAdmin> ShowDataForAdmin(long day);
    void DeleteTime(int timingId);
    void RemoveReservation(int timingId);
    void DeleteTimeByDay(long dayTime);
    ShowDetailOfAppointmentForAdmin GetDetailOfAppointment(int timingId);
    void UpdateAppointmentByAdmin(ShowDetailOfAppointmentForAdmin detail);
    

}