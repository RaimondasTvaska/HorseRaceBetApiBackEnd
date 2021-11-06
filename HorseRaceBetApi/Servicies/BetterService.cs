using HorseRaceBetApi.Entities;
using HorseRaceBetApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Servicies
{
    public class BetterService
    {
        private readonly BetterRepository _betterRepository;

        public BetterService(BetterRepository betterRepository)
        {
            _betterRepository = betterRepository;
        }
        public async Task<List<Better>> GetAllAsync()
        {
            var betterEntities = await _betterRepository.GetAllBettersAsync();

            return betterEntities.ToList();
        }
        public async Task<List<Better>> GetBettersByHorseAsync(int horseId)
        {
            var betterEntities = await _betterRepository.GetAllBettersByHorseAsync(horseId);

            return betterEntities.ToList();
        }
        public async Task<Better> GetByIdAsync(int id)
        {
            return await _betterRepository.GetByIdAsync(id);
        }
        public async Task<int> AddAsync(Better better)
        {

            var entity = new Better()
            {
                Name = better.Name,
                Surname = better.Surname,
                Bet = better.Bet,
                HorseId = better.HorseId
            };

            await _betterRepository.CreateAsync(entity);
            return entity.Id;
        }
        public async Task UpdateBetterAsync(Better better)
        {
            var entity = new Better()
            {
                Id = better.Id,
                Name = better.Name,
                Surname = better.Surname,
                Bet = better.Bet,
                HorseId = better.HorseId
            };
            if (better.HorseId != better.HorseId)
            {
                throw new ArgumentException("Horse not found");
            }
            await _betterRepository.UpdateBetter(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var horse = await GetByIdAsync(id);
            await _betterRepository.DeleteAsync(horse);
        }
    }
}
