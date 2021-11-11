using HorseRaceBetApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Repositories
{
    public interface IBetterRepository
    {
        Task CreateAsync(Better better);
        Task DeleteAsync(Better better);
        Task<List<Better>> GetAllBettersAsync();
        Task<List<Better>> GetAllBettersByHorseIdAsync(int horseId);
        Task<Better> GetByIdAsync(int id);
        Task UpdateBetter(Better better);
    }
}