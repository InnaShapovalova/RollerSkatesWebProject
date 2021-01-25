using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RollerSkatesWebProject.Domain
{
    public class RollerSkateMapLocation
    {
        public int Id { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string LocationName { get; set; }
        public string Address { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
