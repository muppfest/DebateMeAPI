using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DebateMeAPI.Repository;
using DebateMeAPI.Models;
using DebateMeAPI.ViewModels;
using Newtonsoft.Json.Linq;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IUserRepository repoUser;

        public RegisterController(IUserRepository repoUser)
        {
            this.repoUser = repoUser;
        }

        [HttpPost]
        public JsonResult Post([FromBody]JObject jObject)
        {
            var response = new RegistrationResponseViewModel();
            response.Message = "Registration successfully!";
            response.Success = true;

            var user = new User();
            user.Email = jObject["Email"].ToString();

            if(repoUser.EmailExist(user.Email))
            {
                response.Message = "Email does already exist!";
                response.Success = false;
            }

            user.FirstName = jObject["FirstName"].ToString();
            user.LastName = jObject["LastName"].ToString();
            user.PhoneNumber = jObject["PhoneNumber"].ToString();

            if (repoUser.PhoneNumberExist(user.PhoneNumber))
            {
                response.Message = "Phone number does already exist!";
                response.Success = false;
            }

            var pass = jObject["Password"].ToString();
            user.PasswordHash = NETCore.Encrypt.EncryptProvider.Sha512(pass);
            user.IsVerified = false;
            user.VerficationCode = NETCore.Encrypt.EncryptProvider.Sha1(DateTime.Now.ToString());

            if (response.Success == true)
            {
                repoUser.Insert(user);
                repoUser.Save();
            }
            return new JsonResult(response);
        }
    }
}