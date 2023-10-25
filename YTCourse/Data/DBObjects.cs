using YTCourse.Interfaces;
using YTCourse.Models;

namespace YTCourse.Data
{
    public class DBObjects
    {
        public static void Itinial(AppDBContent content)
        {
            if(!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Cars.Any())
            {
                content.Cars.AddRange(AllCars.Select(c => c.Value));
            }

            content.SaveChanges();

        }

        //Добавление категорий
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[] {
                        new Category { categoryName = "Электромобили", categoryDesc = "Современный вид транспорта" },
                        new Category { categoryName = "Классические автомобили", categoryDesc = "Машины с ДВС"}                    
                    };

                    category = new Dictionary<string, Category>();
                    foreach(Category el in  list)
                    {
                        category.Add(el.categoryName, el);
                    }
                }

                return category;

            }
        }

        //Добавление машин
        private static Dictionary<string, Car> allCars;
        public static Dictionary<string, Car> AllCars
        {
            get
            {
                if(allCars == null)
                {
                    var list = new Car[]
                    {
                        new Car{name = "Tesla Model S", 
                            shortDesc = "Быстрый автомобиль", 
                            longDesc = "Красивый, быстрый автомобиль от компании Tesla", 
                            img="/img/tesla_Model_3.jpg", 
                            price=45000,
                            isFavorite=true,
                            available=true,
                            Category=Categories["Электромобили"]
                        },

                        new Car{name = "Бемельве",
                            shortDesc = "Масложер",
                            longDesc = "Твой кошелек станет пустым",
                            img="/img/BMW-5.jpg",
                            price=33500,
                            isFavorite=true,
                            available=true,
                            Category=Categories["Классические автомобили"]
                        },
                    };

                    allCars = new Dictionary<string, Car>();
                    foreach(Car el in list)
                    {
                        allCars.Add(el.name, el);
                    }
                }
                return allCars;
            }
        }
    }
}
