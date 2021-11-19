using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TVTOWebsite.Utils
{
    public static class Utilities
    {
        public static string GetPersianDate(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            return string.Format("{1} {2:00} {3} {0:0000}", jc.GetYear(date), GetDayOfWeekName(date), jc.GetDayOfMonth(date), GetMonthName(date));
        }

        public static string GetDayOfWeekName(this DateTime date)
        {
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Saturday: return "شنبه";
                case DayOfWeek.Sunday: return "يکشنبه";
                case DayOfWeek.Monday: return "دوشنبه";
                case DayOfWeek.Tuesday: return "سه‏ شنبه";
                case DayOfWeek.Wednesday: return "چهارشنبه";
                case DayOfWeek.Thursday: return "پنجشنبه";
                case DayOfWeek.Friday: return "جمعه";
                default: return "";
            }
        }

        public static string GetMonthName(this DateTime date)
        {
            PersianCalendar jc = new PersianCalendar();
            string pdate = string.Format("{0:0000}/{1:00}/{2:00}", jc.GetYear(date), jc.GetMonth(date), jc.GetDayOfMonth(date));

            string[] dates = pdate.Split('/');
            int month = Convert.ToInt32(dates[1]);

            switch (month)
            {
                case 1: return "فررودين";
                case 2: return "ارديبهشت";
                case 3: return "خرداد";
                case 4: return "تير‏";
                case 5: return "مرداد";
                case 6: return "شهريور";
                case 7: return "مهر";
                case 8: return "آبان";
                case 9: return "آذر";
                case 10: return "دي";
                case 11: return "بهمن";
                case 12: return "اسفند";
                default: return "";
            }
        }

        public static string GetMiladiDate(this DateTime date)
        {
            string pdate = string.Format("{0} {2} {1} ", date.Year, GetMiladiMonthName(date), date.Day);
            return pdate;
        }

        public static string GetMiladiMonthName(this DateTime date)
        {
            string[] dates = date.ToShortDateString().Split('/');
            int month = Convert.ToInt32(dates[0]);

            switch (month)
            {
                case 1: return "January";
                case 2: return "February";
                case 3: return "March";
                case 4: return "April‏";
                case 5: return "May";
                case 6: return "June";
                case 7: return "July";
                case 8: return "August";
                case 9: return "September";
                case 10: return "October";
                case 11: return "November";
                case 12: return "December";
                default: return "";
            }
        }

    }
}
