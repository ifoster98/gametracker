using System.Threading.Tasks;
using LanguageExt;
using System.Collections.Generic;
using Ianf.Gametracker.Services.Errors;

namespace Ianf.Gametracker.Services.Interfaces
{
    public interface IMatchEventService
    {
        Task<bool> LoginWithUserId(int userId);
        Task<List<Dto.Match>> GetMatches();
        Task<Either<IEnumerable<Error>, int>> AddNewMatchEventAsync(Dto.MatchEvent matchEvent);
        Task<Either<IEnumerable<Error>, List<Dto.MatchEvent>>> GetAllMatchEventsByUserIdAsync(int userId);
        Task<Either<IEnumerable<Error>, int>> DeleteMatchEventAsync(Dto.MatchEvent matchEvent);
    }
}
