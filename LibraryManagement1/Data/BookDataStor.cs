using LibraryDomain;

namespace LibraryManagement1.Data
{
    public class BookDataStor
    {
        public List<Book> Books { get; set; }
        public static BookDataStor Current { get; set; } = new BookDataStor();
        public BookDataStor()
        {
            Books = new List<Book>()
            {
                new Book(){Title = "First Book", Price = 15.2, NumberAvailable = 20,},
                new Book(){Title = "Second Book", Price = 18, NumberAvailable = 10},
                new Book(){Title = "Third Book", Price = 17, NumberAvailable = 1},
                new Book(){Title = "Fourth Book", Price = 25, NumberAvailable = 6},
                new Book(){Title = "Fifth Book", Price = 24, NumberAvailable = 10},
                new Book(){Title = "Sixth Book", Price = 14.6, NumberAvailable = 15},
                new Book(){Title = "Seventh Book", Price = 8, NumberAvailable = 30},
            };
        }
    }
}
