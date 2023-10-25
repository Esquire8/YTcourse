namespace YTCourse.Models
{
    public class Category
    {
        public int id { get; set; }

        public string categoryName { get; set; }

        public string categoryDesc { get; set; }

        public List<Car> cars { get; set; }

    }
}
