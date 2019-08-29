using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Models
{
    public class GameDto
    {
        public string TeamHome { get; set; }
        public string TeamAway { get; set; }
        public string Championship { get; set; }
        public string Place { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public string CustomerName { get; set; }
        public string Stadium { get; set; }
    }
}
