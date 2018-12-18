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
    public class QuestionController : ControllerBase
    {
        private IRepository<Question> repoQuestion;

        public QuestionController(IRepository<Question> repoQuestion)
        {
            this.repoQuestion = repoQuestion;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(repoQuestion.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repoQuestion.GetById(id));
        }
    }
}