using LibraryData;
using LibraryDomain;

namespace LibraryManagement1.Controller
{
    public class BooksController
    {
        public static void Add(List<Book> list)
        {
            using (var context = new LibraryDBContext())
            {
                context.Books.AddRange(list);
                context.SaveChanges();
            }
        }

        public static List<Book> Get()
        {
            using (var context = new LibraryDBContext())
            {
                var books = context.Books.Where(b => b.IsCompleted == true).ToList();
                return books;
            }
        }

        public static Book Get(int Id)
        {
            using (var context = new LibraryDBContext())
            {
                var book = context.Books.Where(b => (b.Id == Id && b.IsCompleted == true)).ToList();
                return book[0];
            }
        }

        public static void Remove()
        {
            var books = Get();
            foreach (var book in books)
            {
                Remove(book.Id);
            }
        }

        public static void Remove(int Id)
        {
            using (var context = new LibraryDBContext())
            {
                var Book = Get(Id);
                Book.IsCompleted = false;
                context.Books.Update(Book);
                context.SaveChanges();
            }
        }
        public static void Update(int id, string? title, double price, int numberAvailable)
        {
            using (var context = new LibraryDBContext())
            {
                var book = Get(id);
                book.Title = title;
                book.Price = price;
                book.NumberAvailable = numberAvailable;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }
    }
}
