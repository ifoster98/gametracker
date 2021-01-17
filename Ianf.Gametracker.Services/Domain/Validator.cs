using System.Collections.Generic;
using System.Linq;
using Ianf.Gametracker.Services.Errors;
using LanguageExt;

namespace Ianf.Gametracker.Services.Domain
{
    public static class Validator
    {
        public static Either<IEnumerable<Error>, MatchEvent> ValidateDto(this Dto.MatchEvent matchEvent)
        {
            var errors = new List<DtoValidationError>();
            var userId = new UserId();
            UserId.CreateUserId(matchEvent.UserId)
                .Match(
                    None: () => errors.Add(new DtoValidationError("Invalid amount for userId.", "MatchEvent", "UserId") ),
                    Some: (s) => userId = s
                );
            if(errors.Any()) return errors;
            return new MatchEvent(userId, matchEvent.EventTime, matchEvent.MatchEventType);
        }
    }
}