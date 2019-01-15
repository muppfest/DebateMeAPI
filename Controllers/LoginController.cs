using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using DebateMeAPI.ViewModels;
using DebateMeAPI.Repository;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private IUserRepository repoUser;

        public LoginController(IUserRepository repoUser)
        {
            this.repoUser = repoUser;
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jsonString)
        {
            var response = new LoginResponseViewModel();
            response.Success = false;
            response.Message = "Email or password is wrong!";

            var email = jsonString["Email"].ToString();
            var password = jsonString["Password"].ToString();
            var passwordHash = NETCore.Encrypt.EncryptProvider.Sha512(password);

            if(repoUser.Login(email, passwordHash))
            {
                response.UserId = repoUser.GetIdByEmail(email);
                response.Success = true;
                response.Message = "Login successful!";

                var token = NETCore.Encrypt.EncryptProvider.Sha512(email);
                HttpContext.Session.SetString("Id", token);
                response.Token = token;
            }

            return new JsonResult(response);
        }
    }
}
