using BoardGamesRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BoardGamesRoom.Controllers
{
    public class BoardGamesController : ApiController
    {
        BoardGameCategory[] categories = new BoardGameCategory[]
        {
            new BoardGameCategory {ID = 1, Name = "Strategiczne"},
            new BoardGameCategory {ID = 2, Name = "Logiczne"},
            new BoardGameCategory {ID = 3, Name = "Karcianki"}
        };

        BoardGame[] boardGames = new BoardGame[]
        {
            new BoardGame { ID = 1, Name = "Osadnicy z Catanu", Categories = new List<BoardGameCategory>(){
                new BoardGameCategory {ID = 1, Name = "Strategiczne"}, 
                new BoardGameCategory {ID = 2, Name = "Logiczne"}
            },  NumberOfPlayers = 4 },
            new BoardGame { ID = 2, Name = "Sabotażysta", Categories = new List<BoardGameCategory>(){
                new BoardGameCategory {ID = 1, Name = "Strategiczne"}, 
                new BoardGameCategory {ID = 3, Name = "Karcianki"}
            },  NumberOfPlayers = 6 },
            new BoardGame { ID = 3, Name = "Splendor", Categories = new List<BoardGameCategory>(){
                new BoardGameCategory {ID = 2, Name = "Logiczne"}
            },  NumberOfPlayers = 4 }
        };
        
        public IEnumerable<BoardGame> Get()
        {
            return boardGames;
        }

        public IHttpActionResult Get(int id)
        {
            var boardGame = boardGames.FirstOrDefault((p) => p.ID == id);
            if (boardGame == null)
            {
                return NotFound();
            }
            return Ok(boardGame);
        }
    }
}
