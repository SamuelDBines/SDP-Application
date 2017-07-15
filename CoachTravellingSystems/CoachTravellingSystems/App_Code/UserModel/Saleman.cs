using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Staff
/// </summary>
public class Salesman : User
{
    public Salesman(String username, String password)
    {
        this.username = username;
        this.password = password;
        this.person = person;
    }
    public string username
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