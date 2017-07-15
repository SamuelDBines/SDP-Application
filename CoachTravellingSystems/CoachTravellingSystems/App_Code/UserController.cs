using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserController
/// </summary>
public class UserController
{
    public static String checkLogin(String username, String password)
    {
        User user = checkUsername(username);
        if (null == user)
            return "Invalid username";
        if (checkPassword(user, password) == false)
            return "Password incorrect";
        return "Correct";
    }
    public static User checkUsername(String username)
    {
        foreach(User user in StartWebsite.userList)
        {
            if (user.username == username)
                return user;
        }
        return null;
    }
    public static Boolean checkPassword(User user, String password)
    {
          if (user.password == password)
              return true;
          else
              return false;
    }

}