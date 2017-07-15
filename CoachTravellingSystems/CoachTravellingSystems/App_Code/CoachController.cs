using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoachController
/// </summary>
public class CoachController
{
    public List<CoachInterface> coaches = new List<CoachInterface>();
    public int count = 0;
    private CoachInterface coach;
    public CoachController()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public void addCoach(coachType type)
    {
        coach = FactoryModel.coachFactory(type, null,null, false);
        coach.coachNumber = count;
        addSeats();
        coaches.Add(coach);
        count++;
    }
    public void addSeats()
    {
        Boolean odd = false;
        for(int i = 0; i < coach.totalNumberSeats; i++)
        {
            if (false == odd)
            {
                if (i < 12)
                    coach.seats.Add(FactoryModel.seatFactory(seatType.firstClassWindow, i, 20.00, false));
                else
                    coach.seats.Add(FactoryModel.seatFactory(seatType.secondClassWindow, i, 10.00, false));
                odd = true;
            } else
            {
                if (i < 12)
                    coach.seats.Add(FactoryModel.seatFactory(seatType.firstClassAlis, i, 20.00, false));
                else
                    coach.seats.Add(FactoryModel.seatFactory(seatType.secondClassAlis, i, 10.00, false));
                odd = false;
            }
            
        }
        
    }
    public Boolean sellSeat(int coachNumber, int seatNumber)
    {
        coach = coaches[coachNumber];
        if (true == coach.seats[seatNumber].sold)            
            return false;
        coach.numberOfSeats--;
        return coach.seats[seatNumber].sold = true;
    }
    public Boolean coachIsFull(int coachNumber)
    {
        coach = coaches[coachNumber];
        if (coach.numberOfSeats == 0)
            return true;
        return false;
    }
    public Boolean addDriver(int coachNumber, List<Driver> driver)
    {
        if (driver.Count > 2)
            return false;
        coaches[coachNumber].driver = driver;
        return true;
    }
    public Boolean addJourney(int coachNumber, Journey journey)
    {
        if (null == journey)
            return false;
        coaches[coachNumber].desintation = journey;
        return true;
    }
    public Boolean inService(int coachNumber)
    {
        if (true == coaches[coachNumber].service)
            return false;
        return true;
    }
}