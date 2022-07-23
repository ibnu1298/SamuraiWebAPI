using SamuraiWebAPI.Dtos.Sword;

namespace SamuraiWebAPI.Dtos.Samurai
{
    public class ReadSamuraiSword
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReadSwordDTO> Swords { get; set; }
    }
}
