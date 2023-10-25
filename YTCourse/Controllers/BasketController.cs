using Microsoft.AspNetCore.Mvc;
using YTCourse.Interfaces;
using YTCourse.Models;
using YTCourse.ViewModel;

namespace YTCourse.Controllers
{
    public class BasketController : Controller
    {
        private readonly ICars _cars;
        private readonly Basket _basket;

        public BasketController(ICars cars, Basket basket)
        {
            _cars = cars;
            _basket = basket;
        }

        public IActionResult Index()
        {
            var items = _basket.GetBasketItem();
            _basket.listBasketItems = items;

            var obj = new BasketViewModel
            {
                basket = _basket
            };

            return View(obj);
        }

        public RedirectToActionResult RedirectToItem(int id)
        {
            var item = _cars.allCars.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _basket.AddToBasket(item);
            }

            return RedirectToAction("Index");
        }
    }
}
