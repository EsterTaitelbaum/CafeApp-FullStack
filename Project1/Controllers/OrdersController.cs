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
    public class OrdersController : ControllerBase
    {
        IOrderBL orderBL;
        IMapper _mapper;

        public OrdersController(IOrderBL orderBL, IMapper  mapper)
        {
            this.orderBL = orderBL;
            _mapper = mapper;
        }

        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<List<OrderDTO>> Get(int id)
        {
            List<Orders> l = await orderBL.getByUser(id);
            return _mapper.Map<List<Orders>, List<OrderDTO>>(l);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<Orders> PostOrder([FromBody] Orders order)
        {
            return await orderBL.createOrder(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
