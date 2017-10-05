using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.SqlClient;
using System.Configuration;
using ShipBobApp.Models;
using ShipBobDataAccess;
using ShipBobDataAccess.ViewModels;

namespace ShipBobApp.Controllers
{
    public class HomeController : Controller
    {
        private UserDataAccess _userDataAccess; 
        
        public HomeController()
        {
            _userDataAccess = new UserDataAccess();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        public void CreateUser(UserDetails userDetails)
        {

            _userDataAccess.CreateUser(userDetails);

            
        }

        public JsonResult GetUser()
        {
            List<UserDetailsVm> list = new List<UserDetailsVm>();
    
            list = _userDataAccess.ViewUser();
            
            return Json(list, JsonRequestBehavior.AllowGet) ;
        }
      
    }
}