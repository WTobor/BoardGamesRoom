using BoardGamesRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 

namespace BoardGamesRoom.Lib
{
    public class BoardGameDataServices
    {
        private BoardGameContext db = new BoardGameContext();

        public BoardGame[] GetAllBoardGames()
        {
            return db.BoardGames.Include(x => x.Categories).ToArray();
        }

        public BoardGame GetBoardGameByName(string Name)
        {
            return db.BoardGames.Include(x => x.Categories).Where(x => x.Name.ToLower() == Name.ToLower()).FirstOrDefault();
        }

        public void DeleteBoardGameByID(int ID)
        {
            BoardGame boardGame = db.BoardGames.Where(x => x.ID == ID).FirstOrDefault();
            db.BoardGames.Remove(boardGame);
            db.SaveChanges();
        }
    }
}
