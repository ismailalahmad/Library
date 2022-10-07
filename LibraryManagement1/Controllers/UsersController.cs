using LibraryData;
using LibraryDomain;

namespace LibraryManagement1.Controller
{
    public class UsersController
    {
        public static void AddUsers(List<User>? defaultUsers)
        {
            using (var context = new LibraryDBContext())
            {
                context.Users.AddRange(defaultUsers);
                context.SaveChanges();
            }
        }
        public static List<User> GetUsers()
        {
            using (var context = new LibraryDBContext())
            {
                var Users = context.Users.ToList();
                return Users;
            };
        }
        public static User GetUserByUsername(string username)
        {
            using (var context = new LibraryDBContext())
            {
                var user = context.Users.FirstOrDefault(U => U.Username == username);
                return user;
            };

        }
        public static bool UserExist(string? username, string? password)
        {
            using (var context = new LibraryDBContext())
            {
                var user = context.Users.FirstOrDefault(U => U.Username == username && U.Password == password);
                if (user != null) return true;

                return false;
            };

        }
    }
}
