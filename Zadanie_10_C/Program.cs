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

                else if(year % 100 != 0 && year % 400 == 0)
                    Console.WriteLine("\nГод обычный");

                else
                    Console.WriteLine("\nГод високосный");
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            time time = new time();
            int n;

            Console.WriteLine("Следующий день - 1" + "\nПредыдущий день - 2" + "\nСколько до конца месяца - 3" + "\nУзнать дату и/или установить новую - 4" + "\nВыйти - 5");

            while (true)
            {
                n = int.Parse(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        time.next_day();
                        break;

                    case 2:
                        time.prev_day();
                        break;

                    case 3:
                        time.end_month();
                        break;

                    case 4:
                        Console.WriteLine(time.date + "\nУствновить новую дату? (1 - да; 2 - нет)");
                        n = int.Parse(Console.ReadLine());
                        if(n == 1)
                            time.new_date = new DateTime();
                        break;

                    case 5:
                        break;
                }

                if(n == 5)
                    break;
            }

            Console.ReadKey();
        }
    }
}
