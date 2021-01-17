using System;

namespace Ianf.Gametracker.Repositories.Entities
{
    public partial class MatchEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime EventTime { get; set; }
        public int MatchEventType { get; set; }
    }
}
