using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public class TypeSwordDAL : ITypeSword
    {
        private readonly DataContext _context;

        public TypeSwordDAL(DataContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteStype = await _context.TypeSwords.FirstOrDefaultAsync(t => t.Id == id);
                if (deleteStype == null) throw new Exception($"Data Samurai dengan Id {id} tidak ditemukan");
                _context.TypeSwords.Remove(deleteStype);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<TypeSword>> GetAll()
        {
            var results = await _context.TypeSwords.OrderBy(t => t.Id).ToListAsync();
            return results;
        }

        public async Task<TypeSword> GetById(int id)
        {
            var result = await _context.TypeSwords.FirstOrDefaultAsync(t => t.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<TypeSword>> GetByName(string name)
        {
            var results = await _context.TypeSwords.Where(t => t.Name.Contains(name)).OrderBy(t => t.Name).ToListAsync();
            return results;
        }

        public async Task<TypeSword> Insert(TypeSword obj)
        {
            try
            {
                _context.TypeSwords.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<TypeSword> Update(TypeSword obj)
        {
            try
            {
                var updateType = await _context.TypeSwords.FirstOrDefaultAsync(t => t.Id == obj.Id);
                if (updateType == null) throw new Exception($"Data dengan ID = {obj.Id} Tidak ditemukan");
                updateType.Name = obj.Name;
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
