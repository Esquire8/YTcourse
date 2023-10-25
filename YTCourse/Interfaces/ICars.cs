using YTCourse.Models;

namespace YTCourse.Interfaces
{
    public interface ICars
    {
        IEnumerable<Car> allCars { get; }

        IEnumerable<Car> getFavCars { get;}

        Car getObjCar(int carId);
    }
}
