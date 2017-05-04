using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject.Repository
{
    public class UserRepository : IUserRepository
    {
        private DBAContext context;
        public UserRepository()
        {
            this.context = new DBAContext();
        }
        public List<User> GetUserList()
        {
            return context.Users.ToList();
        }
        public User GetUser(int id)
        {
            return context.Users.Find(id);
        }

        public void Create(User item)
        {
            try { 
            context.Users.Add(item);
            context.SaveChanges();
            }
        catch (Exception e)
            {
            }
        }

        public void Update(User item)
        {
           
            var user = context.Users.Where(x => x.Id == item.Id).FirstOrDefault();
            if (user != null)
            {
                try
                {
                    user.Id = item.Id;
                    user.LastName = item.LastName;
                    user.FirstName = item.FirstName;
                    user.Email = item.Email;
                    user.Position = item.Position;

                    context.SaveChanges();
                }
                catch(Exception e)
                {

                }
            }
        }

        public void Delete(int id)
        {
            User c = context.Users.Find(id);
            if (c != null)
            {
                try
                {
                    context.Users.Remove(c);
                    context.SaveChanges();
                }
                catch(Exception e)
                { }
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}