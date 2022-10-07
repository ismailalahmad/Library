using LibraryData;
using LibraryDomain;
using Logging;
using System.Text.Json;

namespace LibraryManagement1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            checkForApp();
            Console.WriteLine("Welcome! to the Library");
            homePage();
        }
        private static void checkForApp()
        {
            //Check the existence of the database
            DatabaseCreated();
            //Check for books
            BooksAdded();
            //Check for users
            UsersAdded();

        }
        private static void DatabaseCreated()
        {
            using (var context = new LibraryDBContext())
            {
                context.Database.EnsureCreated();
            }
        }
        private static void BooksAdded()
        {
            if (Controller.BooksController.GetBooks().Count() == 0)
            {
                var books = Data.BookDataStor.Current.Books;
                Controller.BooksController.AddBooks(books);
            }
        }
        private static void UsersAdded()
        {
            if (Controller.UsersController.GetUsers().Count() == 0)
            {
                String contents = File.ReadAllText("Data/DefaultUsers.json");
                var defaultEmployees = JsonSerializer.Deserialize<List<User>>(contents);
                Controller.UsersController.AddUsers(defaultEmployees);
            }
        }
        private static bool LogIn()
        {
            bool isExist = true;
            string username = "";
            string password = "";
            while (isExist)
            {
                Console.WriteLine("Please, Enter username ");
                username = Console.ReadLine();
                Console.WriteLine("Please, Enter password");
                password = Console.ReadLine();
                isExist = !Controller.UsersController.UserExist(username, password);
                if (isExist)
                    Console.WriteLine("You have an error, please try again");
                else
                {
                    ExtendLogger.FullName = Controller.UsersController.GetUserByUsername(username).FullName;
                }
            }
            Console.WriteLine("Welcome {0} ,There are {1} books in the library", Controller.UsersController.GetUserByUsername(username).FullName, Controller.UsersController.Get().Count());
            return !isExist;
        }
        private static void homePage()
        {
            if (LogIn())
            {
                bool Exit = false;
                while (!Exit)
                {
                    int option = 0;
                    Console.WriteLine("choose :");
                    Console.WriteLine("1 - This option to view brief information about all the books we have available");
                    Console.WriteLine("2 - This option to view the details of a specific book");
                    Console.WriteLine("3 - This option to delete a specific book");
                    Console.WriteLine("4 - This option to update a specific book");
                    Console.WriteLine("5 - switch account ");
                    Console.WriteLine("6 - When you finish");
                    Console.WriteLine("Enter your option here: ");
                    option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1: briefInformation(); break;
                        case 2: details(); break;
                        case 3: delete(); break;
                        case 4: update(); break;
                        case 5: homePage(); break;
                        case 6: Exit = true; Console.WriteLine("Done..."); break;
                        default: Console.WriteLine("this option is not available"); break;
                    }
                }
            }
        }
        private static void briefInformation()
        {
            var books = Controller.BooksController.GetBooks();
            int countOfAllCopies = 0;
            foreach (var book in books)
            {
                Console.WriteLine("Serial Number : {0}", book.Id);
                Console.WriteLine("The name : {0}", book.Title);
                Console.WriteLine("Number of copies : {0}", book.NumberAvailable);
                Console.WriteLine("_______________________________________");
                countOfAllCopies += book.NumberAvailable;
            }
            Console.WriteLine("Number of all books (with all copies) : {0} ", countOfAllCopies);
        }
        private static void details()
        {
            Console.WriteLine("Enter the book Id");
            int id = Convert.ToInt32(Console.ReadLine());
            var book = Controller.BooksController.GetBook(id);
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Title : " + book.Title);
            Console.WriteLine("Price : " + book.Price);
            Console.WriteLine("Number of copies : " + book.NumberAvailable);
            Console.WriteLine("_______________________________________");

        }
        private static void delete()
        {
            Console.WriteLine("Enter book ID");
            Controller.BooksController.RemoveBook(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Book is deleted");
            Console.WriteLine("_______________________________________");
        }
        private static void update()
        {
            Console.WriteLine("Enter book ID");
            int id = Convert.ToInt32(Console.ReadLine());
            string title;
            double price;
            int numberAvailable;
            Console.WriteLine("Pleas, Enter the new title");
            title = Console.ReadLine();
            Console.WriteLine("Please, Enter the new pice");
            price = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please, Enter the new number available");
            numberAvailable = Convert.ToInt32(Console.ReadLine());
            Controller.BooksController.UpdateBook(id, title, price, numberAvailable);
            Console.WriteLine("Book is updated");
            Console.WriteLine("_______________________________________");
        }
    }
}