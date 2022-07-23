using SamuraiWebAPI.Dtos.TypeSword;

namespace SamuraiWebAPI.Dtos.Sword
{
    public class CreateSwordTypeDTO
    {
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public int SamuraiId { get; set; }
        public NameTypeSwordDTO TypeSword { get; set; }//Pemangginalan TypeSword harus sama dengan TypeSword yang ada pada SamuraiWebAPI.Models (Tidak menggunakan TypeSwords tapi TypeSword/ Case Sensitive
    }
}
