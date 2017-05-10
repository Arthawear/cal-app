using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cal_App.Models
{

    public class MonthModel : BaseModel
    {
        private string backgroundColour = "#008DD2";
        private string name;
        private int todayRow;
        private int todayCol;
        private int numberOfDays;
        private int[] days;
        private int number;
        private Dictionary<int, RenderDay> dayToPlace = new Dictionary<int, RenderDay>();
        private bool showHolidays;
        private string culture;
        public string Culture
        {
            get
            {
                return this.culture;
            }
            set
            {
                if (this.culture != value)
                {
                    this.culture = value;
                    this.OnPropertyChanged("Culture");
                }
            }
        }
        private string[] dayNames;
        private string leap;
        private bool isEventOn=false;
        string[] colors = new string[12] { "#008DD2", "#393185", "#57A7B3", "#61A375", "#009846", "#DCCF73", "#E31E24", "#E5097F", "#EF7F1A", "#CC6F3C", "#B2AD81", "#7690C9" };
        public bool IsEventOn
        {
            get
            {
                return this.isEventOn;
            }
            set
            {
                if (this.isEventOn != value)
                {
                    this.isEventOn= value;
                    this.OnPropertyChanged("IsEventOn");
                }
            }
        }
        public string[] DayNames
        {
            get
            {
                return this.dayNames;
            }
            set
            {
                if (this.dayNames != value)
                {
                    this.dayNames = value;
                    this.OnPropertyChanged("DayNames");
                }
            }
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }
        public Dictionary<int, RenderDay> DayToPlace
        {
            get
            {
                return this.dayToPlace;
            }

            set
            {
                if (this.dayToPlace != value)
                {
                    this.dayToPlace = value;
                    this.OnPropertyChanged("DayToPlace");
                }
            }
        }
        public int Thickness { get; set; }
        public int Today { get; set; }
        public int TodayRow
        {
            get
            {
                return this.todayRow;
            }
            set
            {
                if (this.todayRow != value)
                {
                    this.todayRow = value;
                    this.OnPropertyChanged("TodayRow");
                }
            }
        }
        public int TodayCol
        {
            get
            {
                return this.todayCol;
            }
            set
            {
                if (this.todayCol != value)
                {
                    this.todayCol = value;
                    this.OnPropertyChanged("TodayCol");
                }
            }
        }
        public string Leap
        {
            get
            {
                return this.leap;
            }
            set
            {
                if (this.leap != value)
                {
                    this.leap = value;
                    this.OnPropertyChanged("Leap");
                }
            }
        }
        public int[] Days
        {
            get
            {
                return days;
            }

            set
            {
                days = value;
            }
        }
        public int Number
        {
            get
            {
                return this.number;
            }

            set
            {
                if (this.number != value)
                {
                    this.number = value;
                    this.OnPropertyChanged("Number");
                }

            }
        }
        public bool ShowHolidays
        {
            get
            {
                return this.showHolidays;
            }

            set
            {
                if (this.showHolidays != value)
                {
                    this.showHolidays = value;
                    this.OnPropertyChanged("ShowHolidays");
                }

            }
        }
        public int Year { get; set; }
        public string BackgroundColour
        {
            get
            {
                return this.backgroundColour;
            }

            set
            {
                if (this.backgroundColour != value)
                {
                    this.backgroundColour = value;
                    this.OnPropertyChanged("BackgroundColour");
                }

            }
        }
        /// <summary>
        /// The constructor of the MonthModel
        /// </summary>
        /// <param name="month">The number of the month</param>
        /// <param name="year">The year number </param>
        /// <param name="showHolidays">The holidays/weekends to be shown/or not</param>
        /// <param name="culture">The calendar's display language</param>
        public MonthModel(int month, int year, bool showHolidays, string culture, bool isEventOn )
        {
            this.IsEventOn = isEventOn;
            this.Culture = culture;
            this.number = month;
            Today = DateTime.Now.Day;
            this.Year = year;
            this.showHolidays = showHolidays;
            this.BackgroundColour = colors[month-1];
            this.numberOfDays = GetNumberOfDays(month);
            if (year%4==0&&month==2)
            {
                this.numberOfDays = 29;
            }
            if (year == DateTime.Now.Year && month == DateTime.Now.Month)
            {
                Thickness = 100;
            }
            this.DayToPlace = ArrangeDays(year, month, this.numberOfDays, showHolidays);
            this.name = GetName(year, month, 1, false, culture);
            DayNames = new string[7];
            for (int i = 2; i < 9; i++)
            {
                string dayName = GetName(2017, 1, i, true, culture);
                DayNames[i - 2] = dayName;
            }
            if (Today > dayToPlace.Count)
            {
                this.todayRow = 0;
                this.todayCol = 0;
                return;
            }
            this.todayRow = dayToPlace[Today].Key;
            this.todayCol = dayToPlace[Today].Value;
            
        }
        /// <summary>
        /// Gets the name of the month or the weekdays
        /// </summary>
        /// <param name="year">The number of year</param>
        /// <param name="month">The number of month</param>
        /// <param name="day">The number of day</param>
        /// <param name="isDayName">Shows if is day name or month name</param>
        /// <param name="culture">The calendar display language</param>
        /// <returns></returns>
        private string GetName(int year, int month, int day, bool isDayName, string culture)
        {
            string s =isDayName? "dddd": "MMMM";
            string name= new DateTime(year, month, day).ToString(s, new CultureInfo(culture));
            if (isDayName)
            {
                name=name.Substring(0, 2);
            }
            name = new CultureInfo("en-US", false).TextInfo.ToTitleCase(name);
            return name;
        }
        /// <summary>
        /// Arrange the days by the place occupied in the Month grid, and sets the color for weekend days
        /// </summary>
        /// <param name="year">The number of year</param>
        /// <param name="month">The number of month</param>
        /// <param name="numberOfDays">The number of the days of a month</param>
        /// <param name="showHolidays">The holidays/weekends to be shown/or not</param>
        /// <returns></returns>
        private Dictionary<int, RenderDay> ArrangeDays(int year, int month, int numberOfDays, bool showHolidays)
        {
            DayOfWeek firstDay = new DateTime(year, month, 1).DayOfWeek;
            int start = 0;
            Dictionary<int, RenderDay> days1 = new Dictionary<int, RenderDay>();
            this.days = new int[numberOfDays];
            Enumerable.Range(1, numberOfDays).ToArray().CopyTo(days, 0);
            start = (int)firstDay-1;
            if (firstDay==DayOfWeek.Sunday)
            {
                start = 6;
            }
            if (year % 4 == 0)
            {
                Leap = "Visible";
            }
            else
            {
                Leap = "Hidden";
            }
            for (int i = 0; i < days.Length; i++)
            {
                bool isHoliday = false;
                int day = days[i];
                int place = start + i;
                DayOfWeek currentDayOfWeek = new DateTime(year, month, day).DayOfWeek;
                if (currentDayOfWeek == DayOfWeek.Saturday ^ currentDayOfWeek == DayOfWeek.Sunday)
                {
                    isHoliday = true;
                }
                string color = "#FEFEFE";
                if (isHoliday && showHolidays)
                {
                    color = "#2B2A29";
                }
                days1.Add(day, new RenderDay() { Key = place / 7 + 2, Value = place % 7, Color = color });
            }
            return days1;
        }
        public int GetNumberOfDays(int month)
        {
            int numberOfDays = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    numberOfDays = 31;
                    break;
                case 2:
                    numberOfDays = 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    numberOfDays = 30;
                    break;
                default:
                    break;
            }
            return numberOfDays;
        }
        /// <summary>
        /// Contains the grid row and column number and the color of a day
        /// </summary>
        public class RenderDay
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public string Color { get; set; }
        }
        /// <summary>
        /// Contains the background color and the number of days of a Month
        /// </summary>
        //private class MonthStyle
        //{
        //    int numberOfDays;
        //    public int NumberOfDays { get => numberOfDays; set => numberOfDays = value; }
        //    public MonthStyle(int month)
        //    {
        //        switch (month)
        //        {
        //            case 1:
        //            case 3:
        //            case 5:
        //            case 7:
        //            case 8:
        //            case 10:
        //            case 12:
        //                this.NumberOfDays = 31;
        //                break;
        //            case 2:
        //                this.NumberOfDays = 28;
        //                break;
        //            case 4:
        //            case 6:
        //            case 9:
        //            case 11:
        //                this.NumberOfDays = 30;
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //}
    }
}
