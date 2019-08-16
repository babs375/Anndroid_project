
using SQLite;

namespace project.Model
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}