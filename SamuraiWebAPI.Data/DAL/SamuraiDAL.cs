using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public class SamuraiDAL : ISamurai
    {
        private readonly DataContext _context;

        public SamuraiDAL(DataContext context)
        {
            _context = context;
        }

        public async Task<Samurai> AddSamuraiSword(Samurai samurai)
        {
            try
            {
                _context.Samurais.Add(samurai);
                await _context.SaveChangesAsync();
                return samurai;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var deleteSamurai = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSamurai == null) throw new Exception($"Data Samurai dengan Id {id} tidak ditemukan");
                _context.Samurais.Remove(deleteSamurai);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Samurai>> GetAll()
        {
            var results = await _context.Samurais.OrderBy(s => s.Id).ToListAsync();
            return results;
        }

        public async Task<Samurai> GetById(int id)
        {
            var result = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Samurai>> GetByName(string name)
        {
            var results = await _context.Samurais.Where(s => s.Name.Contains(name)).OrderByDescending(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Samurai>> GetSamuraiWithBattles()
        {
            var results = await _context.Samurais.Include(s => s.Battles).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Samurai>> GetSamuraiWithSE()
        {
            var results = await _context.Samurais.Include(s => s.Swords).ToListAsync();
            foreach (var sword in results)
            {
                foreach (var item in sword.Swords)
                {
                    await _context.Swords.Include(s => s.Elements).ToListAsync();
                    await _context.Swords.Include(s => s.TypeSword).ToListAsync();
                }
            }
            return results;
        }

        public async Task<IEnumerable<Samurai>> GetSamuraiWithSwords()
        {
            var results = await _context.Samurais.Include(s => s.Swords).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Samurai> Insert(Samurai obj)
        {
            try
            {
                _context.Samurais.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Samurai> Update(Samurai obj)
        {
            try
            {
                var updateSamurai = await _context.Samurais.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateSamurai == null) throw new Exception($"Data dengan ID = {obj.Id} Tidak ditemukan");
                updateSamurai.Name = obj.Name;
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {

                throw new Exception($"{ex.Message}");
            }
        }
    }
}
