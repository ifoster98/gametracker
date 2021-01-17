using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Errors;
using Ianf.Gametracker.Services.Interfaces;
using LanguageExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Ianf.Gametracker.Services.Domain.Validator;

namespace Ianf.Gametracker.Services
{
    public class MatchEventService : IMatchEventService
    {
        private readonly IMatchEventRepository _matchEventRepository;

        public MatchEventService(IMatchEventRepository matchEventRepository) =>
            _matchEventRepository = matchEventRepository;
        
        public Task<List<Dto.Match>> GetMatches()
        {
            // Hard-code for now.
            return Task.FromResult(new List<Dto.Match>
            {
                new Dto.Match 
                {
                    Id = 1,
                    Name = "Saracens v. Wasps"
                },
                new Dto.Match 
                {
                    Id = 2,
                    Name = "Gloucester v. Bath"
                },
                new Dto.Match 
                {
                    Id = 3,
                    Name = "Harlequin v. Leeds"
                }
            });
        }

        public Task<List<Dto.Event>> GetEvents()
        {
            // Hard-code for now.
            return Task.FromResult(new List<Dto.Event>
            {
                new Dto.Event 
                {
                    Id = 1,
                    Name = "Conversion"
                },
                new Dto.Event 
                {
                    Id = 2,
                    Name = "Try"
                },
                new Dto.Event 
                {
                    Id = 3,
                    Name = "Penalty"
                }
            });
        }

        public Task<bool> LoginWithUserId(int userId) =>
            Task.FromResult(UserId.CreateUserId(userId).Match(None: () => false, Some: (u) => true));

        public async Task<Either<IEnumerable<Error>, int>> AddNewMatchEventAsync(Dto.MatchEvent matchEvent) =>
            await matchEvent
                .ValidateDto()
                .BindAsync(ValidateMatchEventToAdd)
                .BindAsync(m => _matchEventRepository.AddNewMatchEventAsync(m));

        protected async Task<Either<IEnumerable<Error>, MatchEvent>> ValidateMatchEventToAdd(MatchEvent matchEvent)
        {
            var errors = new List<Error>();
            // Validation checks here.
            if (errors.Any()) return errors;
            return matchEvent;
        }

        public Task<Either<IEnumerable<Error>, List<Dto.MatchEvent>>> GetAllMatchEventsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Either<IEnumerable<Error>, int>> DeleteMatchEventAsync(Dto.MatchEvent matchEvent)
        {
            throw new NotImplementedException();
        }
    }
}