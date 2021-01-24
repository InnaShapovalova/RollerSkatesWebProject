using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.models
{
    public class RollerSkate
    {
        public int id { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public ushort price { set; get; }
        public string img { set; get; }
        public bool isFavourite { set; get; }
        public bool available { set; get; }
        public int categoryId { set; get; }
        public Category Category { set; get; }

    }
}
