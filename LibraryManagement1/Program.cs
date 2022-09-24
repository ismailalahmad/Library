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
            check();
            Console.WriteLine("Welcome! to the Library");
            homePage();
        }
        private static void check()
        {
            //Check the existence of the database
            using (var context = new LibraryDBContext())
            {
                context.Database.EnsureCreated();
            }
            //Check for books
            if (Controller.BooksController.Get().Count() == 0)
            {
                var books = new List<Book>()
                        {
                            new Book(){Title = "First Book", Price = 15.2, NumberAvailable = 20,},
                            new Book(){Title = "Second Book", Price = 18, NumberAvailable = 10},
                            new Book(){Title = "Third Book", Price = 17, NumberAvailable = 1},
                            new Book(){Title = "Fourth Book", Price = 25, NumberAvailable = 6},
                            new Book(){Title = "Fifth Book", Price = 24, NumberAvailable = 10},
                            new Book(){Title = "Sixth Book", Price = 14.6, NumberAvailable = 15},
                            new Book(){Title = "Seventh Book", Price = 8, NumberAvailable = 30},
                        };
                Controller.BooksController.Add(books);
            }
            //Check for users
            if (Controller.UsersController.Get().Count() == 0)
            {
                String contents = File.ReadAllText("DefaultUsers.json");
                var defaultEmployees = JsonSerializer.Deserialize<List<User>>(contents);
                Controller.UsersController.Add(defaultEmployees);
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
                isExist = !Controller.UsersController.find(username, password);
                if (isExist)
                    Console.WriteLine("You have an error, please try again");
                else
                {
                    ExtendLogger.FullName = Controller.UsersController.Get(username).FullName;
                }
            }
            Console.WriteLine("Welcome {0} ,There are {1} books in the library", Controller.UsersController.Get(username).FullName, Controller.UsersController.Get().Count());
            return !isExist;
        }
        private static void homePage()
        {
            if (LogIn())
            {
                string Exit = "";
                while (Exit != "6")
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
                        case 6: Exit = "6"; Console.WriteLine("Done..."); break;
                        default: Console.WriteLine("this option is not available"); break;
                    }
                }
            }
        }
        private static void briefInformation()
        {
            var books = Controller.BooksController.Get();
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
            var book = Controller.BooksController.Get(id);
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Title : " + book.Title);
            Console.WriteLine("Price : " + book.Price);
            Console.WriteLine("Number of copies : " + book.NumberAvailable);
            Console.WriteLine("_______________________________________");

        }
        private static void delete()
        {
            Console.WriteLine("Enter book ID");
            Controller.BooksController.Remove(Convert.ToInt32(Console.ReadLine()));
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
            Controller.BooksController.Update(id, title, price, numberAvailable);
            Console.WriteLine("Book is updated");
            Console.WriteLine("_______________________________________");
        }
    }
}