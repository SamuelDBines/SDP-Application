using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AddressLine
/// </summary>
public class AddressLine
{
    private int houseNumber { get; set; }
    private String postcode { get; set; }
    private String address { get; set; }
    private String county { get; set; }
    private String country { get; set; }

    public AddressLine(int houseNumber, String postcode, String address, String county, String country)
    {
        this.houseNumber = houseNumber;
        this.postcode = postcode;
        this.address = address;
        this.county = county;
        this.country = country;
    }
}