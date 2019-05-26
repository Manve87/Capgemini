using Capgemini.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Capgemini.Controllers.Api
{
    public class UsersController : ApiController
    {
        private MyDbContext _context;

        public UsersController()
        {
            _context = new MyDbContext();
        }
        //GET api/Users

        public IEnumerable<User> GetTasks()
        {
            return _context.users.ToList();
        }
        //GET api/Users/{id}
        public User GetUser(int id)
        {
            var user = _context.users.SingleOrDefault(t => t.id == id);
            if (user == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return user;
        }
        //POST /api/Users
        [HttpPost]
        public User NewUser(User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }
        //PUT /api/Users/{id}
        [HttpPut]
        public void UpdateUser(int id, User user)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var UserInDb = _context.users.SingleOrDefault(t => t.id == id);

            if (UserInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            UserInDb.userName = user.userName;
            _context.SaveChanges();
        }
        // DELETE /api/Users/{id}
        [HttpDelete]
        public void DeleteUser(int id)
        {
            var UserInDb = _context.users.SingleOrDefault(t => t.id == id);

            if (UserInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.users.Remove(UserInDb);
            _context.SaveChanges();
        }
    }
}
