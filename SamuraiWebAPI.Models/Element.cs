using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiWebAPI.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Sword> Swords { get; set; } = new List<Sword>();
        public List<Demon> Demons { get; set; } = new List<Demon>();
    }
}
