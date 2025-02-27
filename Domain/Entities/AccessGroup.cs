using Domain.Abstractions;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class AccessGroup: BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AccessGrid> AccessGrids { get; set; } = new List<AccessGrid>();
        public ICollection<AccessRule> AccessRules { get; set; } = new List<AccessRule>();
    }

}
