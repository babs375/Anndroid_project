
using SQLite;

namespace project.Model
{
    public class UserCart
    {
        [PrimaryKey, AutoIncrement]
        public int crtID { get; set; }
        public int fdID { get; set; }
        public int usrID { get; set; }
    }
}