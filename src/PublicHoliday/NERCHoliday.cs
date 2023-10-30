using System;
using System.Collections.Generic;

namespace PublicHoliday
{
    /// <summary>
    /// NERC Holidays in the US
    /// <br />
    /// If a holiday falls on a Saturday the NERC is open the preceding Friday, this differs from how <see cref="USAPublicHoliday"></see> treats Fridays preceding a Saturday holiday.
    /// <br />
    /// If a holiday falls on a Sunday the NERC is closed following Monday.
    /// https://www.nerc.com/Pages/default.aspx
    /// </summary>
    public class NERCHoliday : PublicHolidayBase
    {
        #region Holiday Adjustments
        private static DateTime FixWeekend(DateTime hol)
        {
            if (hol.DayOfWeek == DayOfWeek.Sunday)
                hol = hol.AddDays(1);
            return hol;
        }
        #endregion

        #region Individual Holidays

        /// <summary>
        /// New Years Day. Note in 1999 and 2005 it was 31st December
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday NewYear(int year)
        {
            var holiday = new DateTime(year, 1, 1);
            return new Holiday(holiday, FixWeekend(holiday), "NewYear");
        }


        /// <summary>
        /// Last Monday in May
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday MemorialDay(int year)
        {
            var hol = new DateTime(year, 5, 25);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, "MemorialDay");
        }


        /// <summary>
        /// Independence Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday IndependenceDay(int year)
        {
            var hol = new DateTime(year, 7, 4);
            var observed = FixWeekend(hol);
            return new Holiday(hol, observed, "IndependenceDay");
        }

        /// <summary>
        /// First Monday in September
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday LaborDay(int year)
        {
            var hol = new DateTime(year, 9, 1);
            hol = HolidayCalculator.FindFirstMonday(hol);
            return new Holiday(hol, hol, "LaborDay");
        }
         
        /// <summary>
        /// Thanksgiving - Fourth Thursday in November
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday Thanksgiving(int year)
        {
            var hol = new DateTime(year, 11, 22);
            hol = HolidayCalculator.FindOccurrenceOfDayOfWeek(hol, DayOfWeek.Thursday, 1);
            return new Holiday(hol, hol, "Thanksgiving");
        }

        /// <summary>
        /// Christmas Day
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public static Holiday Christmas(int year)
        {
            var hol = new DateTime(year, 12, 25);
            return new Holiday(hol, FixWeekend(hol), "Christmas");
        }
        #endregion

        /// <summary>
        /// Get a list of dates for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IList<DateTime> PublicHolidays(int year)
        {
            var bHols = new List<DateTime>();
            bHols.Add(NewYear(year)); //1st January
            bHols.Add(MemorialDay(year)); //Last Monday in May

            bHols.Add(IndependenceDay(year)); //4 July
            bHols.Add(LaborDay(year)); //First Monday in September

            bHols.Add(Thanksgiving(year)); //Fourth Thursday in November
            bHols.Add(Christmas(year)); //25 December

            return bHols;
        }

        /// <summary>
        /// Gets a list of public holidays with their observed and actual date
        /// </summary>
        /// <param name="year">The given year</param>
        /// <returns></returns>
        public override IList<Holiday> PublicHolidaysInformation(int year)
        {
            var bHols = new List<Holiday>();
            bHols.Add(NewYear(year)); //1st January
            bHols.Add(MemorialDay(year)); //Last Monday in May

            bHols.Add(IndependenceDay(year)); //4 July
            bHols.Add(LaborDay(year)); //First Monday in September
            bHols.Add(Thanksgiving(year)); //Fourth Thursday in November
            bHols.Add(Christmas(year)); //25 December
            return bHols;
        }

        /// <summary>
        /// Get a list of dates with names for all holidays in a year.
        /// </summary>
        /// <param name="year">The year.</param>
        /// <returns></returns>
        public override IDictionary<DateTime, string> PublicHolidayNames(int year)
        {
            var bHols = new Dictionary<DateTime, string>();
            bHols.Add(NewYear(year), "New Year"); //1st January
            bHols.Add(MemorialDay(year), "Memorial Day"); //Last Monday in May
            bHols.Add(IndependenceDay(year), "Independence Day"); //4 July
            bHols.Add(LaborDay(year), "Labor Day"); //First Monday in September
            bHols.Add(Thanksgiving(year), "Thanksgiving"); //Fourth Thursday in November
            bHols.Add(Christmas(year), "Christmas"); //25 December
            return bHols;
        }
        /// <summary>
        /// Check if a specific date is a federal holiday.
        /// Obviously the PublicHoliday list is more efficient for repeated checks
        /// </summary>
        /// <param name="dt">The date you wish to check</param>
        /// <returns>True if date is a federal holiday (excluding weekends)</returns>
        public override bool IsPublicHoliday(DateTime dt)
        {
            int year = dt.Year;
            var date = dt.Date;

            switch (dt.Month)
            {
                case 1:
                    if (NewYear(year) == date)
                        return true;
                    break;
                case 5:
                    if (MemorialDay(year) == date)
                        return true;
                    break;
                case 7:
                    if (IndependenceDay(year) == date)
                        return true;
                    break;
                case 9:
                    if (LaborDay(year) == date)
                        return true;
                    break;
                case 11:
                    if (Thanksgiving(year) == date)
                        return true;
                    break;
                case 12:
                    if (Christmas(year) == date)
                        return true;
                    if (NewYear(year + 1) == date)
                        return true; //31st December if New Year is Saturday
                    break;
            }
            return false;
        }
    }
}
