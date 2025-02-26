using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ActionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Trigger> Triggers { get; set; } = new List<Trigger>();
    }
}
