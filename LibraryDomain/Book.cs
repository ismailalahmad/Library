namespace LibraryDomain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int NumberAvailable { get; set; }
        public bool IsCompleted { get; set; } = true;
        public List<User> Users { get; set; } = new List<User>();
        public List<UserBook> UserBooks { get; set; } = new List<UserBook>();

    }
}