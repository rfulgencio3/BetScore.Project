using System;

namespace BetScore.Domain.Entities
{
    public class Base
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? LastUpdate { get; set; }
        public bool Active { get; set; }
    }
}
