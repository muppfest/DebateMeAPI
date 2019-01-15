using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DebateMeAPI.Repository;
using DebateMeAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateMeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AsdfController : ControllerBase
    {
        private IRepository<Category> repoCat;
        private IRepository<Topic> repoTopic;

        public AsdfController(IRepository<Category> repoCat, IRepository<Topic> repoTopic)
        {
            this.repoCat = repoCat;
            this.repoTopic = repoTopic;
        }
        [HttpGet]
        public JsonResult Get()
        {
            Topic t = new Topic();
            t.CategoryId = 2;
            t.Name = "Bensinpriser";

            Topic t1 = new Topic();
            t.CategoryId = 2;
            t.Name = "Skatter";

            Topic t2 = new Topic();
            t.Name = "Fildelning";
            t.CategoryId = 1;

            Topic t3 = new Topic();
            t3.Name = "GDPR";
            t3.CategoryId = 1;

            repoTopic.Insert(t);
            repoTopic.Insert(t1);
            repoTopic.Insert(t2);
            repoTopic.Insert(t3);

            repoTopic.Save();

            return new JsonResult(repoCat.GetAll());
        }
    }
}
