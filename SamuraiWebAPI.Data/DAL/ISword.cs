using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public interface ISword : ICrud<Sword>
    {
        Task<IEnumerable<Sword>> GetSwordWithSamurai();
        Task<IEnumerable<Sword>> GetSwordWithElements();
        Task<IEnumerable<Sword>> PaginationSword();
        Task DeleteElement(int id);


    }
}
