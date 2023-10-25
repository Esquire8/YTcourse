using Microsoft.EntityFrameworkCore;
using YTCourse.Interfaces;
using YTCourse.Models;

namespace YTCourse.Data.Repository
{
    public class CarRepository : ICars
    {
        private readonly AppDBContent _content;

        public CarRepository(AppDBContent content)
        {
            this._content = content;
        }

        public IEnumerable<Car> allCars => _content.Cars.Include(c => c.Category);

        public IEnumerable<Car> getFavCars => _content.Cars.Where(p => p.isFavorite).Include(c => c.Category);

        public Car getObjCar(int carId) => _content.Cars.FirstOrDefault(p => p.id == carId);
    }
}
