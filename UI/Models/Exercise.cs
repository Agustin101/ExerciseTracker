using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public TimeSpan Duration { get { return CalculateDuration(); } }
        public string Comments { get; set; }

        private TimeSpan CalculateDuration()
        {
            var result = endDate - startDate;
            return result;
        }
    }
}
