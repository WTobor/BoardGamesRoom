using BoardGamesRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRoom.Lib
{
    public class UserDataServices
    {
        private BoardGameContext db = new BoardGameContext();

        public User[] GetAllUsers()
        {
            return db.Users.ToArray();
        }

        public User GetUserByLogin(string Login)
        {
            return db.Users.Where(x => x.Login.ToLower() == Login.ToLower()).FirstOrDefault();
        }
    }
}
