using System.Collections.Generic;

namespace APB.AccessControl.Domain.Entities
{
    public class AccessPointType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AccessPoint> AccessPoints { get; set; } = new List<AccessPoint>();
    }
}
