using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp
{
    /// <summary>
    /// Represents a calendar 
    /// </summary>
    interface ICalendar
    {
        /// <summary>
        /// Gets the calendar event list
        /// </summary>
        /// <param name="year">The year of the event list</param>
        /// <param name="month">The month of the event list</param>
        /// <param name="day">The day of the event list</param>
        /// <returns>The asked day's event list or null if does not exist event on that day</returns>
        Task<string> GetEvents(int year, int month, int day);
    }
}
