using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public interface User
{
    bool staffMember();
    String username { get; set; }
    String password { get; set;  }
    MemberDetails person { get; set; }
    AddressLine addressLine { get; set; }
    ContactLine contactLine { get; set; }
    Ticket ticket { get; set; }
}
public interface SeatInterface
{
    int seatNumber { get; set; }
    String type { get; set; }
    Double price { get; set; }
    Boolean sold { get; set; }
}
public interface PaymentInterface
{
    String bank { get; set; }
    String payeeName { get; set; }
    ulong accountNumber { get; set; }
    ushort securityNumber { get; set; }
    double amount { get; set; }
}
public interface CoachInterface
{
    int coachNumber { get; set; }
    int numberOfDrivers { get; set; }
    ushort numberOfSeats { get; set; }
    ushort totalNumberSeats { get; set; }
    List<Driver> driver { get; set; }
    Journey desintation { get; set; }
    bool service { get; set; }
    bool toiletFacilities { get; set; }
    List<SeatInterface> seats { get; set; }
}