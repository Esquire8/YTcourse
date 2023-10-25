namespace YTCourse.Models
{
    public class BasketItem
    {
        public int id { get; set; }
        public Car car { get; set; }
        public int price { get; set; }

        public string basketItemId { get; set; }
    }
}
