using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Interfaces;
using Ianf.Gametracker.Services.Errors;
using System;

namespace Ianf.Gametracker.Repositories
{
    public class MatchEventRepository : IMatchEventRepository
    {
        protected GametrackerDbContext _dbContext { get; }

        public MatchEventRepository(GametrackerDbContext context) => _dbContext = context;

        public async Task<List<MatchEvent>> GetAllMatchEventsByUserIdAsync(UserId userId) =>
            await _dbContext.MatchEvents
                .Where(e => e.UserId == userId.Value)
                .Select(s => s.ToDomain())
                .ToListAsync();

        public Task<LanguageExt.Either<IEnumerable<Error>, int>> DeleteMatchEventAsync(MatchEvent matchEvent)
        {
            throw new System.NotImplementedException();
        }

        public async Task<LanguageExt.Either<IEnumerable<Error>, int>> AddNewMatchEventAsync(MatchEvent matchEvent)
        {
            try
            {
                var entity = matchEvent.ToEntity();
                _dbContext.MatchEvents.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity.Id;
            } 
            catch (Exception ex) 
            {
                return new List<Error> { new SqlError(ex.Message) };
            }
        }

        Task<LanguageExt.Either<IEnumerable<Error>, List<MatchEvent>>> IMatchEventRepository.GetAllMatchEventsByUserIdAsync(UserId userId)
        {
            throw new System.NotImplementedException();
        }
    }
}