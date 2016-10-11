using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BoardGamesRoom.Model;
using BoardGamesRoom.Lib;

namespace BoardGamesRoom.Controllers
{
    public class BoardGamesController : ApiController
    {
        BoardGameDataServices boardGameDS = new BoardGameDataServices();

        public IEnumerable<BoardGame> Get()
        {
            BoardGame[] games = boardGameDS.GetAllBoardGames();
            return games;
        }

        public IHttpActionResult Get(int id)
        {
            BoardGame boardGame = boardGameDS.GetBoardGameByID(id);
            if (boardGame == null)
            {
                return NotFound();
            }
            return Ok(boardGame);
        }
    }
}