using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Destination
/// </summary>
public class Journey
{
   
    public String endCity { get; set; }
    public String endCountry { get; set; }
    public double tripTime { get; set; }
    public String startCity { get; set; }
    public String startCountry { get; set; }

    public Journey(String endCity,String endCountry,double tripTime,String startCity, String startCountry)
    {
        this.endCity = endCity;
        this.endCountry = endCountry;
        this.tripTime = tripTime;
        this.startCity = startCity;
        this.startCountry = startCountry;
    }
    
    public String[] getTripLeaveDate(int days)
    {
        DateTime current = System.DateTime.Now;
        TimeSpan leaveDate = new System.TimeSpan(days, 0, 0, 0);
        DateTime tripStarts = current.Add(leaveDate);
        return tripStarts.GetDateTimeFormats();
    }
    public Boolean twoDriversNeeded()
    {
        if(tripTime > 4.5)
        {
            return true;
        }
        return false;
    }
}