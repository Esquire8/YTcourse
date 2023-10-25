using YTCourse.Models;

namespace YTCourse.Interfaces
{
    public interface ICarsCategories
    {
        IEnumerable<Category> allCategories { get; }
    }
}
