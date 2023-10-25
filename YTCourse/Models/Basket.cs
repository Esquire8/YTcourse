using YTCourse.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Entity;

namespace YTCourse.Models
{
    public class Basket
    {
        //Подключение к БД
        private readonly AppDBContent _content;
        public Basket(AppDBContent content) => this._content = content;

        public string Id { get; set; }
        public List<BasketItem> listBasketItems { get; set; }

        public static Basket GetItem(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var content = services.GetService<AppDBContent>();
            string basketId = session.GetString("ItemId") ?? Guid.NewGuid().ToString();

            session.SetString("ItemId", basketId);
            return new Basket(content) { Id = basketId };
        }

        //Добавление товара в корзину
        public void AddToBasket(Car car)
        {
            _content.BasketItem.Add(new BasketItem
            {
                basketItemId = Id,
                car = car,
                price = car.price
            });

            _content.SaveChanges();
        }

        //отображение всех товаров в корзине
        public List<BasketItem> GetBasketItem()
        {
            return _content.BasketItem.Where(c => c.basketItemId == Id).Include(s => s.car).ToList();
        }
    }
}
