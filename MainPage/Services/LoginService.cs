using MainPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

public class LoginService
{
    public bool Login(string username, string password)
    {
        // Validate the username and password (you can replace this with your own logic)
        if (username == "admin" && password == "password")
        {
            return true; // Successful login
        }
        else
        {
            return false; // Failed login
        }
    }
}
