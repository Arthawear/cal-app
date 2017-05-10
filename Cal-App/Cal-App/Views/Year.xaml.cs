using Cal_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cal_App.Views
{
    /// <summary>
    /// Interaction logic for Year.xaml
    /// </summary>
    public partial class Year : UserControl, INotifyPropertyChanged
    {
        public static readonly DependencyProperty YearNumberProperty;
        public int YearNumber
        {
            get
            {
                return (int)GetValue(YearNumberProperty);
            }

            set
            {
                SetValue(YearNumberProperty, (int)value);
            }
        }
        private YearModel yearToCal=new YearModel(DateTime.Now.Year,false, CultureInfo.CurrentCulture.ToString(), false);
        private bool showHolidays = false;
        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private bool isEventOn = false;
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
        public event PropertyChangedEventHandler PropertyChanged;
        public YearModel YearToCal
        {
            get
            {
                return this.yearToCal;
            }
            set
            {
                if (this.yearToCal != value)
                {
                    this.yearToCal = value;
                    this.OnPropertyChanged("YearToCal");
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
        static Year()
        {
            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata(DateTime.Now.Year);
            metadata.AffectsArrange = true;
            metadata.AffectsMeasure = true;
            metadata.AffectsParentArrange = true;
            metadata.AffectsParentMeasure = true;
            metadata.AffectsRender = true;
            YearNumberProperty = DependencyProperty.Register("YearNumber", typeof(int), typeof(Year), metadata);
        }
        public Year()
        {
            InitializeComponent();
            CultureInfo current = CultureInfo.CurrentCulture;
            //CultureInfo current = new CultureInfo("hu-HU",false);
            Culture = current.ToString();
        }
        /// <summary>
        /// Initializes by a new YearModel new MonthModels for (Month) DataContexts 
        /// </summary>
        /// <param name="year">New year number</param>
        /// <param name="culture">New calendar display language</param>
        /// <returns>YearModel</returns>
        public YearModel RunYear(int year, string culture, bool isEventOn)
        {
            this.YearNumber = year;
            this.IsEventOn = isEventOn;
            this.Culture = culture;
            YearModel months = new YearModel(year, ShowHolidays, culture, isEventOn);
            this.YearToCal = months;
            this.DataContext = months;
            return months;
        }
        
    }
}
