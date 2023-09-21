using System.Globalization;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace Core.Convertors;

public static class DateConvertor
{
    public static string ToShamsi(this DateTime value)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
               pc.GetDayOfMonth(value).ToString("00");
    }
    //public static DateTime ToShamsi3(this DateTime value)
    //{
    //    PersianCalendar pc = new PersianCalendar();
    //    pc.GetYear(value);
    //    pc.GetMonth(value);
    //    pc.GetDayOfMonth(value);
    //    return DateTime.Equals(pc);
    //}

    public static string ToShamsi2(this DateTime value)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/" +
               pc.GetDayOfMonth(value).ToString("00") +
               "  " + value.Date.ToString("HH:mm");
    }


}