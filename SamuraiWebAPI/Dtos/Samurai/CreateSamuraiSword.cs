using SamuraiWebAPI.Dtos.Sword;

namespace SamuraiWebAPI.Dtos.Samurai
{
    public class CreateSamuraiSword
    {
        public string Name { get; set; }
        public List<CreateSwordDTO> Swords { get; set; }
    }
}
