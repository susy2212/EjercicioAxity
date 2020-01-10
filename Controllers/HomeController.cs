using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Axity.Models;
using Axity.VM;

namespace Axity.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel objuserlogin)
        {
            ValuesController CC = new ValuesController();
            var obj = CC.employeeLogin(objuserlogin);
            
            if (!(obj == null))
            {
                if (obj.Status == "Success")
                {
                    ViewBag.Status = obj.Message;
                    var prod = CC.GetProducts();
                    return View("Products", prod);
                }
                else
                {
                    ViewBag.Status = obj.Message;
                }
                return View(objuserlogin);
            }
            else
            {
                var response = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Employee doesn't exist", System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.NotFound
                };
                throw new System.Web.Http.HttpResponseException(response);
            }
        }
    }
}
