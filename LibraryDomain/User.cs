﻿namespace LibraryDomain
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
        public List<UserBook> UserBooks { get; set; } = new List<UserBook>();


    }
}
