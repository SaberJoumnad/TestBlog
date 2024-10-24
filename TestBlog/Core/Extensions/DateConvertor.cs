﻿using System.Globalization;

namespace TestBlog.Core.Extensions
{
    // انواع تبدیل تاریخ ها
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00") + "/"
                + pc.GetDayOfMonth(value).ToString("00");
        }

        public static string ToPersianDate(this DateTime dateTime, string format)
        {
            PersianCalendar pc = new PersianCalendar();
            try
            {
                string date = format.Replace("Y", pc.GetYear(dateTime).ToString().PadLeft(4, '0'))
                        .Replace("mm", pc.GetMonth(dateTime).ToString())
                        .Replace("MM", pc.GetMonth(dateTime).ToString().PadLeft(2, '0'))
                        .Replace("dd", pc.GetDayOfMonth(dateTime).ToString())
                        .Replace("DD", pc.GetDayOfMonth(dateTime).ToString().PadLeft(2, '0'))
                        .Replace("ds", GetDayOfWeekString((int)pc.GetDayOfWeek(dateTime)).ToString())
                        .Replace("ms", GetMonthString(pc.GetMonth(dateTime)).ToString())
                    ;
                return date;
            }
            catch
            {
                return "";
            }

            // نحوه استفاده از این متود در ویو
            //@DateTime.Now.ToPersianDate("ds dd ms Y")

        }

        private static string GetDayOfWeekString(int day)
        {
            string[] days = new string[] { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
            if (day <= days.Length)
            {
                return days[day];
            }
            return "";
        }
        private static string GetMonthString(int month)
        {
            string[] months = new string[] { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };
            if (month <= months.Length)
            {
                return months[month - 1];
            }
            return "";
        }
        public static string GetTimeAgo(this DateTime dateTime)
        {
            var now = DateTime.Now;
            int year = now.Year - dateTime.Year;
            int month = now.Month - dateTime.Month;
            int days = now.Day - dateTime.Day;
            int hours = now.Hour - dateTime.Hour;
            int minutes = now.Minute - dateTime.Minute;
            int seconds = now.Second - dateTime.Second;

            if (year > 0)
            {
                return $"{year} سال پیش";
            }
            else if (month > 0)
            {
                return $"{month} ماه پیش";
            }
            else if (days > 0)
            {
                return $"{days} روز پیش";
            }
            else if (hours > 0)
            {
                return $"{hours} ساعت پیش";
            }
            else if (minutes > 0)
            {
                return $"{minutes} دقیقه پیش";
            }
            else if (seconds > 0)
            {
                return $"{seconds} ثانیه پیش";
            }
            else
            {
                return "لحضاتی پیش";
            }
        }

    }
}
