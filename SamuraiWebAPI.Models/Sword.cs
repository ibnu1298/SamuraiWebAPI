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
        public string Name { get; set; }
        public Samurai Samurai { get; set; }
        public int SamuraiId { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public TypeSword TypeSM { get; set; }
    }
}
