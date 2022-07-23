namespace SamuraiWebAPI.Dtos.Sword
{
    public class ReadSwordTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public ReadDTO TypeSword { get; set; }
        public int pageCount { get; set; }
    }
}
