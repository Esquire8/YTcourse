using Microsoft.EntityFrameworkCore;
using YTCourse.Models;

namespace YTCourse.Data
{
    /*Экземпляр DbContext представляет сеанс с базой данных и может использоваться для запроса и сохранения экземпляров сущностей. 
    DbContext — это сочетание шаблонов единиц работы и репозитория.*/
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        /*Обычно создается класс, производный от DbContext и содержащий DbSet<TEntity> свойства для каждой сущности в модели. 
        DbSet<TEntity> Если свойства имеют открытый метод задания, они автоматически инициализируются при создании экземпляра производного контекста.*/
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BasketItem> BasketItem { get; set; }
    }
}
