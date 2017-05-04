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
            var result = objContext.Users.ToList();

            return Ok(result);
        }

        
        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = objContext.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPut]        
        public IHttpActionResult UpdateUser([FromBody]User putModel)
        {
            var obj = objContext.Users.Where(x => x.Id == putModel.Id).FirstOrDefault();
            if (obj == null) return BadRequest();

          
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            //Main information

            obj.FirstName = putModel.FirstName;
            obj.LastName = putModel.LastName;
            obj.Email = putModel.Email;
            obj.Position = putModel.Position;


            //Save changes
            objContext.SaveChanges();

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
          
            objContext.Users.Add(user);
            objContext.SaveChanges();

            return  Ok();
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            var obj = objContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (obj == null) return NotFound();

            //Save changes
            objContext.Users.Remove(obj);
            objContext.SaveChanges();

            return Ok();           

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                objContext.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return objContext.Users.Count(e => e.Id == id) > 0;
        }
    }
}