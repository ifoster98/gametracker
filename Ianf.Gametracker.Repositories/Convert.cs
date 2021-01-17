using System;
using System.Linq;
using System.Reflection.Metadata;
using Ianf.Gametracker.Services;
using Ianf.Gametracker.Services.Domain;

namespace Ianf.Gametracker.Repositories
{
    public static class Convert
    {
        public static MatchEvent ToDomain(this Entities.MatchEvent matchEvent) =>
            new MatchEvent(
                UserId.CreateUserId(matchEvent.UserId).IfNone(new UserId()),
                matchEvent.EventTime,
                (MatchEventType)matchEvent.MatchEventType
            );

        public static Entities.MatchEvent ToEntity(this MatchEvent matchEvent)  =>
            new Entities.MatchEvent() {
                UserId = matchEvent.UserId.Value,
                EventTime = matchEvent.EventTime,
                MatchEventType = (int)matchEvent.MatchEventType
            };
    }
}