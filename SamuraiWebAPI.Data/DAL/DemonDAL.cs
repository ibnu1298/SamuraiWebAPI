using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public class DemonDAL : IDemon
    {
        private readonly DataContext _context;

        public DemonDAL(DataContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var delete = await _context.Battles.FirstOrDefaultAsync(b => b.Id == id);
                if (delete == null) throw new Exception($"Data Battle dengan Id {id} tidak ditemukan");
                _context.Battles.Remove(delete);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Demon>> GetAll()
        {
            var results = await _context.Demons.OrderByDescending(d => d.Level).ToListAsync();
            return results;
        }

        public async Task<Demon> GetById(int id)
        {
            var result = await _context.Demons.FirstOrDefaultAsync(d => d.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Demon>> GetByName(string name)
        {
            var results = await _context.Demons.Where(d => d.Name.Contains(name)).OrderBy(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Demon>> GetDemonWithBattles()
        {
            var results = await _context.Demons.Include(s => s.Battles).OrderBy(s => s.Name).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Demon>> GetDemonWithElement()
        {
            var results = await _context.Demons.Include(d => d.Elements).OrderBy(d => d.Level).ToListAsync();
            return results;
        }

        public async Task<Demon> Insert(Demon obj)
        {
            try
            {
                _context.Demons.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Demon> Update(Demon obj)
        {
            try
            {
                var updateDemon = await _context.Demons.FirstOrDefaultAsync(d => d.Id == obj.Id);
                if (updateDemon == null)
                    throw new Exception($"Data dengan ID = {obj.Id} Tidak ditemukan");
                updateDemon.Name = obj.Name;
                updateDemon.Level = obj.Level;
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
