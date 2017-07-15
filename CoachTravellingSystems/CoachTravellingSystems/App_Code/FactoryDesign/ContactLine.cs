using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactLine
/// </summary>
public class ContactLine
{
    private long telephoneNumber { get; set; }
    private long mobileNumber { get; set; }
    private String emailAddress { get; set; }
    public ContactLine(long telephoneNumber, long mobileNumber, String emailAddress)
    {
        this.telephoneNumber = telephoneNumber;
        this.mobileNumber = mobileNumber;
        this.emailAddress = emailAddress;
        
    }
    public Boolean checkTelephoneNumber(long number)
    {
        if(number > 99999999999 || number < 10000000000)
        {
            return false;
        }
        return true;
    }
}