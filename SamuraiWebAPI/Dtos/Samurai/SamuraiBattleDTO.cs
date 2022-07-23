namespace SamuraiWebAPI.Dtos
{
    public class SamuraiBattleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReadDTO> Battles { get; set; }
    }
}
