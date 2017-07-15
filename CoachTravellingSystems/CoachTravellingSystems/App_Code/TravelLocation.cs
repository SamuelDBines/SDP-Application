using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Journey
/// </summary>
public class TravelLocation
{
    private String location;
    private Double price;
    private Double journeyTime;
    public TravelLocation()
    {
        
    }
    public TravelLocation(String location,Double price)
    {
        setLocation(location);
        setPrice(price);
    }
    public void setLocation(String location)
    {
        this.location = location;
    }
    public String getLocation()
    {
        return this.location;
    }
    public void setPrice(Double price)
    {
        this.price = price;
    }
    public Double getPrice()
    {
        return price;
    }
    public void setJourneyTime(Double journeyTime)
    {
        this.journeyTime = journeyTime;
    }
    public Double getJourneyTime()
    {
        return this.journeyTime;
    }
}