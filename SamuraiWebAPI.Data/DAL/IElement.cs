using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public interface IElement :ICrud<Element>
    {
        Task<IEnumerable<Element>> GetElementWithSword();
    }
}
