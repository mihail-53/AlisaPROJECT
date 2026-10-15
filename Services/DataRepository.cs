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
        public static List<User> users = new List<User>();
        public static List<Recepie> recepies = new List<Recepie>();
        public static User? currUser;
        // add allergens and preferences lists

        public static void CreateFakeData()
        {
            users.Add(new User { Id = "1", Name = "jane Doe", Email = "jad@email.com", Password = "12345678" });
            users.Add(new User { Id = "2", Name = "John Doe", Email = "jod@email.com", Password = "87654321" });

            recepies.Add(new Recepie
            {
                Id = "1",
                Name = "Pizza",
                Ingredients = new List<Ingredient> { new Ingredient { Name = "Cheese" }, new Ingredient { Name = "Tomato sauce" }, new Ingredient { Name = "Dough" }, new Ingredient { Name = "Toppings" } },
                PostedBy = users[0],
                Instructions = "1. preheat the oven to 350 degrees C\n2.roll the dough and transfer to the baking tray\n3.spread tomato sauce, cheese, and your favourite toppings\n4. bake for 7-8 minutes\n5. enjoy!"
            } );
            
        }

        public static bool RegisterUser(string email, string password, string name)
        {
            var foundUser = users.Find(u => u.Email.ToLower() == email.ToLower());

            if (foundUser != null)
            {
                return false;
            }

            var newUser = new User
            {
                Id = (users.Count + 1).ToString(),
                Name = name,
                Email = email.ToLower(),
                Password = password
            };
            users.Add(newUser);

            currUser = newUser;

            return true;
        }


    }
}
