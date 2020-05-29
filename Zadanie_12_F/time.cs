using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_12_F
{
    class time
    {
        public DateTime date;

        public DateTime this[int i]
        {
            get
            {
                return this.date;
            }

            set
            {
                this.date = date.AddDays(i);
            }
        }

        public static bool operator !(time a)
        {
            if (a.date.Day == 31 || a.date.Day == 30)
                return false;
            else
                return true;
        }

        public static bool operator true(time a)
        {
            if (a.date.Month == 01)
                return true;
            else
                return false;
        }

        public static bool operator false(time a)
        {
            if (a.date.Month == 01)
                return true;
            else
                return false;
        }

        public static bool operator &(time a, time b)
        {
            if (a.date == b.date)
                return true;
            else
                return false;
        }

        public string ToString(time time)
        {
            string value = time.date.ToString();
            return value;
        }

        public DateTime ToString(string time)
        {
            DateTime value = new DateTime(Convert.ToInt32(time));
            return value;
        }
    }
}
