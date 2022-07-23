using SamuraiWebAPI.Dtos.TypeSword;

namespace SamuraiWebAPI.Dtos
{
    public class SwordElementDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public ReadDTO TypeSword { get; set; }
        public List<ReadDTO> Elements { get; set; }
    }
}
