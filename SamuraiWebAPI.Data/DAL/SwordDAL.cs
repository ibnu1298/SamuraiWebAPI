using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public class SwordDAL : ISword
    {
        private readonly DataContext _context;

        public SwordDAL(DataContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteSword == null) throw new Exception($"Data Sword dengan Id {id} tidak ditemukan");
                _context.Swords.Remove(deleteSword);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task DeleteElement(int id)
        {
            try
            {
                var element = await _context.ElementSwords.Where(s => s.SwordsId == id).ToListAsync();
                if (element == null) throw new ($"Tidak ada Element pada Sword dengan Id = {id} tidak ditemukan");
                _context.ElementSwords.RemoveRange(element);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<Sword>> GetAll()
        {
            var results = await _context.Swords.OrderBy(s => s.Weight).ToListAsync();
            return results;
        }

        public async Task<Sword> GetById(int id)
        {
            var result = await _context.Swords.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new ($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Sword>> GetByName(string name)
        {
            var results = await _context.Swords.Where(s => s.Name.Contains(name)).OrderByDescending(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Sword>> GetSwordWithElements()
        {
            var swordElements = await _context.Swords.Include(s => s.Elements).OrderBy(s => s.Id).ToListAsync();
            return swordElements;
        }

        public async Task<IEnumerable<Sword>> GetSwordWithSamurai()
        {
            var swordSamurai = await _context.Swords.Include(s => s.Samurai).OrderBy(s => s.Id).ToListAsync();
            return swordSamurai;

        }

        public async Task<Sword> Insert(Sword obj)
        {
            try
            {
                _context.Swords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Sword>> PaginationSword()
        {
            var results = await _context.Swords.Include(s => s.TypeSword).OrderBy(s => s.Weight).ToListAsync();
            return results;
        }

        public async Task<Sword> Update(Sword obj)
        {
            try
            {
                var updateSword = await _context.Swords.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateSword == null) throw new ($"Data dengan ID = {obj.Id} Tidak ditemukan");
                updateSword.Name = obj.Name;
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
