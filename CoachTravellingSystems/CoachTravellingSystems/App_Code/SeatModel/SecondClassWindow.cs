using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Seat
/// </summary>
public class SecondClassWindowSeat : SeatInterface
{
    public SecondClassWindowSeat(int seatNumber, double price, bool sold)
    {
        this.seatNumber = seatNumber;
        this.price = price;
        this.sold = sold;
    }
    public double price
    {
        get
        {
            return this.price;
        }

        set
        {
            price = value;
        }
    }

    public int seatNumber
    {
        get
        {
            return this.seatNumber;
        }

        set
        {
            seatNumber = value;
        }
    }

    public bool sold
    {
        get
        {
            return this.sold;
        }

        set
        {
            this.sold = value;
        }
    }

    public string type
    {
        get
        {
            return this.type;
        }

        set
        {
            this.type = "Second Class Window Seat";
        }
    }
}