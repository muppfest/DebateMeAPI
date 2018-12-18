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
    public class CategoryController : ControllerBase
    {
        private IRepository<Category> repoCategory;

        public CategoryController(IRepository<Category> repoCategory)
        {
            this.repoCategory = repoCategory;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(repoCategory.GetAll());
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return new JsonResult(repoCategory.GetById(id));
        }
    }
}