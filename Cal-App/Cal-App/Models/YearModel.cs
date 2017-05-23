using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Models
{
    public class YearModel : BaseModel
    {
        private int number = DateTime.Now.Year;
        private int isLeap;
        private List<MonthModel> items;
        private string culture;
        private bool isEventOn = false;
        private int viewColumnNumber;
        private int viewRowNumber;
        private string visibility;
        private bool showHolidays;
        internal string[] pathData = new string[3] { "M151,1L2416,1C2498,1,2566,68,2566,151L2566,6680C2566,6762,2498,6830,2416,6830L151,6830C69,6830,1,6762,1,6680L1,151C1,68,69,1,151,1z", "M2394,4273L5874,4273C5954,4273,6019,4339,6019,4419L6019,7274C6019,7354,5954,7420,5874,7420L2394,7420C2314,7420,2248,7354,2248,7274L2248,4419C2248,4339,2314,4273,2394,4273z", "M63,0L764,0C798,0,827,32,827,72L827,873C827,913,798,945,764,945L63,945C28,945,0,913,0,873L0,72C0,32,28,0,63,0z" };
        private string data = "M151,1L2416,1C2498,1,2566,68,2566,151L2566,6680C2566,6762,2498,6830,2416,6830L151,6830C69,6830,1,6762,1,6680L1,151C1,68,69,1,151,1z";
        private List<string> texts;
        public List<string> Texts
        {
            get
            {
                return this.texts;
            }

            set
            {
                if (this.texts != value)
                {
                    this.texts = value;
                    this.OnPropertyChanged("Texts");
                }
            }
        }
        public string Data
        {
            get
            {
                return this.data;
            }

            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged("Data");
                }
            }
        }
        private string backgroundColor= "Transparent";
        private bool isEventPopupOpen = false;
        private string eventsText= "Events from google calendar";
        public string EventsText
        {
            get
            {
                return this.eventsText;
            }
            set
            {
                if (this.eventsText != value)
                {
                    this.eventsText = value;
                    this.OnPropertyChanged("EventsText");
                }
            }
        }
        public bool IsEventPopupOpen
        {
            get
            {
                return this.isEventPopupOpen;
            }
            set
            {
                if (this.isEventPopupOpen != value)
                {
                    this.isEventPopupOpen = value;
                    this.OnPropertyChanged("IsEventPopupOpen");
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
        public int ViewRowNumber
        {
            get
            {
                return this.viewRowNumber;
            }
            set
            {
                if (this.viewRowNumber != value)
                {
                    this.viewRowNumber = value;
                    this.OnPropertyChanged("ViewRowNumber");
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
        public int Number
        {
            get
            {
                return number;
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
        public int IsLeap
        {
            get
            {
                return isLeap;
            }

            set
            {
                if (this.isLeap != value)
                {
                    this.isLeap = value;
                    this.OnPropertyChanged("IsLeap");
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
        public List<MonthModel> Items1
        {
            get
            {
                return items;
            }

            set
            {
                if (items != value)
                {
                    items = value;
                    this.OnPropertyChanged("Items1");
                }

            }
        }
        /// <summary>
        /// Initializes a new YearModel 
        /// </summary>
        /// <param name="year">The year number</param>
        /// <param name="showHolidays">The holidays/weekends to be shown/or not</param>
        /// <param name="culture">The calendar's display language</param>
        public YearModel(int year, bool showHolidays, string culture, bool isEventOn, int viewColumnNumber, int viewRowNumber, string visibility)
        {
            this.ShowHolidays = showHolidays;
            this.Number=year;
            this.IsEventOn = isEventOn;
            this.Culture = culture;
            this.ViewColumnNumber = viewColumnNumber;
            this.ViewRowNumber = viewRowNumber;
            this.Visibility = visibility;
            SetTexts(culture);
            this.items = new List<MonthModel>
        {
                new MonthModel(1, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(2, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(3, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(4, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(5, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(6, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(7, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(8, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(9, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(10, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(11, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility),
                new MonthModel(12, year, showHolidays,culture, isEventOn, viewColumnNumber,viewRowNumber, visibility)
            };
        }
        public void SetTexts(string culture)
        {
            this.Culture = culture;
            List<string> huTexts = new List<string> { "Év", "Nyelv", "Nézet", "Háttér", "Események", "Hétvégék", "Nyomtatás", "Kilépés", "Beállítások", "Beállítások mentése" };
            List<string> enTexts = new List<string> { "Year", "Language", "View", "Background", "Events", "Weekends", "Print", "Exit", "Settings","Save Settings" };
            if (Culture == "hu-HU" || Culture == "HU")
            {
                this.Texts = huTexts;
            }
            else
            this.Texts = enTexts;
        }
    }
}
