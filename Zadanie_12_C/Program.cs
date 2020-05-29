using System;

namespace Zadanie_10_C
{
    class time
    {
        public DateTime date;

        public DateTime new_date
        {
            get
            {
                return date;
            }

            set
            {
                Console.Write("День:");
                int day = int.Parse(Console.ReadLine());
                Console.Write("Год:");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Месяц:");
                int month = int.Parse(Console.ReadLine());

                date = new DateTime(year, month, day);

                Console.WriteLine(date);

                if (year % 4 != 0)
                    Console.WriteLine("\nГод обычный");

                else if (year % 100 != 0 && year % 400 == 0)
                    Console.WriteLine("\nГод обычный");

                else
                    Console.WriteLine("\nГод високосный");
            }
        }

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

        public time(int year, int month, int day)
        {
            this.date = new DateTime(year, month, day);
        }

        public time()
        {
            this.date = new DateTime(2009, 01, 1);
        }

        public void prev_day()
        {
            DateTime p_date;
            p_date = date.AddDays(-1);

            Console.WriteLine("Предыдущий день:" + p_date);
        }

        public void next_day()
        {
            DateTime n_date;
            n_date = date.AddDays(1);

            Console.WriteLine("Следующий день:" + n_date);
        }

        public void end_month()
        {
            int daysL = DateTime.DaysInMonth(date.Year, date.Month) - date.Day;

            Console.WriteLine("До конца месяца {0} дней.", daysL);
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

    class Program
    {
        static void Main(string[] args)
        {
            time time = new time();
            time da = new time();
            int n;

            Console.WriteLine("Дата 1: " + time.date + "\nДата 2: " + da.date);
            Console.WriteLine("Является ли дата 1 началом года - 1"+ "\nЯвлиется ли дата 1 концом месяца - 2" + "\nРавны ли даты 1 и 2 - 3" + "\nИз DateTime в string - 4" + "\nДата по счету дня - 5" + "\nВыйти - 6");

            while (true)
            {
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        if (time)
                            Console.WriteLine("Начало года");
                        else
                            Console.WriteLine("Не начало года");
                        break;

                    case 2:
                        if (!time)
                            Console.WriteLine("Не последний день месяца");
                        else
                            Console.WriteLine("Последний день месяца");
                        break;

                    case 3:
                        bool r = time & da;
                        if(r == true)
                            Console.WriteLine("Даты равны");
                        else
                            Console.WriteLine("Даты не равны");
                        break;

                    case 4:
                        Console.WriteLine("Дату 1 или 2?");
                        n = int.Parse(Console.ReadLine());
                        string str;
                        if (n == 1)
                            str = time.ToString(time);
                        else
                            str = da.ToString(da);
                        Console.WriteLine("Дата:" + str);
                        break;
                    case 5:
                        Console.Write("День по счету:");
                        n = int.Parse(Console.ReadLine());
                        time[n] = new DateTime();
                        Console.WriteLine("Дата по счету:" + time.date);
                        break;
                    case 6:
                        break;
                }

                if (n == 6)
                    break;
            }

            Console.ReadKey();
        }
    }
}
