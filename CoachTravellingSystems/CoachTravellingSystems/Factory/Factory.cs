using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    class UserFactory
    {
        public static User userFactory(userType type)
        {
            switch (type)
            {
               case userType.Driver:
                    return new Driver();
               case userType.Salesman:
                   return new Salesman();
               case userType.Customer:
                    return new Customer();
                default:
                    return null;
            }
        }
    }
    class SeatFactory
    {
        public static Seats seatFactory(seatType type)
        {
            switch (type)
            {
                case seatType.FirstClass:
                    return new FirstClass();       
                case seatType.SecondClass:
                    return new SecondClass();
                default:
                    return null;
            }
        }
    }
    class Factory
    {
        public static PaymentInterface paymentFactory(paymentType type, String bank, String payeeName, ulong accountNumber, ushort securityNumber, double amount)
        {
            switch (type)
            {
                case paymentType.CreditCard:
         //           return new CreditCard(bank, payeeName, accountNumber, securityNumber, amount);
                case paymentType.DebitCard:
     //               return new DebitCard(bank, payeeName, accountNumber, securityNumber, amount);
                default:
                    return null;
            }
        }
    }
}
