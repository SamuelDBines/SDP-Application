using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DebitCard
/// </summary>
public class DebitCard : PaymentInterface
{
    //New payment info
    public DebitCard(String bank, String payeeName,ulong accountNumber, ushort securityNumber,double amount)
    {
        this.bank = bank;
        this.payeeName = payeeName;
        this.accoutNumber = accoutNumber;
        this.securityNumber = securityNumber;
        this.amount = amount;
    }
    //Which bank or company 
    public string bank
    {
        get
        {
            return this.bank;
        }

        set
        {
            this.bank = value;
        }
    }
    //Name on card for payment
    public string payeeName
    {
        get
        {
            return this.payeeName;
        }

        set
        {
            this.payeeName = value;
        }
    }
    //Card account number for payment
    public ulong accoutNumber
    {
        get
        {
            return this.accoutNumber;
        }

        set
        {
            this.accoutNumber = value;
        }
    }
    //Card security number
    public ushort securityNumber
    {
        get
        {
            return this.securityNumber;
        }

        set
        {
            this.securityNumber = value;
        }
    }
    //Payable amount mutators
    public double amount
    {
        get
        {
            return this.amount;
        }
        set
        {
            this.amount = value;
        }
    }

    public ulong accountNumber
    {
        get
        {
            throw new NotImplementedException();
        }

        set
        {
            throw new NotImplementedException();
        }
    }
}