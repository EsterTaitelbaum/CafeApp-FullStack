using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
        ICategoryBL categoryBL;
        IMapper _mapper;

        public CategoryController(ICategoryBL categoryBL)
        {
            this.categoryBL = categoryBL;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Categories>> Get()
        {
            return await categoryBL.getAllCategories();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<CategoryController>
        [HttpPost]
        public async Task Post([FromBody] Categories category)
        {
            await categoryBL.addCategory(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
