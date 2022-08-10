using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public interface ISamurai : ICrud<Samurai>
    {
        Task<IEnumerable<Samurai>> GetSamuraiWithSwords();
        Task<IEnumerable<Samurai>> GetSamuraiWithBattles();
        Task<IEnumerable<Samurai>> GetSamuraiWithSE();
        Task<Samurai> AddSamuraiSword(Samurai samurai);
    }
}
