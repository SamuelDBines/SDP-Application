using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CreateUserController
/// </summary>
public class CreateUserController
{

    private static User newuser;
    public static void setPersonalInformation(String fname, String lname, int age)
    {
        newuser.person = new MemberDetails(fname, lname, age);
    }
    public static void setUsersAddress(int houseNumber, String postcode, String address, String county, String country)
    {
        newuser.addressLine= new AddressLine(houseNumber, postcode, address, county, country);
    }
    public static void setContactLine(long telephoneNumber, long mobileNumber, String emailAddress)
    {
        newuser.contactLine = new ContactLine(telephoneNumber, mobileNumber, emailAddress);
    }
    public static void addUser(userType type, String username, String password, String confirm)
    {
        newuser = FactoryModel.userFactory(type, username, password);
        StartWebsite.userList.Add(newuser);
    }
    public static Boolean checkUsername(String username)
    {
        foreach(User users in StartWebsite.userList)
        {
            if(users.username == username)
            {
                return false;
            }
        }
        return true;
    }
    public static String checkPassword(String password, String confirm)
    {
        if (password != confirm)
            return "* Passwords do not match";
        if(password.Length <6 || password.Length > 30 )
            return "* Incorrect length";        
        else
            return "*";
    } 
    public static Boolean checkAge(int age)
    {
        if(age < 16 || age > 150)
        {
            return false;
        }
        return true;
    }

}