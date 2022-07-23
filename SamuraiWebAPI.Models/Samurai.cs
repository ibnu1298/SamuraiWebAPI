using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiWebAPI.Models
{
    public class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public List<Sword> Swords { get; set; } = new List<Sword>();
        public List<Battle> Battles { get; set; } = new List<Battle>();
    }
}
