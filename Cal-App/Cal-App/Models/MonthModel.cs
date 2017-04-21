using System;
using System.Collections.Generic;
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
        private DayOfWeek firstDay;
        private int[] days;
        private int number;
        private Dictionary<int, RenderDay> dayToPlace = new Dictionary<int, RenderDay>();
        private bool showHolidays;
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

        public MonthModel(int month, int year, bool showHolidays)
        {
            this.number = month;
            Today = DateTime.Now.Day;
            this.firstDay = new DateTime(year, month, 1).DayOfWeek;
            int currentMonth = DateTime.Now.Month;
            int currentYear = DateTime.Now.Year;
            this.Year = year;
            this.showHolidays = showHolidays;
            int start = 0;
            switch (month)
            {
                case 1:
                    this.numberOfDays = 31;
                    this.name = "Január";
                    this.backgroundColour = "#008DD2";
                    if (currentMonth == 1)
                    {
                        Thickness = 100;

                    }
                    break;
                case 2:
                    this.name = "Február";
                    this.backgroundColour = "#393185";
                    if (currentMonth == 2)
                    {
                        Thickness = 100;
                    }
                    if (year % 4 == 0)
                    {
                        this.numberOfDays = 29;
                        this.Leap = "29";
                    }
                    else
                        this.numberOfDays = 28;
                    break;
                case 3:
                    this.name = "Március";
                    this.backgroundColour = "#57A7B3";
                    if (currentMonth == 3)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                case 4:
                    this.name = "Április";
                    this.backgroundColour = "#61A375";
                    if (currentMonth == 4)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 30;
                    break;
                case 5:
                    this.name = "Május";
                    this.backgroundColour = "#009846";
                    if (currentMonth == 5)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                case 6:
                    this.name = "Június";
                    this.backgroundColour = "#DCCF73";
                    if (currentMonth == 6)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 30;
                    break;
                case 7:
                    this.name = "Július";
                    this.backgroundColour = "#E31E24";
                    if (currentMonth == 7)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                case 8:
                    this.name = "Augusztus";
                    this.backgroundColour = "#E5097F";
                    if (currentMonth == 8)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                case 9:
                    this.name = "Szeptember";
                    this.backgroundColour = "#EF7F1A";
                    if (currentMonth == 9)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 30;
                    break;
                case 10:
                    this.name = "Október";
                    this.backgroundColour = "#CC6F3C";
                    if (currentMonth == 10)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                case 11:
                    this.name = "November";
                    this.backgroundColour = "#B2AD81";
                    if (currentMonth == 11)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 30;
                    break;
                case 12:
                    this.name = "December";
                    this.backgroundColour = "#7690C9";
                    if (currentMonth == 12)
                    {
                        Thickness = 100;
                    }
                    this.numberOfDays = 31;
                    break;
                default:
                    break;
            }
            if (year != currentYear)
            {
                Thickness = 0;
            }
            this.days = new int[numberOfDays];
            Enumerable.Range(1, numberOfDays).ToArray().CopyTo(this.days, 0);
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
            for (int i = 0; i < this.days.Length; i++)
            {
                bool isHoliday = false;
                int day = this.days[i];
                int place = start + i;

                DayOfWeek currentDayOfWeek = new DateTime(year, month, day).DayOfWeek;
                var holyday = new DateTime(year, month, day).DayOfYear;
                if (currentDayOfWeek == DayOfWeek.Saturday ^ currentDayOfWeek == DayOfWeek.Sunday)
                {
                    isHoliday = true;
                }
                string color = "#FEFEFE";

                if (isHoliday && showHolidays)
                {
                    color = "#2B2A29";
                }
                dayToPlace.Add(day, new RenderDay() { Key = place / 7 + 2, Value = place % 7, Color = color });
            }
            this.todayRow = dayToPlace[Today].Key;
            this.todayCol = dayToPlace[Today].Value;
        }
        public class RenderDay
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public string Color { get; set; }

        }

    }
}
