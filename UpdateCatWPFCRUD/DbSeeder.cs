using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataContext
{
    public static class DbSeeder
    {
        public static void SeedAll(EFDataContext context) 
        {
            SeedCat(context);
        }

        private static void SeedCat(EFDataContext context) 
        {
            if (!context.cats.Any()) 
            {
                context.cats.Add(new CatRenta.Entities.AppCat { 
                Name = "Манул",
                Birthday = new DateTime(2018, 2, 12),
                UrlImage = "https://upload.wikimedia.org/wikipedia/commons/d/d6/Manoel.jpg"
                });

                context.SaveChanges();
            }
        }
    }
}
