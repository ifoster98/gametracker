using System;

namespace Ianf.Gametracker.Services.Domain
{
    public record MatchEvent(UserId UserId, DateTime EventTime, MatchEventType MatchEventType)
    { 
        public Dto.MatchEvent ToDto()  =>
            new Dto.MatchEvent() {
                UserId = this.UserId.Value,
                EventTime = this.EventTime,
                MatchEventType = this.MatchEventType
            };
    }
}
