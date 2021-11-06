using HorseRaceBetApi.Data;
using HorseRaceBetApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Repositories
{
    public class HorseRepository
    {
        private readonly DataContext _context;

        public HorseRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Horse horse)
        {
            _context.Add(horse);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Horse>> GetAllHorsesAsync()
        {
            return await _context.Horses.ToListAsync();
        }
        public async Task<Horse> GetByIdAsync(int id)
        {
            return await _context.Horses.FirstOrDefaultAsync(h => h.Id == id);
        }
        public async Task UpdateHorse(Horse horse)
        {
            _context.Update(horse);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Horse horse)
        {
            _context.Remove(horse);
            await _context.SaveChangesAsync();
        }
        //public async Task<Horse> GetBettersByIdAsync(int id)
        //{
        //    return await _context.Horses.Include(b => b.Betters).FirstOrDefaultAsync(h => h.Id == id);
        //}

    }
}
