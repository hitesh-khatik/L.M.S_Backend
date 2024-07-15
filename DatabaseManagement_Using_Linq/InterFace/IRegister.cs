using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.InterFace
{
    public interface IRegister
    {
        public User AddUsers(User request);
        public User EditUsers( User request);
        public void  DeleteUsers(int id);
        public List<User> GetUsers();
        public Object GetUserData(int UserId);
    }
}
