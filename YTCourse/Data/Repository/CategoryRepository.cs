using System.Data.Entity;
using YTCourse.Interfaces;
using YTCourse.Models;

namespace YTCourse.Data.Repository
{
    public class CategoryRepository : ICarsCategories
    {
        private readonly AppDBContent _content;

        public CategoryRepository(AppDBContent content)
        {
            this._content = content;
        }
        public IEnumerable<Category> allCategories => _content.Categories;
    }
}
