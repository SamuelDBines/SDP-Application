using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Driver
/// </summary>
public class Driver : User
{
    public Driver(String username, String password)
    {
        this.username = username;
        this.password = password;
    }
    public String username
    {
        get
        {
            return this.username;
        }

        set
        {
            this.username = value;
        }
    }

    public string password
    {
        get
        {
            return this.password;
        }

        set
        {
            this.password = value;
        }
    }
    public Ticket ticket
    {
        get
        {
            return this.ticket;
        }

        set
        {
            this.ticket = value;
        }
    }
    public MemberDetails person
    {
        get
        {
            return this.person;
        }

        set
        {
            this.person = value;
        }
    }
    public bool staffMember()
    {
        return true;
    }
    public AddressLine addressLine
    {
        get
        {
            return this.addressLine;
        }

        set
        {
            this.addressLine = value;
        }
    }

    public ContactLine contactLine
    {
        get
        {
            return this.contactLine;
        }

        set
        {
            this.contactLine = value;
        }
    }
}