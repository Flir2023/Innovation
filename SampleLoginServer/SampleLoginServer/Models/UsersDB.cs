using System.ComponentModel;

namespace WebApplicaion.Models
{
    public class UsersDB
    {
        public List<User> UsersList { get; set; }
        private static UsersDB? instance = null;

        public UsersDB()
        {
            UsersList = new List<User>
            {
                new User("Admin", "1234", "aaa@aa.com"),
                new User("admin", "Dv123456", "yyy@flir.com"),
                new User("admin", "admin", "ccc@flir.com")
            };
        }

        public static UsersDB Instance()
        {
            if (instance == null)
            {
                instance = new UsersDB();
            }
            return instance;
        }
    }
}
