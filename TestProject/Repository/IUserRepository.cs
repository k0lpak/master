using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Repository
{
  public  interface IUserRepository
    {
        List<User> GetUserList();
        User GetUser(int id);
        void Create(User item);
        void Update(User item);
        void Delete(int id);
        void Save();
    }
}
