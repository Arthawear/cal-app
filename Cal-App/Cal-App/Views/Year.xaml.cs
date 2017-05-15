using CalApp.Models;
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

namespace CalApp.Views
{
    /// <summary>
    /// Interaction logic for Year.xaml
    /// </summary>
    public partial class Year: UserControl 
    {
        public Year()
        {
            InitializeComponent();
            foreach (var item in bigGrid.Children)
            {
                var month = item as Month;
                Binding binding = new Binding();
                binding.Source = this;
                binding.Path = new PropertyPath("DataContext");
                month.eventsToCalendar.SetBinding(DataContextProperty, binding);
            }
        }
    }
}
