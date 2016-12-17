using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRoom.Model
{
    public class Statistic
    {
        public int ID { get; set; }
        
        public virtual ICollection<Play> Plays { get; set; }
    }

    public class Play
    {
        public int ID { get; set; }
        [Required]
        public DateTimeOffset Date { get; set; }
        [Required]
        public string Winner { get; set; }
        [Required]
        public int BoardGameID { get; set; }
        [Required]
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Statistic> Statistics { get; set; }
        public virtual BoardGame BoardGame { get; set; }
    }

    public class Player
    {
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int Points { get; set; }
        [Required]
        public int Ranking { get; set; }
        public virtual ICollection<Play> Plays { get; set; }
    }
}
