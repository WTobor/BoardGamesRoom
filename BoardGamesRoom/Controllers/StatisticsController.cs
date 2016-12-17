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
    public class StatisticsController : ApiController
    {
        StatisticDataServices StatisticDS = new StatisticDataServices();

        public IEnumerable<Statistic> Get()
        {
            Statistic[] Statistics = StatisticDS.GetAllStatistics();
            return Statistics;
        }

        public IHttpActionResult Get(int id)
        {
            Statistic statistic = StatisticDS.GetStatistic(id);
            if (statistic == null)
            {
                return NotFound();
            }
            return Ok(statistic);
        }
    }
}