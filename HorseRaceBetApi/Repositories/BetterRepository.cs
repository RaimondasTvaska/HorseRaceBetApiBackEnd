using HorseRaceBetApi.Data;
using HorseRaceBetApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Repositories
{
    public class BetterRepository
    {
        private readonly DataContext _context;

        public BetterRepository(DataContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(Better better)
        {
            _context.Add(better);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Better>> GetAllBettersAsync()
        {
            return await _context.Betters.Include(h => h.Horse).ToListAsync();
        }
        public async Task<Better> GetByIdAsync(int id)
        {
            return await _context.Betters.FirstOrDefaultAsync(b => b.Id == id);
        }
        public async Task UpdateBetterAsync(Better better)
        {
            _context.Update(better);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Better better)
        {
            _context.Remove(better);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Better>> GetAllBettersByHorseIdAsync(int horseId)
        {
            return await _context.Betters.Include(h => h.Horse).Where(a => a.HorseId == horseId).ToListAsync();
        }
    }
}
