using HorseRaceBetApi.Entities;
using HorseRaceBetApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HorseRaceBetApi.Servicies
{
    public class HorseService
    {
        private HorseRepository _horseRepository;

        public HorseService(HorseRepository horseRepository)
        {
            _horseRepository = horseRepository;
        }
        public async Task<List<Horse>> GetAllAsync()
        {
            var horseEntities = await _horseRepository.GetAllHorsesAsync();

            return horseEntities.ToList();
        }
        public async Task<Horse> GetByIdAsync(int id)
        {
            return await _horseRepository.GetByIdAsync(id);
        }
        //public async Task<Horse> GetAllBettersByIdAsync(int id)
        //{
        //    return await _horseRepository.GetBettersByIdAsync(id);
        //}
        public async Task<int> AddAsync(Horse horse)
        {

            var entity = new Horse()
            {
                Name = horse.Name,
                Runs = horse.Runs,
                Wins = horse.Wins,
                About = horse.About
            };
            if (horse.Wins > horse.Runs)
            {

                throw new ArgumentException("Taip tikrai nebūna !!!!!");

            }
            await _horseRepository.CreateAsync(entity);
            return entity.Id;
        }
        public async Task UpdateHorseAsync(Horse horse)
        {
            var entity = new Horse()
            {
                Id = horse.Id,
                Name = horse.Name,
                Runs = horse.Runs,
                Wins = horse.Wins,
                About = horse.About,
            };
            if (horse.Wins > horse.Runs)
            {

                throw new ArgumentException("Taip tikrai nebūna !!!!!");

            }
            await _horseRepository.UpdateHorse(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var horse = await GetByIdAsync(id);
            await _horseRepository.DeleteAsync(horse);
        }
    }
}
