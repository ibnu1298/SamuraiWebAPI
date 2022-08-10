using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public interface IDemon : ICrud<Demon>
    {
        Task<IEnumerable<Demon>> GetDemonWithElement();
        Task<IEnumerable<Demon>> GetDemonWithBattles();
    }
}
