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
        private DBAContext db = new DBAContext();

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
            User user = db.Users.Find(id);
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
            if (!Regex.IsMatch(putModel.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
           
            {
                ModelState.AddModelError("Email","Email is not correct");
                return BadRequest(ModelState);
            }
           



            //Main information

            obj.FirstName = putModel.FirstName;
            obj.LastName = putModel.LastName;
            obj.Email = putModel.Email;
            obj.Position = putModel.Position;


            //Save changes
            objContext.SaveChanges();

            return Ok(new Message("User success edited"));
        }

      
        // POST: api/Users
        [ResponseType(typeof(User))]

        public IHttpActionResult PostUser(User user)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Email
           
                if (!Regex.IsMatch(user.Email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))

            {                
                ModelState.AddModelError("Email", "Email is not correct");
                return BadRequest(ModelState);
            }
           

          
            db.Users.Add(user);
            db.SaveChanges();

            return  Ok(new Message("ok"));
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
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}