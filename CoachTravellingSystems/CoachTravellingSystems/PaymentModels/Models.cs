using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    
    public interface PaymentInterface
    {
        String bank { get; set; }
        String payeeName { get; set; }
        ulong accountNumber { get; set; }
        ushort securityNumber { get; set; }
        double amount { get; set; }
    }
}
