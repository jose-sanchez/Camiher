using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;

/// <summary>
/// Summary description for UsersWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class UsersWebService : System.Web.Services.WebService {

    public UsersWebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string GetUser()
    {
        Membership.GetUser();
        return null;
    }

    [WebMethod]
    public string DeleteUser()
    {
        Membership.DeleteUser(null);
        return null;
    }

    [WebMethod]
    public string UpdateUser()
    {
        Membership.UpdateUser(null);
        return null;
    }

    [WebMethod]
    public string GetAllUser()
    {
        Membership.GetAllUsers();
        return null;
    }

    [WebMethod]
    public string CreateUser()
    {
        return "Hello World";
    }
    
}
