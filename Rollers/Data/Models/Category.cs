using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.models
{
    public class Category
    {
        public int id { set; get; }
        public string categoryName { set; get; }
        public string desc { set; get; }
        public List<RollerSkate> cars { set; get; }

    }
}
