using Microsoft.EntityFrameworkCore;
using suppliers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace suppliers
{
    public class SeedData
    {
        public static void SeedDatabase(DataContext context)
        {
            if (context.Database.GetMigrations().Count() > 0
                && context.Database.GetPendingMigrations().Count() == 0
                && context.Products.Count() == 0)
            {

                var supplier1 = new Supplier
                {
                    Name = "ООО Кубонские вина",
                    City = "Краснодар",
                    Address = "ул. Ленина д. 40"
                };
                var supplier2 = new Supplier
                {
                    Name = "ООО Букет Чувашии",
                    City = "Чебоксары",
                    Address = "пр. Базовый д. 6"
                };
                var supplier3 = new Supplier
                {
                    Name = "ООО Чебоксарский ЛВЗ",
                    City = "Чебоксары",
                    Address = "ул. Афанасьева д. 12"
                };

                context.Products.AddRange(
                    new Product
                    {
                        Name = "Изабелла",
                        Description = "Сухое полусладкое вино",
                        Category = "Вино",
                        Price = 246,
                        Supplier = supplier1,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 4}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Мерло",
                        Description = "Сухое полусладкое вино",
                        Category = "Вино",
                        Price = 263,
                        Supplier = supplier1,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 4}, new Rating {Stars = 5}
                        }
                    },
                    new Product
                    {
                        Name = "Пенное",
                        Description = "Пиво",
                        Category = "Пиво",
                        Price = 36,
                        Supplier = supplier2,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 3}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Чебоксарское",
                        Description = "Пиво",
                        Category = "Пиво",
                        Price = 33,
                        Supplier = supplier2,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 3}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Визитное",
                        Description = "Пиво",
                        Category = "Пиво",
                        Price = 34,
                        Supplier = supplier2,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 3}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Живое",
                        Description = "Пиво",
                        Category = "Пиво",
                        Price = 38,
                        Supplier = supplier2,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 3}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Леди-Ночь",
                        Description = "Пиво",
                        Category = "Пиво",
                        Price = 39,
                        Supplier = supplier2,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 3}, new Rating {Stars = 4}
                        }
                    },
                    new Product
                    {
                        Name = "Столичная",
                        Description = "Водка",
                        Category = "Водка",
                        Price = 366,
                        Supplier = supplier1,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 5}, new Rating {Stars = 5}
                        }
                    }, new Product
                    {
                        Name = "Празднечная",
                        Description = "Водка",
                        Category = "Водка",
                        Price = 352,
                        Supplier = supplier1,
                        Ratings = new List<Rating>
                        {
                            new Rating {Stars = 5}, new Rating {Stars = 5}
                        }
                    });
            }

        }
    }
}
