using System;
using System.Collections.Generic;
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
    /// Interaction logic for Events.xaml
    /// </summary>
    public partial class Events : UserControl
    {
        public Events()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Shuts down the Events popup
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The instance containing the event data</param>
        private void Button_ClickExitEvent(object sender, RoutedEventArgs e)
        {
            var popEvent = this.Parent as Popup;
            popEvent.IsOpen = false;
            var grid = popEvent.Parent as Grid;
            var calendar = grid.Parent as Calendar;
            var window = calendar.Parent as MainWindow;
            window.DispatcherTimer_Tick(sender,e);
        }
    }
}
