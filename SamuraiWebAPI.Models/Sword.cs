using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiWebAPI.Models
{
    public class Sword
    {
        public int Id { get; set; }
        public string Name { get; set; } = null;
        public decimal Weight { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public TypeSword TypeSword { get; set; }
    }
}
