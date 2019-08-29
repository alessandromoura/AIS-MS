using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Entities
{
    public class GameEntity
    {
        public Guid Id { get; set; }
        public Guid TeamHomeId { get; set; }
        public Guid TeamAwayId { get; set; }
        public Guid StadiumId { get; set; }
        public Guid ChampionshipId { get; set; }

        public TeamEntity TeamHome { get; set; }
        public TeamEntity TeamAway { get; set; }
        public StadiumEntity Stadium { get; set; }
        public ChampionshipEntity Championship { get; set; }
    }
}
