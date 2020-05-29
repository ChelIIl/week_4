using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_10_F
{
    class time
    {
        public DateTime date;

        public string new_date
        {
            get
            {
                if (date.Year % 4 != 0)
                    return "Год обычный";

                else if (date.Year % 100 != 0 && date.Year % 400 == 0)
                    return "Год обычный";

                else
                    return "Год високосный";
            }
        }

        public string prev_day()
        {
            DateTime p_date;
            p_date = date.AddDays(-1);

            return p_date.ToString();
        }

        public string next_day()
        {
            DateTime n_date;
            n_date = date.AddDays(1);

            return n_date.ToString();
        }

        public string end_month()
        {
            int daysL = DateTime.DaysInMonth(date.Year, date.Month) - date.Day;

            return daysL.ToString();
        }
    }
}