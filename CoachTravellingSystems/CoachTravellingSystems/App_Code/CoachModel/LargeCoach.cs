using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LargeCoach
/// </summary>
public class LargeCoach : CoachInterface
{
    public LargeCoach(List<Driver> driver,Journey destination,bool service) 
    {
        this.numberOfSeats = this.totalNumberSeats;
        this.driver= driver;
        this.desintation = desintation;
        this.service = service;
    }

  

    public Journey desintation
    {
        get
        {
            return this.desintation;
        }

        set
        {
            this.desintation = value;
        }
    }

    public List<Driver> driver
    {
        get
        {
            return this.driver;
        }

        set
        {
            this.driver = value;
        }
    }

    public int numberOfDrivers
    {
        get
        {
            return this.numberOfDrivers;
        }

        set
        {
            this.numberOfDrivers = driver.Count;
        }
    }

    public bool service
    {
        get
        {
            return this.service;
        }

        set
        {
            this.service = value;
        }
    }

    public bool toiletFacilities
    {
        get
        {
            return this.toiletFacilities;
        }

        set
        {
            this.toiletFacilities = true;
        }
    }

    public ushort numberOfSeats
    {
        get
        {
            return this.numberOfSeats;
        }

        set
        {
            this.numberOfSeats = value;
        }
    }

    public List<SeatInterface> seats
    {
        get
        {
            return this.seats;
        }

        set
        {
            this.seats = value;
        }
    }

    public ushort totalNumberSeats
    {
        get
        {
            return totalNumberSeats;
        }

        set
        {
            this.totalNumberSeats = 80;
        }
    }

    public int coachNumber
    {
        get
        {
            return this.coachNumber;
        }

        set
        {
            this.coachNumber = value;
        }
    }
}