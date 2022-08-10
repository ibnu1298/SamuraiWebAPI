using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public interface IBattle : ICrud<Battle>
    {
        Task<IEnumerable<Battle>> GetElementWithSword();
    }
}
