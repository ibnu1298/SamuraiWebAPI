using SamuraiWebAPI.Dtos.Sword;

namespace SamuraiWebAPI.Dtos
{
    public class SamuraiSwordDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SwordElementDTO> Swords { get; set; }
    }
}
