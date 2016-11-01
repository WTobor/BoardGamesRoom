using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BoardGamesRoom.Model
{
    public class BoardGame
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MinNumberOfPlayers { get; set; }
        [Required]
        public int MaxNumberOfPlayers { get; set; }

        public virtual ICollection<BoardGameCategory> Categories { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }    
}