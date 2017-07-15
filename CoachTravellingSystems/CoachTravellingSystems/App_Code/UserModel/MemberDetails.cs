using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Person
/// </summary>
public class MemberDetails
{
    public String firstName  { get; set; }
    public String lastName { get; set; }
    public int age { get; set; }
   
    public MemberDetails(String firstName, String lastName, int age)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
   
}