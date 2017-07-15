using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CoachFactoryController
/// </summary>
public class FactoryModel
{
    public static CoachInterface coachFactory(coachType type, List<Driver> driver, Journey destination, bool service
        )
    {
        switch(type)
        {
            case coachType.largeCoach:
                return new LargeCoach(driver,destination,service);
            case coachType.mediumCoach:
                return new MediumCoach(driver, destination, service);
            case coachType.smallCoach:
                return new SmallCoach(driver, destination, service);
            default:
                return null;
        }
    }
    public static SeatInterface seatFactory(seatType type, int seatNumber, double price, bool sold)
    {
        switch (type)
        {
            case seatType.firstClassWindow:
                return new FirstClassWindowSeat(seatNumber, price, sold);
            case seatType.firstClassAlis:
                return new FirstClassAisleSeat(seatNumber, price, sold);
            case seatType.secondClassWindow:
                return new SecondClassWindowSeat(seatNumber, price, sold);
            case seatType.secondClassAlis:
                return new SecondClassAisleSeat(seatNumber, price, sold);
            default:
                return null;
        }
    }
    public static User userFactory(userType type, String username, String password)
    {
        switch (type)
        {
            case userType.Driver:
                return new Driver(username, password);
            case userType.Salesman:
                return new Salesman(username, password);
            case userType.Customer:
                return new Customer(username, password);
            default:
                return null;
        }
    }
    public static PaymentInterface paymentFactory(paymentType type, String bank, String payeeName, ulong accountNumber, ushort securityNumber, double amount)
    {
        switch(type)
        {
            case paymentType.CreditCard:
                return new CreditCard(bank, payeeName, accountNumber, securityNumber, amount);
            case paymentType.DebitCard:
                return new DebitCard(bank, payeeName, accountNumber, securityNumber, amount);
            default:
                return null;
        }
    }
}