using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SamuraiWebAPI.Models;

namespace SamuraiWebAPI.Data.DAL
{
    public class ElementDAL : IElement
    {
        private readonly DataContext _context;

        public ElementDAL(DataContext context)
        {
            _context = context;
        }
        public async Task Delete(int id)
        {
            try
            {
                var deleteElement = await _context.Elements.FirstOrDefaultAsync(s => s.Id == id);
                if (deleteElement == null) throw new Exception($"Data Element dengan Id {id} tidak ditemukan");
                _context.Elements.Remove(deleteElement);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<IEnumerable<Element>> GetAll()
        {
            var results = await _context.Elements.OrderBy(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<Element> GetById(int id)
        {
            var result = await _context.Elements.FirstOrDefaultAsync(s => s.Id == id);
            if (result == null) throw new Exception($"Tidak ada data dengan Id = {id}");
            return result;
        }

        public async Task<IEnumerable<Element>> GetByName(string name)
        {
            var results = await _context.Elements.Where(s => s.Name.Contains(name)).OrderByDescending(s => s.Name).ToListAsync();
            return results;
        }

        public async Task<IEnumerable<Element>> GetElementWithSword()
        {
            var elementSword = await _context.Elements.Include(s => s.Swords).OrderBy(s => s.Id).ToListAsync();
            return elementSword;
        }

        public async Task<Element> Insert(Element obj)
        {
            try
            {
                _context.Elements.Add(obj);
                await _context.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<Element> Update(Element obj)
        {
            try
            {
                var updateElement = await _context.Elements.FirstOrDefaultAsync(s => s.Id == obj.Id);
                if (updateElement == null) throw new Exception($"Data dengan ID = {obj.Id} Tidak ditemukan");
                updateElement.Name = obj.Name;
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
