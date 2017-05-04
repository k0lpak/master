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

namespace TestProject.Controllers
{
    public class UsersController : BaseController
    {
      
        [HttpGet]     
        public IHttpActionResult GetUser()
        {
            var result = dataContext.Users.ToList();

            return Ok(result);
        }

        
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            var user = dataContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]        
        public IHttpActionResult UpdateUser([FromBody]User putModel)
        {
            var user = dataContext.Users.Where(x => x.Id == putModel.Id).FirstOrDefault();
            if (user == null) return BadRequest();

          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Main information

            user.FirstName = putModel.FirstName;
            user.LastName = putModel.LastName;
            user.Email = putModel.Email;
            user.Position = putModel.Position;


            //Save changes
            dataContext.SaveChanges();

            return Ok("User success edited");
        }

      
        // POST: api/Users
        [ResponseType(typeof(User))]

        public IHttpActionResult PostUser(User user)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            dataContext.Users.Add(user);
            dataContext.SaveChanges();

            return  Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            var user = dataContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null) return NotFound();

            //Save changes
            dataContext.Users.Remove(user);
            dataContext.SaveChanges();

            return Ok();           

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dataContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return dataContext.Users.Count(e => e.Id == id) > 0;
        }
    }
}