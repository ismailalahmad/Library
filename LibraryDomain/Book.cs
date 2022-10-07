namespace LibraryDomain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int NumberAvailable { get; set; }
        public bool IsDeleted { get; set; } = true;

    }
}