using YTCourse.Models;

namespace YTCourse.ViewModel
{
    public class CarListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string curCategory { get; set; }
    }
}
