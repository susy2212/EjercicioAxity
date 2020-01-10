using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Axity.Models;
using Axity.VM;

namespace Axity.Controllers
{
    [RoutePrefix("Api/login")]
    public class ValuesController : ApiController
    {
        EJERCICIOSEntities DB = new EJERCICIOSEntities();

        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(LoginModel login)
        {
            var log = DB.Users.Where(x => x.Usuario.Equals(login.Usuario) && x.Password.Equals(login.Password)).FirstOrDefault();
            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Usuario y Password invalido" };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }

        [HttpGet]
        public IEnumerable<Products> GetProducts()
        {
            var listOfProducts = (from x in DB.Products select x).ToList();
            return listOfProducts;

        }
    }
}
