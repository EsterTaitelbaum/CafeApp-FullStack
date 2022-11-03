using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities;
using Newtonsoft.Json;
using System.IO;
using BL;
using Microsoft.Extensions.Logging;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //string path = @"D:\\יד סימסטר א\\WebApi\\Project1\\UsersFile.txt";
        IUserBL userBL;
        ILogger<UserController> _logger;
        IMapper _mapper;
        public UserController(IUserBL userBL, ILogger<UserController> logger, IMapper mapper)
        {
            this.userBL = userBL;
            _logger = logger;
            _mapper = mapper;
        }



        // GET: api/<UserController1>
        //[Rout("[action]")]
        [HttpGet("{email}/{pass}")]

        public async Task<ActionResult<Users>> Login(string email, string pass)
        {
            _logger.LogInformation($"a user log in with email {email} and password {pass}");
            Users user = await userBL.getUser(email, pass);
            if (user == null)
                return NoContent();
            return Ok(_mapper.Map<Users,UserDTO>(user));
        }
       
        // GET api/<UserController1>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController1>
        [HttpPost]
        public async Task Post([FromBody] Users user)
        {
            await userBL.createUser(user);
        }

        // PUT api/<UserController1>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Users userToUpdate)
        {
            await userBL.updateDetails(id, userToUpdate);
        }

        // DELETE api/<UserController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
