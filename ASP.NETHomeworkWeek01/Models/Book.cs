namespace ASP.NETHomeworkWeek01.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string? BookName { get; set; }
        public decimal Price { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        //public List<Book> books { get; set; }
    }
}
