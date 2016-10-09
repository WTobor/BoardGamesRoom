using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGamesRoom.Models
{
    public class BoardGame
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<BoardGameCategory> Categories { get; set; }
        public int NumberOfPlayers { get; set; }
    }

    public class BoardGameCategory
    {
        public int ID {get; set;}
        public string Name { get; set; }
    }
}