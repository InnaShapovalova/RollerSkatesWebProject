using Rollers.Data.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data.models
{
    public class MockCategory : IRollerSkatesCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { categoryName = "Speed skates", desc = "These skates are meant to go fast and because of their design they are very popular skates. Speed skates feature low cut shoes (boot) that fits just like tennis shoes. The low cut design helps with going around corners." },
                    new Category { categoryName = "Outdoor skates", desc = "These skates are simply meant for the outdoors. Outdoor skates come in either low top or high top boots and the wheels are specifically designed to skate outdoors where the ground is not as smooth." },
                    new Category { categoryName = "Racing skates", desc = "Racing skates are skates that were designed to go fast, simply put. The shoe (boot) is designed so that it fits as close to your foot as possible allowing you the least amount of wind resistance. The wheels of these skates are easily interchangeable to allow the skater to skate indoors or outdoors." },
                    new Category { categoryName = "Kids skates", desc = "Kids skates are skates that are designed for the young skaters. They look cool but at the same time they designed so that they will not go as fast as other skates. Plus, kids skating shoes are designed for the wear and tear that kids put on their skates!" },
                };
            }

        }
    }
}
