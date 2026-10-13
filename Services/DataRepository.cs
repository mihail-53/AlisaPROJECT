using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlisaPROJECT.Models;

namespace AlisaPROJECT.Services
{
    internal class DataRepository
    {
        static List<User> users = new List<User>();
        static List<Recepie> recepies = new List<Recepie>();
        static User currUser;
        // add allergens and preferences lists

        public static void CreateFakeData()
        {
            users.Add(new User { Id = "1", Name = "jane Doe", Email = "jd@email.com", Password = "12366666" });
            users.Add(new User { Id = "2", Name = "John Doe", Email = "jjd@email.com", Password = "123458888" });

            recepies.Add(new Recepie
            {
                Id = "1",
                Name = "Pizza",
                Ingredients = new List<Ingredient> { new Ingredient { Name = "Cheese" }, new Ingredient { Name = "Tomato sauce" }, new Ingredient { Name = "Dough" }, new Ingredient { Name = "Toppings" } },
                PostedBy = users[0],
                Instructions = "1. preheat the oven to 350 degrees C\n2.roll the dough and transfer to the baking tray\n3.spread tomato sauce, cheese, and your favourite toppings\n4. bake for 7-8 minutes\n5. enjoy!"
            } );
            
        }

        
    }
}
