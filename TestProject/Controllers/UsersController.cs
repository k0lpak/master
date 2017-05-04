using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TestProject;
using TestProject.Models;
using TestProject.Repository;

namespace TestProject.Controllers
{
    public class UsersController : ApiController
    {
        IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]     
        public IHttpActionResult GetUser()
        {
            var result = _repository.GetUserList();

            return Ok(result);
        }

        
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = _repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
           
        }

        [HttpPut]        
        public IHttpActionResult UpdateUser([FromBody]User putModel)
        {
                     
            _repository.Update(putModel);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok();
        }

      
        // POST: api/Users
        [ResponseType(typeof(User))]

        public IHttpActionResult PostUser(User user)
        {
            _repository.Create(user);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return  Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            _repository.Delete(id);
           

            return Ok();           

        }

       
    }
}