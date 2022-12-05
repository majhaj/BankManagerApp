using BankManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstConsoleApp.GenericTypes
{
    internal class Examples
    {
        public Examples()
        {
            List<BankEntity> banks = new List<BankEntity>();

        }

    }

    class YearCounter
    {
        public int Year { get; set; }
        public int Counter { get; set; }

        public static YearCounter GetYearCounter(int year, List<YearCounter> yearsCounters)
        {
            foreach (var item in yearsCounters)
            {
                if (item.Year == year)
                {
                    return item;
                }
            }

            return null;
        }
    }

    class DateDifferential
    {
        public DateTime CurrentDate { get; set; }
        public DateTime VerifyDate { get; set; }
        //public long TicksInterval => CurrentDate.Ticks - VerifyDate.Ticks;
        public int DaysDifference => VerifyDate.DayOfYear - CurrentDate.DayOfYear;


        public static DateDifferential GetNearestDifferential(List<DateDifferential> dateDifferentials)
        {
            DateDifferential result = null;
            if (CheckIfAnyBirthdayExistsInCurrentYearDateExists(dateDifferentials))
            {
                result = GetNearestFromPositive(dateDifferentials);
            }
            else
            {
                result = GetNearestFromNegative(dateDifferentials);
            }

            return result;
        }

        public static bool CheckIfAnyBirthdayExistsInCurrentYearDateExists(List<DateDifferential> dateDifferentials)
        {
            foreach (var item in dateDifferentials)
            {
                if (item.DaysDifference > 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static DateDifferential GetNearestFromPositive(List<DateDifferential> dateDifferentials)
        {
            DateDifferential nearest = null;
            foreach (var item in dateDifferentials)
            {
                if (item.DaysDifference > 0)
                {
                    if (nearest == null || nearest.DaysDifference > item.DaysDifference)
                    {
                        nearest = item;
                    }
                }
            }

            return nearest;
        }

        private static DateDifferential GetNearestFromNegative(List<DateDifferential> dateDifferentials)
        {
            DateDifferential nearest = null;
            foreach (var item in dateDifferentials)
            {
                if (nearest == null || nearest.DaysDifference > item.DaysDifference)
                {
                    nearest = item;
                }
            }

            return nearest;
        }
    }
}
