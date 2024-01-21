using System;

namespace timer.Data.MyCustomTimer
{
    /// <summary>
    /// <para>Universal time store</para>
    /// <para>TimeOnly</para>
    /// <para>TimeSpan</para>
    /// <para>DateTime</para>
    /// <para>DateTimeOffset</para>
    /// <para>...</para>
    /// </summary>
    internal class MyClock
    {
        /*
         * internal types for controling
         */
        private int Day { get; set; }
        private int Hour { get; set; }
        private int Minute { get; set; }
        private int Second { get; set; }
        private int Millisecond { get; set; }

        private int Year { get; set; }
        private int Month { get; set; }
        private int DayOfMonth { get; set; }
        private int DayOfWeek { get; set; }
        private int DayOfYear { get; set; }
        private int MonthOfYear { get; set; }

        /*
         * Data structure
         */
        public TimeOnly GetTimeOnly => new TimeOnly(Hour, Minute, Second, Millisecond);
        public TimeSpan GetTimeSpan => new TimeSpan(Day, Hour, Minute, Second, Millisecond);
        public DateTime GetDateTime => new DateTime(0, 0, Day, Hour, Minute, Second, Millisecond);
        public DateTimeOffset GetDateTimeOffset => new DateTimeOffset(0, 0, Day, Hour, Minute, Second, Millisecond, new TimeSpan(1, 0, 0));

        //Json
        //Xml 
        //Csv
        //Txt
        //Custom format
        //File format
        
        //Output
        //console
        //file
        //other diff file structure

        public string ToStringClock() => Day + " " + Hour + ":" + Minute + ":" + Second + " " + Millisecond;
        public string ToStringShortClock() => Hour + ":" + Minute + ":" + Second;

        public MyClock(TimeOnly timeOnly)
        {
            Day = 0;
            Hour = timeOnly.Hour;
            Minute = timeOnly.Minute;
            Second = timeOnly.Second;
            Millisecond = timeOnly.Millisecond;
        }
        public MyClock(TimeSpan timeSpan)
        {
            Day = timeSpan.Days;
            Hour = timeSpan.Hours;
            Minute = timeSpan.Minutes;
            Second = timeSpan.Seconds;
            Millisecond = timeSpan.Milliseconds;
        }
        public MyClock(DateTime dateTime)
        {
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;
        }
        public MyClock(DateTimeOffset dateTime)
        {
            Day = dateTime.Day;
            Hour = dateTime.Hour;
            Minute = dateTime.Minute;
            Second = dateTime.Second;
            Millisecond = dateTime.Millisecond;
        }
        public MyClock(string? day, string? hour, string? minute, string? second, string? millisecond = null)
        {
            Day = string.IsNullOrEmpty(day) ? 0 : int.Parse(day);
            Hour = string.IsNullOrEmpty(hour) ? 0 : int.Parse(hour);
            Minute = string.IsNullOrEmpty(minute) ? 0 : int.Parse(minute);
            Second = string.IsNullOrEmpty(second) ? 0 : int.Parse(second);
            Millisecond = string.IsNullOrEmpty(millisecond) ? 0 : int.Parse(millisecond);
        }
        public MyClock(int day, int hour, int minute, int second, int millisecond)
        {
            Day = day;
            Hour = hour;
            Minute = minute;
            Second = second;
            Millisecond = millisecond;
        }
        public MyClock()
        {
            Day = DateTime.Now.Day;
            Hour = DateTime.Now.Hour;
            Minute = DateTime.Now.Minute;
            Second = DateTime.Now.Second;
            Millisecond = DateTime.Now.Millisecond;
        }

        /*
         * Сalculations, Conditions, Time arithmetic
         */

        /// <summary>
        /// Сравнивает значения двух часов
        /// </summary>
        /// <param name="other">Другие часы</param>
        /// <returns></returns>
        public bool Equals(MyClock other)
        {
            if (other.Hour == Hour && other.Minute == Minute && other.Second == Second
                && other.Millisecond == Millisecond) return true;
            else return false;
        }

        /// <summary>
        /// Сравнивает значения двух часов
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator ==(MyClock clock, MyClock clock1)
        {
            if (clock.Hour == clock1.Hour && clock.Minute == clock1.Minute && clock.Second == clock1.Second) return true;
            else return false;
        }

        /// <summary>
        /// Проверяет неравенство значений двух часов
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator !=(MyClock clock, MyClock clock1)
        {
            if (clock.Hour != clock1.Hour && clock.Minute != clock1.Minute && clock.Second != clock1.Second) return true;
            else return false;
        }

        /// <summary>
        /// Левый операнд больше правого операнда
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator >(MyClock clock, MyClock clock1)
        {
            if (clock.Hour > clock1.Hour) return true;
            else if (clock.Minute > clock1.Minute) return true;
            else if (clock.Second > clock1.Second) return true;
            else return false;
        }

        /// <summary>
        /// Левый операнд меньше правого 
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator <(MyClock clock, MyClock clock1)
        {
            if (clock.Hour < clock1.Hour) return true;
            else if (clock.Minute < clock1.Minute) return true;
            else if (clock.Second < clock1.Second) return true;
            else return false;
        }

        /// <summary>
        /// Левый операнд меньше либо равен правого 
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator <=(MyClock clock, MyClock clock1)
        {
            var clockInLine = clock.Hour + "" + clock.Minute + "" + clock.Second;
            var clock1InLine = clock1.Hour + "" + clock1.Minute + "" + clock1.Second;

            return Convert.ToInt32(clockInLine) <= Convert.ToInt32(clock1InLine);
        }

        /// <summary>
        /// Левый операнд больше либо равен правому 
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static bool operator >=(MyClock clock, MyClock clock1)
        {
            var clockInLine = clock.Hour + "" + clock.Minute + "" + clock.Second;
            var clock1InLine = clock1.Hour + "" + clock1.Minute + "" + clock1.Second;

            return Convert.ToInt32(clockInLine) >= Convert.ToInt32(clock1InLine);
        }

        /// <summary>
        /// Сложить два времени
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static MyClock operator + (MyClock clock, MyClock clock1)
        {
            var s = clock.Second + clock1.Second;
            var m = clock.Minute + clock1.Minute;
            var h = clock.Hour + clock1.Hour;

            if (s > 60)
            {
                var ss = s - 60;
                m = m + 1;
                s = ss;
            }
            if (m > 60)
            {
                var mm = m - 60;
                h = h + 1;
                m = mm;
            }

            return new MyClock(0, h, m, s, 0);
        }

        /// <summary>
        /// Вычесть время
        /// </summary>
        /// <param name="clock"></param>
        /// <param name="clock1"></param>
        /// <returns></returns>
        public static MyClock operator -(MyClock clock, MyClock clock1)
        {
            var h = clock.Hour - clock1.Hour;
            var m = clock.Minute - clock1.Minute;
            var s = clock.Second - clock1.Second;
            return new MyClock(0, h, m, s, 0);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        /*
         * CRUD
         */

    }
}
