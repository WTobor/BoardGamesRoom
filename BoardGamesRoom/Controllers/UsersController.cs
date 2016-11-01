using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BoardGamesRoom.Lib;
using BoardGamesRoom.Model;

namespace BoardGamesRoom.Controllers
{
    public class UsersController : ApiController
    {
        UserDataServices userDS = new UserDataServices();

        public IEnumerable<User> Get()
        {
            User[] users = userDS.GetAllUsers();
            return users;
        }

        public IHttpActionResult Get(string id)
        { 
            User user = userDS.GetUserByLogin(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}