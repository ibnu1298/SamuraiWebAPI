namespace SamuraiWebAPI.Dtos.Demon
{
    public class DemonWithElementsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public List<ReadDTO> Elements { get; set; }
    }
}
