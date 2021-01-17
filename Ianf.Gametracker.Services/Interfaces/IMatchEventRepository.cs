using System.Collections.Generic;
using System.Threading.Tasks;
using Ianf.Gametracker.Services.Domain;
using Ianf.Gametracker.Services.Errors;
using LanguageExt;

namespace Ianf.Gametracker.Services.Interfaces
{
    public interface IMatchEventRepository
    {
        Task<Either<IEnumerable<Error>, int>> AddNewMatchEventAsync(MatchEvent matchEvent);
        Task<Either<IEnumerable<Error>, List<MatchEvent>>> GetAllMatchEventsByUserIdAsync(UserId userId);
        Task<Either<IEnumerable<Error>, int>> DeleteMatchEventAsync(MatchEvent matchEvent);
    }
}
