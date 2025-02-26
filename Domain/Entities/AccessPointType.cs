using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class AccessPointType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>();
    }
}
