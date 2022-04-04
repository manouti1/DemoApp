using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : ApiController
    {
        // GET api/<controller>
        [Route("Api/account/register")]
        [HttpPost]
        public object register(Registration Lvm)
        {
            try
            {
                UserManagementEntities db = new UserManagementEntities();
                UserMaster Em = new UserMaster();
                if (Em.UserId == 0)
                {
                    Em.UserName = Lvm.UserName;
                    Em.LoginName = Lvm.LoginName;
                    Em.Password = Lvm.Password;
                    Em.Email = Lvm.Email;
                    Em.ContactNo = Lvm.ContactNo;
                    Em.Address = Lvm.Address;
                    Em.IsApporved = Lvm.IsApporved;
                    Em.Status = Lvm.Status;
                    db.UserMasters.Add(Em);
                    db.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }

        [Route("Api/account/login")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            UserManagementEntities DB = new UserManagementEntities();
            var Obj = DB.Usp_Login(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Obj.Status == 0)
                return new Response { Status = "Invalid", Message = "Invalid User." };
            if (Obj.Status == -1)
                return new Response { Status = "Inactive", Message = "User Inactive." };
            else
                return new Response { Status = "Success", Message = Lg.UserName };
        }
    }
}