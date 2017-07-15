using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    interface Seats
    {
        int seatNumber { get; set; }
        //String type { get; set; }
        Double price { get; set; }
        Boolean sold { get; set; }
        Boolean windowSeat { get; set; }
    }
}
