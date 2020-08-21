using System;
using System.Globalization;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Start time:");
            string dateString = Console.ReadLine();  //"2019-08-31 7:10:24 am";
            DateTime dateFromStringstart =
                DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture);


            Console.Write("End time:");
            string dateString2 = Console.ReadLine();  //"2019-08-31 7:10:24 am";
            DateTime dateFromStringEnd =
                DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture);


            DateTime start = dateFromStringstart;
            DateTime end = dateFromStringEnd;

            double totalpoisa = 0;
            var peakhourstart = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 9, 0, 0);
            var peakhourend = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 22, 59, 59);
            var offpeakhourstart1 = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 23, 0, 0);
            var offpeakhourend2 = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 23, 59, 59);
            var offpeakhourstart3 = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 0, 0, 59);
            var offpeakhourend4 = new DateTime(dateFromStringstart.Year, dateFromStringstart.Month, dateFromStringstart.Day, 8, 59, 59);
            while (end > start)
            {
                start = start.AddSeconds(20);
                if (start >= peakhourstart && start <= peakhourend) totalpoisa += 30;
                if (start >= offpeakhourstart1 && start <= offpeakhourend2) totalpoisa += 20;
                if (start >= offpeakhourstart3 && start <= offpeakhourend4) totalpoisa += 20;
            }

            Console.WriteLine(Convert.ToDouble(totalpoisa / 100) + "taka");

            Console.ReadKey();
        }
    }
}