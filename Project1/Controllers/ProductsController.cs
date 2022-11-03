using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL;
using DL;
using DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductBL productBL;
        IMapper _mapper;
        public ProductsController(IProductBL productBL, IMapper mapper)
        {
            this.productBL = productBL;
            _mapper = mapper;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetAllProducts()
        {
            List<Products> p = await productBL.getAllProducts();
            return Ok(_mapper.Map<List<Products>, List<ProductDTO>>(p));
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Products>>> GetByCategory(int id)
        {
            List<Products> p = await productBL.getByCategory(id);
            return Ok(_mapper.Map<List<Products>, List<ProductDTO>>(p));
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Products product)
        {
            await productBL.addProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
