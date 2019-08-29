using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketsCorinthiansCore.Entities
{
    public class TeamEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public virtual ICollection<GameEntity> Games { get; set; }
    }
}
