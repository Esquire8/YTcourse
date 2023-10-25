using Microsoft.AspNetCore.Mvc;
using YTCourse.Data;
using YTCourse.Interfaces;
using YTCourse.ViewModel;

namespace YTCourse.Controllers
{
    public class CarsController : Controller
    {

        AppDBContent db;

        private readonly ICars _iCars;
        private readonly ICarsCategories _iCarsCat;

        public CarsController(ICars iCars, ICarsCategories iCarsCat, AppDBContent appDBContent)
        {
            db = appDBContent;
            this._iCars = iCars;
            this._iCarsCat = iCarsCat;
        }

        public ViewResult ListCars()
        {
            ViewData["Title"] = "Page with cars";
            CarListViewModel carObj = new CarListViewModel();
            carObj.allCars = _iCars.allCars;
            carObj.curCategory = "Автомобили";
            

            return View(carObj);
        }
    }
}
