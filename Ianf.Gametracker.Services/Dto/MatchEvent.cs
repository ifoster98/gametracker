using System;

namespace Ianf.Gametracker.Services.Dto
{
    public struct MatchEvent 
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public DateTime EventTime { get; set; }
        public MatchEventType MatchEventType { get; set; }
    }
}
