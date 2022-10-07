using LibraryData;
using LibraryDomain;

namespace LibraryManagement1.Controller
{
    public class BooksController
    {
        public static void AddBooks(List<Book> list)
        {
            using (var context = new LibraryDBContext())
            {
                context.Books.AddRange(list);
                context.SaveChanges();
            }
        }

        public static List<Book> GetBooks()
        {
            using (var context = new LibraryDBContext())
            {
                var books = context.Books.Where(b => b.IsDeleted == true).ToList();
                return books;
            }
        }

        public static Book GetBook(int Id)
        {
            using (var context = new LibraryDBContext())
            {
                var book = context.Books.FirstOrDefault(b => (b.Id == Id && b.IsDeleted == true));
                return book;
            }
        }
        public static void RemoveBook(int Id)
        {
            using (var context = new LibraryDBContext())
            {
                var book = context.Books.FirstOrDefault(b => (b.Id == Id && b.IsDeleted == true));
                book.IsDeleted = false;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }
        public static void UpdateBook(int Id, string? title, double price, int numberAvailable)
        {
            using (var context = new LibraryDBContext())
            {
                var book = context.Books.FirstOrDefault(b => (b.Id == Id && b.IsDeleted == true));
                book.Title = title;
                book.Price = price;
                book.NumberAvailable = numberAvailable;
                context.Books.Update(book);
                context.SaveChanges();
            }
        }
    }
}
