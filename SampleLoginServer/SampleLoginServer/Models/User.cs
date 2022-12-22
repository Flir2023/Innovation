using System.Globalization;

namespace WebApplicaion.Models
{
    public class User
    {
        public String Name { get; set; }
        public String Password { get; set; }
        public String? Email { get; set; }

        public User(String name, String password, String email = "")
        {
            this.Name = name;
            this.Password = password;
            this.Email = email;
        }
    }
}
