using SamuraiWebAPI.Dtos.Sword;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Response
{
    public class SwordResponse
    {
        public List<Sword> Swords { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
    }
}
