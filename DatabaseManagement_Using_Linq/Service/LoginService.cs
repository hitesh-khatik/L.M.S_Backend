using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;

namespace DatabaseManagement_Using_Linq.Service
{
    public class LoginService : ILogin
    {


        private readonly  DataDbContext _sql;
        public LoginService(DataDbContext IDbContext  )
        {
            _sql = IDbContext;
        }

        public dynamic Login(LoginModel request)
        {
            dynamic returnval = null;

        
            var user = _sql.Users.FirstOrDefault(u => u.UserName == request.UserName);

            if (user != null && user.Password == request.Password)
            {
                returnval = new { Msg = 1, Id = user.Id, Name = user.Name };

            }
            else
            {
                returnval = new { Msg = 0 };
            }

            return returnval;
        }

        
    }
}
