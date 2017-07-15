using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Ticket
/// </summary>
public class Ticket
{
    public int key { get; set; }
    public User ticketHolder;
    public CoachInterface coach;
    public SeatInterface seat;
    public Journey journey;
    public Ticket()
    {
      
    }
    public Boolean sellTicket(User ticketHolder, CoachInterface coach, SeatInterface seat, Journey journey)
    {
        if (true == seat.sold)
            return false;
        this.ticketHolder = ticketHolder;
        this.seat = seat;
        this.journey = journey;
        return true;
    }
    public int coachNumber()
    {
        return coach.coachNumber;
    }
    public int seatNumber()
    {
        return seat.seatNumber;
    }
    public String firstName()
    {
        return ticketHolder.person.firstName;
    }
    public String lastName()
    {
        return ticketHolder.person.lastName;
    }
    public String destination()
    {
        return journey.endCity;
    }
}