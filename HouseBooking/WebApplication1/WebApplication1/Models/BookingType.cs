using System;

namespace WebApplication1.Models
{
    public class BookingType
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime ArrivalDateTime{ get; set; }
        public DateTime DepartureDateTime { get; set; }

    }
}
