using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Rollers.Data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rollers.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        { 

            if (!content.categories.Any())
            {
                content.categories.AddRange(Categories.Select(c => c.Value));
            }
            if (!content.rollerSkates.Any())
            {
                content.AddRange(new RollerSkate
                {
                    id = 1,
                    name = "VNLA Jr. SLVR Jam Skate",
                    shortDesc = "The Backspin Remix Lite wheels (92A) with a lightweight VNLA Gorilla plate will allow you to achieve all of your desired skate moves. ",
                    longDesc = "Only the finest for VNLA Jam skaters; our SLVR boots are made with luxurious black and red suede hidden underneath a futuristic metallic silver cover. As the metallic cover wears down, the red suede is revealed; our innovative answer to the dreaded issue of scuffing! Rather than your skates looking worn after use, you will literally have a BRAND NEW looking pair of skates. A nice red lace cover finishes off the polished, one-of-a-kind look. ",
                    price = 219,
                    img = "https://cdn2.bigcommerce.com/n-d57o0b/dmke2u/products/2609/images/23831/VNLA_SLVR_JP_1__32404.1607444627.500.659.jpg?c=2",
                    isFavourite = true,
                    available = true,
                    Category = Categories["Speed skates"]
                });
            }
            content.SaveChanges();
        }
        
            private static Dictionary<string, Category> category;
            public static Dictionary<string, Category> Categories
            {
                get
                {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Speed skates", desc = "These skates are meant to go fast and because of their design they are very popular skates. Speed skates feature low cut shoes (boot) that fits just like tennis shoes. The low cut design helps with going around corners." },
                        new Category { categoryName = "Outdoor skates", desc = "These skates are simply meant for the outdoors. Outdoor skates come in either low top or high top boots and the wheels are specifically designed to skate outdoors where the ground is not as smooth." },
                        new Category { categoryName = "Racing skates", desc = "Racing skates are skates that were designed to go fast, simply put. The shoe (boot) is designed so that it fits as close to your foot as possible allowing you the least amount of wind resistance. The wheels of these skates are easily interchangeable to allow the skater to skate indoors or outdoors." }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }
                return category; 
                }
            }


        }
    }

