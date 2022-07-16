using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiWebAPI.Models
{
    public class Battle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Samurai> Samurais { get; set; } = new List<Samurai>();
        public List<Demon> Demons { get; set; } = new List<Demon>();
    }
}
