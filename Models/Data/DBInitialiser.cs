using passholder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace passholder.Models.Data
{
    public static class DBInitialiser
    {
        public static void Initialize(PassDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Count() > 1)
            {
                return;   // DB has been seeded
            }
            var users = new User[]
            {
                new User{ Name="Sreekumar",Email="heysreekumar@gmail.com",IsActive = true  },
                new User{ Name="Honey Dev P",Email="hodev@gmail.com",IsActive = true  }
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();
        }
    }
}
