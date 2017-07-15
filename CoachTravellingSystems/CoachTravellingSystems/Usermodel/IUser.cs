using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    interface User
    {
        
        String username { get; set; }
        String password { get; set; }
        String firstname { get; set; }
        String lastname { get; set; }
        Boolean isStaff();
        String viewUsername(String user);
        String getPassword(String user);
        String getFirstName(String user);
        String getLastName(String user);
        String getEmail(String user);
        String getMobile(String user);
        String getAddress(String user);
    }
}
