using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DebateMeAPI.Models;
using DebateMeAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DebateMeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private IRepository<Topic> repoTopic;
    
        public TopicController(IRepository<Topic> repoTopic)
        {
            this.repoTopic = repoTopic;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(repoTopic.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repoTopic.GetById(id));
        }
    }
}