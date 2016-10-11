using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesRoom.Model
{
    public class BoardGameCategory
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<BoardGame> BoardGames { get; set; }
    }
}