using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Entities
{
    public class ChampionshipEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Trophy { get; set; }
        public short Year { get; set; }
    }
}
