using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cal_App
{
    interface ICalendar
    {
         Task<string> GetEvents(int year, int month, int day);
    }
}
