using LibraryData;
using LibraryDomain;

namespace LibraryManagement1.Controller
{
    public class UsersController
    {
        public static void Add(List<User>? defaultUsers)
        {
            using (var context = new LibraryDBContext())
            {
                context.Users.AddRange(defaultUsers);
                context.SaveChanges();
            }
        }
        public static List<User> Get()
        {
            using (var context = new LibraryDBContext())
            {
                var Users = context.Users.ToList();
                return Users;
            };
        }
        public static User Get(string username)
        {
            var users = Get();
            foreach (var user in users)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }
            return new User();
        }
        public static bool find(string? username, string? password)
        {
            var Users = Get();
            foreach (var user in Users)
            {
                if (username == user.Username && password == user.Password)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
