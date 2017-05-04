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
        private MonthStyle monthStyle;
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
        public string Leap { get; set; }
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
        public MonthModel(int month, int year, bool showHolidays, string culture )
        {
            this.Culture = culture;
            this.number = month;
            Today = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            this.Year = year;
            this.showHolidays = showHolidays;
            this.monthStyle = new MonthStyle(month);
            this.BackgroundColour = monthStyle.BackgroundColour;
            this.numberOfDays = monthStyle.NumberOfDays;
            if (year%4==0&&month==2)
            {
                this.numberOfDays = 29;
            }
            if (currentMonth == month&& year == currentYear)
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
            switch (firstDay)
            {
                case DayOfWeek.Sunday:
                    start = 6;
                    break;
                case DayOfWeek.Monday:
                    start = 0;
                    break;
                case DayOfWeek.Tuesday:
                    start = 1;
                    break;
                case DayOfWeek.Wednesday:
                    start = 2;
                    break;
                case DayOfWeek.Thursday:
                    start = 3;
                    break;
                case DayOfWeek.Friday:
                    start = 4;
                    break;
                case DayOfWeek.Saturday:
                    start = 5;
                    break;
                default:
                    break;
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
        private class  MonthStyle
        {
            int numberOfDays;
            string backgroundColour;
            public int NumberOfDays { get => numberOfDays; set => numberOfDays = value; }
            public string BackgroundColour { get => backgroundColour; set => backgroundColour = value; }
            public MonthStyle(int month)
            {
                switch (month)
                {
                    case 1:
                        this.NumberOfDays = 31;
                        this.BackgroundColour = "#008DD2";
                        break;
                    case 2:
                        this.BackgroundColour = "#393185";
                            this.NumberOfDays = 28;
                        break;
                    case 3:
                        this.BackgroundColour = "#57A7B3";
                        this.NumberOfDays = 31;
                        break;
                    case 4:
                        this.BackgroundColour = "#61A375";
                        this.NumberOfDays = 30;
                        break;
                    case 5:
                        this.BackgroundColour = "#009846";
                        this.NumberOfDays = 31;
                        break;
                    case 6:
                        this.BackgroundColour = "#DCCF73";
                        this.NumberOfDays = 30;
                        break;
                    case 7:
                        ;
                        this.BackgroundColour = "#E31E24";
                        this.NumberOfDays = 31;
                        break;
                    case 8:
                        this.BackgroundColour = "#E5097F";
                        this.NumberOfDays = 31;
                        break;
                    case 9:
                        ;
                        this.BackgroundColour = "#EF7F1A";
                        this.NumberOfDays = 30;
                        break;
                    case 10:
                        this.BackgroundColour = "#CC6F3C";
                        this.NumberOfDays = 31;
                        break;
                    case 11:
                        this.BackgroundColour = "#B2AD81";
                        this.NumberOfDays = 30;
                        break;
                    case 12:
                        this.BackgroundColour = "#7690C9";
                        this.NumberOfDays = 31;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
