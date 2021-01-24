using Rollers.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.models
{
    public class MockRollerSkates : IAllRollerSkates  {
        private readonly IRollerSkatesCategory _rollerSkatesCategory = new MockCategory();
        public IEnumerable<RollerSkate> RollerSkates {
            get {
                return new List<RollerSkate>{
                new RollerSkate {
                    id = 1,
                    name = "VNLA Jr. SLVR Jam Skate",
                    shortDesc = "The Backspin Remix Lite wheels (92A) with a lightweight VNLA Gorilla plate will allow you to achieve all of your desired skate moves. ",
                    longDesc = "Only the finest for VNLA Jam skaters; our SLVR boots are made with luxurious black and red suede hidden underneath a futuristic metallic silver cover. As the metallic cover wears down, the red suede is revealed; our innovative answer to the dreaded issue of scuffing! Rather than your skates looking worn after use, you will literally have a BRAND NEW looking pair of skates. A nice red lace cover finishes off the polished, one-of-a-kind look. ",
                    price = 219,
                    img = "https://cdn2.bigcommerce.com/n-d57o0b/dmke2u/products/2609/images/23831/VNLA_SLVR_JP_1__32404.1607444627.500.659.jpg?c=2",
                    isFavourite = true,
                    available = true,
                    Category = _rollerSkatesCategory.AllCategories.First()  }
            };
            }
        }
        public IEnumerable<RollerSkate> getFavRollerSkates { get; set; }

        public RollerSkate getObjectRollerSkate(int rollerId)
        {
            throw new NotImplementedException();
        }
    }
}
