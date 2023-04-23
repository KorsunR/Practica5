using System.Windows.Documents;

namespace Practica5
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public User(JEDKIYDataSet2.USsERRow uSsERRow) {
            Id = uSsERRow.ID;
            Login = uSsERRow.Login;
            Password = uSsERRow.Password;
            Role = uSsERRow.Rol;
        }
    }
}