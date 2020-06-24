using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tessera.Models;
using AutoMapper;
using Tessera.Dtos;
using System.Data.Entity;

namespace Tessera.Controllers.Api
{
    public class UsersController : ApiController
    {
        private Context _context;

        public UsersController()
        {
            _context = new Context();
        }               
        
        // GET api/users
        public IHttpActionResult GetUsers()
        {
            var userDtos = _context.Users
                .Include(u => u.Group)
                .Include(u => u.UserStatus)
                .ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(userDtos);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}