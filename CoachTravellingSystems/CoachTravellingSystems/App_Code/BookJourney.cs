using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookJourney
/// </summary>
public class BookJourney
{
    List<Ticket> soldTickets = new List<Ticket>();
    int count = 0;
    public BookJourney()
    {
        
    }
    public void bookJourney(User user, CoachInterface coach,int seatNumber)
    {
        Ticket newTicket = new Ticket();
        newTicket.sellTicket(user, coach, coach.seats[seatNumber], coach.desintation);
        soldTickets.Add(newTicket);
        count++;
    }
    public void refundTicket(int id)
    {
        for(int i = id; i < count; i++)
        {
            soldTickets[i] = soldTickets[i++];
        }
    }

    
    
}