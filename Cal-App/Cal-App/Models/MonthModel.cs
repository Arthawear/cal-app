using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Models
{
    /// <summary>
    /// Implements a month
    /// </summary>
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
        private string[] dayNames;
        private string leap;
        private bool isEventOn = false;
        string[] colors = new string[12] { "#008DD2", "#393185", "#57A7B3", "#61A375", "#009846", "#DCCF73", "#E31E24", "#E5097F", "#EF7F1A", "#CC6F3C", "#B2AD81", "#7690C9" };
        private int gridRow;
        private int gridColumn;
        private string visibility;
        private string currentSquareVisibility;
        /// <summary>
        /// The display language of the calendar
        /// </summary>
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
        /// <summary>
        /// The visibility of square for indicate the current day
        /// </summary>
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
        /// <summary>
        /// The visibility of the month 
        /// </summary>
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
        /// <summary>
        /// The month's number of row in grid in different views
        /// </summary>
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
        /// <summary>
        /// The month's number of column in grid in different views
        /// </summary>
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
        /// <summary>
        /// The event task enabled/disabled
        /// </summary>
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
                    this.isEventOn = value;
                    this.OnPropertyChanged("IsEventOn");
                }
            }
        }
        /// <summary>
        /// The weekdays names in the set language
        /// </summary>
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
        /// <summary>
        /// The visibility of button for the 30th day of the month
        /// </summary>
        public string Button30 { get; set; }
        /// <summary>
        /// The visibility of button for the 31th day of the month
        /// </summary>
        public string Button31 { get; set; }
        /// <summary>
        /// The name of the month
        /// </summary>
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
        /// <summary>
        /// a month's days with the column and row number of each day in the grid, and the color indicating the weekend/weekdays
        /// </summary>
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
        /// <summary>
        /// The thickness of the square indicating the current day
        /// </summary>
        public int Thickness { get; set; }
        /// <summary>
        /// The current day's number
        /// </summary>
        public int Today { get; set; }
        /// <summary>
        /// The current day's row number in grid
        /// </summary>
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
        /// <summary>
        /// The current day's column number in grid
        /// </summary>
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
        /// <summary>
        /// The visibility of button for the 29th day of the month
        /// </summary>
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
        /// <summary>
        /// The days of the month
        /// </summary>
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
        /// <summary>
        /// The number of days of the month
        /// </summary>
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
        /// <summary>
        /// The number of the month
        /// </summary>
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
        /// <summary>
        /// The weekends display in different color/or not
        /// </summary>
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
        /// <summary>
        /// The year of the month
        /// </summary>
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
        /// <summary>
        /// The background color of the month
        /// </summary>
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
        /// <param name="isEventOn">The event task enabled/disabled</param>
        /// <param name="viewColumnNumber">The calendar display column number</param>
        /// <param name="viewRowNumber">The calendar display row number</param>
        /// <param name="visibility">The visibility of the Month UIElement</param>
        public MonthModel(int month, int year, bool showHolidays, string culture, bool isEventOn, int viewColumnNumber, int viewRowNumber, string visibility)
        {
            if (month == 0 || month > 12)
                throw new ArgumentOutOfRangeException("month", "month must be greater than 0 and smaller than 13");
            this.Visibility = visibility;
            this.IsEventOn = isEventOn;
            this.Culture = culture;
            this.number = month;
            Today = DateTime.Now.Day;
            this.Year = year;
            this.showHolidays = showHolidays;
            this.BackgroundColor = colors[month - 1];
            GetNumberOfDays(month, year);
            ArrangeDays(year, month, this.NumberOfDays, showHolidays);
            SetRowAndColumn(this.Number, viewColumnNumber, viewRowNumber);
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
        /// <summary>
        /// Sets the view of the calendar depending on the display options
        /// </summary>
        /// <param name="month">The number of the month</param>
        /// <param name="viewColumnNumber">The number of the columns of the calendar</param>
        /// <param name="viewRowNumber">The number of the rows of the calendar</param>
        public void SetRowAndColumn(int month, int viewColumnNumber, int viewRowNumber)
        {
            if (month == 0 || month > 12)
                throw new ArgumentOutOfRangeException("month", "month must be greater than 0 and smaller than 13");
            int currentMonth = DateTime.Now.Month;
            if (viewColumnNumber == 1)
            {
                this.Visibility = "Collapsed";
                GridColumn = 0;
                if (viewRowNumber == 1 && month == currentMonth)
                {
                    GridRow = 0;
                    this.Visibility = "Visible";
                }
                else if (viewRowNumber == 3)
                {
                    SetThreeMonthsView(month);
                }
            }
            else
            {
                this.GridRow = (month - 1) / viewColumnNumber;
                this.GridColumn = (month - 1) % viewColumnNumber;
            }
        }
        /// <summary>
        /// Sets the calendar view for the three months option
        /// </summary>
        /// <param name="month">The number of the month</param>
        private void SetThreeMonthsView(int month)
        {
            int currentMonth = DateTime.Now.Month;
            if (month >= currentMonth - 1 && month <= currentMonth + 1)
            {
                this.Visibility = "Visible";
                this.GridRow = this.Number - (currentMonth - 1);
            }
            int currentYear = DateTime.Now.Year;
            if (currentMonth == 1&& this.Number==12)
            {
                this.ArrangeDays((currentYear - 1), 12, 31, ShowHolidays);
                this.Visibility = "Visible";
                this.GridRow = 0;
            }
            else if (currentMonth == 12&& this.Number == 1)
            {
                this.ArrangeDays((currentYear + 1), 1, 31, ShowHolidays);
                this.Visibility = "Visible";
                this.GridRow = 2;
            }
        }
        /// <summary>
        /// Sets the name of the month and the weekdays
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
        /// <summary>
        /// Gets the name of the month or the weekdays
        /// </summary>
        /// <param name="year">The number of year</param>
        /// <param name="month">The number of month</param>
        /// <param name="day">The number of day</param>
        /// <param name="isDayName">Shows if is day name or month name</param>
        /// <param name="culture">The calendar display language</param>
        /// <returns></returns>
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
        public void ArrangeDays(int year, int month, int numberOfDays, bool showHolidays)
        {
            this.ShowHolidays = showHolidays;
            this.Year = year;
            SetProperties(year, month);
            DayOfWeek firstDay = new DateTime(year, month, 1).DayOfWeek;
            int start = 0;
            Dictionary<int, RenderDay> days1 = new Dictionary<int, RenderDay>();
             var daysOfMonth = new int[numberOfDays];
            Enumerable.Range(1, numberOfDays).ToArray().CopyTo(daysOfMonth,0);
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
        }
        /// <summary>
        /// Sets the properties of the month
        /// </summary>
        /// <param name="year">The number of year</param>
        /// <param name="month">The number of month</param>
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
        /// <summary>
        /// Gets the number of the days of a month
        /// </summary>
        /// <param name="month">The number of month</param>
        /// <param name="year">The number of year</param>
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
