using Stockpot.DataAccess.Entities;
using Stockpot.DataAccess.Entities.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Stockpot.DataAccess
{
    public static class DbInitializer
    {
        public static void Initialize(DbContextProvider dbContextProvider)
        {
            var dbContext = dbContextProvider.DbContext;

            dbContext.Database.EnsureCreated();
            //dbContext.Database.Migrate();

            // Return when database has been seeded.
            if (dbContext.Recipes.Any())
            {
                return;
            }

            var ingredient1 = new Ingredient
            {
                Name = "Coffee powder"
            };

            var ingredient2 = new Ingredient
            {
                Name = "Sugar"
            };

            var ingredient3 = new Ingredient
            {
                Name = "Milk"
            };

            var recipe1 = new Recipe
            {
                Name = "Coffee with milk and sugar",
                Description = "Best coffee in the world!",
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient {
                        Ingredient = ingredient1,
                        Amount = 1,
                        Unit = Unit.Tsp
                    },
                    new RecipeIngredient {
                        Ingredient = ingredient2,
                        Amount = 1,
                        Unit = Unit.Tbsp
                    },
                    new RecipeIngredient {
                        Ingredient = ingredient3,
                        Amount = 20,
                        Unit = Unit.Milliliter
                    }
                }
            };

            dbContext.Add(recipe1);

            dbContext.SaveChanges();
        }
    }
}