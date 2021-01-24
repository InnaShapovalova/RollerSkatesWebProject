using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.interfaces
{
    public interface IRollerSkatesCategory
    {
        public IEnumerable<Category> AllCategories { get; }
    }
}
