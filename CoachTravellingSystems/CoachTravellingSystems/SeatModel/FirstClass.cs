using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    class FirstClass : Seats
    {
        private double price;
        private int seatNumber;
        private bool sold;
        private bool windowSeat;
        double Seats.price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        int Seats.seatNumber
        {
            get
            {
                return seatNumber;
            }

            set
            {
                seatNumber = value;
            }
        }

        bool Seats.sold
        {
            get
            {
                return sold;
            }

            set
            {
                sold = value;
            }
        }


        bool Seats.windowSeat
        {
            get
            {
                return windowSeat;
            }

            set
            {
                windowSeat = value;
            }
        }
    }
}
