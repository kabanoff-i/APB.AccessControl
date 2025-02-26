using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AccessGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<AccessGrid> AccessGrids { get; set; } = new List<AccessGrid>();
        public ICollection<AccessRule> AccessRules { get; set; } = new List<AccessRule>();
    }

}
