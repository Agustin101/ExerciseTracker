using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public static class Helpers
    {
        public static DateTime GetDate()
        {
            string input = Console.ReadLine();
            DateTime date;

            while (!DateTime.TryParseExact(input, "yyyy/MM/dd HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                Console.WriteLine("Invalid format. Try again");
                input = Console.ReadLine();
            }

            return date;
        }

        public static string? GetString()
        {
            string? input = Console.ReadLine();

            while (!InputValidator.IsValidString(input))
            {
                Console.WriteLine("Please enter a valid text. Try again.");
                input = Console.ReadLine();
            }

            return input;
        }
    }
}
