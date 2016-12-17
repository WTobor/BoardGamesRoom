using BoardGamesRoom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGamesRoom.Lib
{
    public class StatisticDataServices
    {
        private BoardGameContext db = new BoardGameContext();

        public Statistic[] GetAllStatistics()
        {
            return db.Statistics.Include("Plays").ToArray();
        }

        public Statistic GetStatistic(int ID)
        {
            return db.Statistics.Include("Plays").Where(x => x.ID == ID).FirstOrDefault();
        }
    }
}
