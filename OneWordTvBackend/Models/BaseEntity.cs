using System;

namespace OneWordTvBackend.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; } 
    }
}
