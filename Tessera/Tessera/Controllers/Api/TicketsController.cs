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
    public class TicketsController : ApiController
    {
        private Context _context;

        public TicketsController()
        {
            _context = new Context();
        }

        //GET api/tickets

        [Route("api/GetTicketsFromUser")]
        public IHttpActionResult GetTicketsFromUser()
        {
            var user = _context.Users.SingleOrDefault(u => u.Name == User.Identity.Name);

            if (user != null)
            {
               var ticketDtos = _context.Tickets
                           .Include(t => t.Group)
                           .Include(t => t.User)
                           .Include(t => t.TicketStatus)
                           .Include(t => t.Priority)
                           .Include(t => t.TicketAction)
                           .Where(t => t.UserId == user.Id)
                           .ToList()
                           .Select(Mapper.Map<Ticket, TicketDto>);

                return Ok(ticketDtos);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);  
        }

         //GET api/tickets

        [Route("api/GetTicketsFromGroup")]
        public IHttpActionResult GetTicketsFromGroup()
        {
            var user = _context.Users.SingleOrDefault(u => u.Name == User.Identity.Name);

            if (user != null)
            {
                var ticketDtos = _context.Tickets
                          .Include(t => t.Group)
                          .Include(t => t.User)
                          .Include(t => t.TicketStatus)
                          .Include(t => t.Priority)
                          .Include(t => t.TicketAction)
                          .Where(t => t.GroupId == user.GroupId)
                          .ToList()
                          .Select(Mapper.Map<Ticket, TicketDto>);                

             return Ok(ticketDtos);
            }
            throw new HttpResponseException(HttpStatusCode.NotFound);           
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