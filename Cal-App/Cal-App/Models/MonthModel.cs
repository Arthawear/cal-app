using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Models
{

    public class MonthModel : BaseModel
    {
        private string backgroundColor = "#008DD2";
        private string name;
        private int todayRow;
        private int todayCol;
        private int numberOfDays;
        private int[] days;
        private int number;
        private int year;
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
        private int gridRow;
        private int gridColumn;
        private int viewColumnNumber;
        private string visibility;
        private string currentSquareVisibility;
        public string CurrentSquareVisibility
        {
            get
            {
                return this.currentSquareVisibility;
            }
            set
            {
                if (this.currentSquareVisibility != value)
                {
                    this.currentSquareVisibility = value;
                    this.OnPropertyChanged("CurrentSquareVisibility");
                }
            }
        }
        public string Visibility
        {
            get
            {
                return this.visibility;
            }
            set
            {
                if (this.visibility != value)
                {
                    this.visibility = value;
                    this.OnPropertyChanged("Visibility");
                }
            }
        }
        public int ViewColumnNumber
        {
            get
            {
                return this.viewColumnNumber;
            }
            set
            {
                if (this.viewColumnNumber != value)
                {
                    this.viewColumnNumber = value;
                    this.OnPropertyChanged("ViewColumnNumber");
                }
            }
        }
        public int GridRow
        {
            get
            {
                return this.gridRow;
            }
            set
            {
                if (this.gridRow != value)
                {
                    this.gridRow = value;
                    this.OnPropertyChanged("GridRow");
                }
            }
        }
        public int GridColumn
        {
            get
            {
                return this.gridColumn;
            }
            set
            {
                if (this.gridColumn != value)
                {
                    this.gridColumn = value;
                    this.OnPropertyChanged("GridColumn");
                }
            }
        }
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
        public string Button30 { get; set; }
        public string Button31 { get; set; }
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
                return this.days;
            }

            set
            {
                if (this.days != value)
                {
                    this.days = value;
                    this.OnPropertyChanged("Days");
                }
            }
        }
        public int NumberOfDays
        {
            get
            {
                return this.numberOfDays;
            }

            set
            {
                if (this.numberOfDays != value)
                {
                    this.numberOfDays = value;
                    this.OnPropertyChanged("NumberOfDays");
                }
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
        public int Year
        {
            get
            {
                return this.year;
            }
            set
            {
                if (this.year != value)
                {
                    this.year = value;
                    this.OnPropertyChanged("Year");
                }
            }
        }
        public string BackgroundColor
        {
            get
            {
                return this.backgroundColor;
            }
            set
            {
                if (this.backgroundColor != value)
                {
                    this.backgroundColor = value;
                    this.OnPropertyChanged("BackgroundColor");
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
        public MonthModel(int month, int year, bool showHolidays, string culture, bool isEventOn, int viewColumnNumber, string visibility)
        {
            if (month == 0 || month > 12)
                throw new ArgumentOutOfRangeException("month", "month must be greater than 0 and smaller than 13");
            SetRowAndColumn(month, viewColumnNumber);
            this.Visibility = visibility;
            this.IsEventOn = isEventOn;
            this.Culture = culture;
            this.number = month;
            Today = DateTime.Now.Day;
            this.Year = year;
            this.showHolidays = showHolidays;
            this.BackgroundColor = colors[month-1];
            GetNumberOfDays(month, year);
            if (year == DateTime.Now.Year && month == DateTime.Now.Month)
            {
                Thickness = 100;
            }
            ArrangeDays(year, month, this.NumberOfDays, showHolidays);
            SetNames(month, culture);
            if (Today > dayToPlace.Count)
            {
                this.todayRow = 0;
                this.todayCol = 0;
                return;
            }
            this.todayRow = dayToPlace[Today].Key;
            this.todayCol = dayToPlace[Today].Value;
            
        }
        public void SetRowAndColumn(int month, int viewColumnNumber)
        {
            if (month == 0||month>12)
                throw new ArgumentOutOfRangeException("month", "month must be greater than 0 and smaller than 13");
            this.ViewColumnNumber = viewColumnNumber;
            this.GridRow = (month - 1) / ViewColumnNumber;
            this.GridColumn = (month - 1) % ViewColumnNumber;
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
        /// 
        public void SetNames(int month, string culture)
        {
            this.Culture = culture;
            this.Name = GetName(year, month, 1, false, culture);
            var dayNames = new string[7];
            for (int i = 2; i < 9; i++)
            {
                string dayName = GetName(2017, 1, i, true, culture);
                dayNames[i - 2] = dayName;
            }
            this.DayNames = dayNames;
        }
        private static string GetName(int year, int month, int day, bool isDayName, string culture)
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
        public Dictionary<int, RenderDay> ArrangeDays(int year, int month, int numberOfDays, bool showHolidays)
        {
            this.Year = year;
            SetProperties(year, month);
            DayOfWeek firstDay = new DateTime(year, month, 1).DayOfWeek;
            int start = 0;
            Dictionary<int, RenderDay> days1 = new Dictionary<int, RenderDay>();
             var daysOfMonth = new int[numberOfDays];
            Enumerable.Range(1, numberOfDays).ToArray().CopyTo(daysOfMonth, 0);
            start = (int)firstDay-1;
            if (firstDay==DayOfWeek.Sunday)
            {
                start = 6;
            }
            for (int i = 0; i < daysOfMonth.Length; i++)
            {
                bool isHoliday = false;
                int day = daysOfMonth[i];
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
            this.Days = daysOfMonth;
            this.DayToPlace = days1;
           
            return days1;
        }
        private void SetProperties(int year, int month)
        {
            if (month == 2 && year % 4 != 0)
            {
                Leap = "Hidden";
            }
            else
            {
                Leap = "Visible";
            }
            if (year == DateTime.Now.Year && month == DateTime.Now.Month)
            {
                this.CurrentSquareVisibility = "Visible";
                Thickness = 100;
            }
            else
            {
                this.CurrentSquareVisibility = "Hidden";
                Thickness = 0;
            }
        }
        public void GetNumberOfDays(int month, int year)
        {
            if (month == 0 || month > 12)
                throw new ArgumentOutOfRangeException("month", "month must be greater than 0 and smaller than 13");
            int number = 0;
            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    number = 31;
                    break;
                case 2:
                    if (year % 4 == 0 )
                    {
                        number = 29;
                        break;
                    }
                    number = 28;
                    this.Button30 = "Hidden";
                    this.Button31 = "Hidden";
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    number = 30;
                    this.Button31= "Hidden";
                    break;
                default:
                    break;
            }
                 this.NumberOfDays=number;
        }
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
}
