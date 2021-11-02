using System;
using System.Collections.Generic;

namespace KSTrips.Application.Services
{
    public class Dates
    {

        private int _year;
        private int _easterMonth;
        private int _easterDay;
        private List<string> _holidays;

        /// <summary>
        /// Calcula los dias festivos en colombia
        /// </summary>
        /// <param name="add"></param>
        /// <param name="initialDate"></param>
        /// <returns></returns>
        public DateTime WorkingDays(int add, DateTime initialDate)
        {
           var notificationDate = GetNextDayEnabled(initialDate, add);

           return notificationDate;
        }

        private void DateUtility(int year)
        {
            _year = year;
            _holidays = new List<string>();
            var a = year % 19;
            var b = year / 100;
            var c = year % 100;
            var d = b / 4;
            var e = b % 4;
            var g = (8 * b + 13) / 25;
            var h = (19 * a + b - d - g + 15) % 30;
            var j = c / 4;
            var k = c % 4;
            var m = (a + 11 * h) / 319;
            var r = (2 * e + 2 * j - k - h + m + 32) % 7;
            _easterMonth = (h - m + r + 90) / 25;
            _easterDay = (h - m + r + _easterMonth + 19) % 32;
            _easterMonth--;

            _holidays.Add("0:1"); // Primero de Enero
            _holidays.Add("4:1"); // Dia del trabajo 1 de mayo
            _holidays.Add("6:20"); // Independencia 20 de Julio
            _holidays.Add("7:7"); // Batalla de boyaca 7 de agosto
            _holidays.Add("11:8"); // Maria inmaculada 8 de diciembre
            _holidays.Add("11:25"); // Navidad 25 de diciembre

            CalculateEmiliani(0, 6); // Reyes magos 6 de enero
            CalculateEmiliani(2, 19); // San jose 19 de marzo
            CalculateEmiliani(5, 29); // San pedro y san pablo 29 de junio
            CalculateEmiliani(7, 15); // Asuncion 15 de agosto
            CalculateEmiliani(9, 12); // Descubrimiento de america 12 de octubre
            CalculateEmiliani(10, 1); // Todos los santos 1 de noviembre
            CalculateEmiliani(10, 11); // Independencia de cartagena 11 de noviembre

            CalculateOtherHoliday(-3, false); // jueves santos
            CalculateOtherHoliday(-2, false); // viernes santo
            CalculateOtherHoliday(43, true); // Asención del señor de pascua
            CalculateOtherHoliday(60, true); // Corpus cristi
            CalculateOtherHoliday(68, true); // Sagrado corazon

        }

        private void CalculateEmiliani(int _month, int _day)
        {
            var date = DateTime.Now;
            var dayOfWeek = (int)date.DayOfWeek;
            switch (dayOfWeek)
            {
                case 1:
                    date = date.AddDays(1);
                    break;
                case 3:
                    date = date.AddDays(6);
                    break;
                case 4:
                    date = date.AddDays(5);
                    break;
                case 5:
                    date = date.AddDays(4);
                    break;
                case 6:
                    date = date.AddDays(3);
                    break;
                case 7:
                    date = date.AddDays(2);
                    break;
            }
            _holidays.Add(date.Month + ":" + date.Day);

        }

        private void CalculateOtherHoliday(int days, bool emiliani)
        {
            var date = DateTime.Now;
            // date.Year = _year;
            // date.Month = _easterMonth;
            // date.Day = _easterDay;

            date = date.AddDays(days);

            if (emiliani)
            {
                CalculateEmiliani(date.Month, date.Day);
            }
            else
            {
                _holidays.Add(date.Month + ":" + date.Day);
            }
        }

        private bool IsHoliday(int month, int day)
        {
            return _holidays.Contains(month + ":" + day);
        }

        public int GetYear()
        {
            return _year;
        }

        private DateTime GetNextDayEnabled(DateTime date, int days)
        {
            var calendar = date;
            DateUtility(calendar.Year);
            while (days > 0)
            {
                var dayOfWeek = (int)calendar.DayOfWeek;
                if (dayOfWeek != 1 && dayOfWeek != 7 && !IsHoliday(calendar.Month, calendar.Day))
                {
                    days--;
                }
                if (calendar.DayOfWeek == DayOfWeek.Saturday) { calendar = calendar.AddDays(2); }
                if (calendar.DayOfWeek == DayOfWeek.Sunday) { calendar = calendar.AddDays(1); }
                 if (calendar.DayOfWeek != DayOfWeek.Saturday && calendar.DayOfWeek != DayOfWeek.Saturday){ calendar = calendar.AddDays(1);}
            }
            return calendar;
        }

    }
}


