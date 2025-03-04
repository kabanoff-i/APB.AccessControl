using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class ActionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Trigger> Triggers { get; set; } = new List<Trigger>();
    }
}
