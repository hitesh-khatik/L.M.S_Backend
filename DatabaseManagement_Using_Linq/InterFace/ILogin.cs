using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.InterFace
{
    public interface ILogin
    {
        public dynamic Login(LoginModel request);
    }
}
