using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiWebAPI.Models
{
    public class Demon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Battle> Battles { get; set; } = new List<Battle>();
        public List<Element> Elements { get; set; } = new List<Element>();
    }
}
