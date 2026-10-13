using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisaPROJECT.Models
{
    internal class Recepie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public User PostedBy { get; set; }
        public string Instructions { get; set; }
        public string? Img { get; set; }

        //add allergens and preferences lists
    }
}
