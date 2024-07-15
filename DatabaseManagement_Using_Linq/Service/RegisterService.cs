using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using System.Linq;

namespace DatabaseManagement_Using_Linq.Service
{
    public class RegisterService : IRegister
    {
        private readonly DataDbContext _sql;

        public RegisterService(DataDbContext IDbContext)
        {
            _sql = IDbContext;
        }

        public User AddUsers(User request)
        {
            try
            {
                // Check for duplicate Contact Number

                if (_sql.Users.Any(u => u.Mobile == request.Mobile))
                {
                    throw new ArgumentException("Contact is already registered.");
                
                }

                // Check for duplicate Email

                if (_sql.Users.Any(u => u.Email == request.Email))
                {
                    throw new ArgumentException("Email is already registered.");
                }

                _sql.Users.Add(request);
                _sql.SaveChanges();
                return request;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public User EditUsers( User request)
        {
            
                var userExists = _sql.Users.Any(u => u.Id == request.Id);

                if (!userExists)
                {
                    throw new ArgumentException("User not found.");
                }
                if (_sql.Users.Any(u => u.Name == request.Name && u.Id != request.Id))
                {
                    throw new ArgumentException("Name is already exist ! Enter different name ");
                }


                if (_sql.Users.Any(u => u.Mobile == request.Mobile && u.Id != request.Id))
                {
                    throw new ArgumentException("Mobile number  is already registered ! Try with different  number ");
                }


                if (_sql.Users.Any(u => u.Email == request.Email && u.Id != request.Id))
                {
                    throw new ArgumentException (" Email is already registered ! Try with different  Email ");
                }
                 

                var userToUpdate = _sql.Users.Single(u => u.Id == request.Id); 

                userToUpdate.Name = request.Name;
                userToUpdate.Email = request.Email;
                userToUpdate.Mobile = request.Mobile;
                userToUpdate.UserName = request.UserName;
                userToUpdate.Password = request.Password;

            // Save changes to the database
            _sql.SaveChanges();

                return userToUpdate;
            
           

        }

        public Object GetUserData(int UserId)
        {
            Object returnval = null;


            var IdExist = _sql.Users.Find(UserId);

            if (IdExist!= null)
            {

                returnval = new
                {
                    Username = IdExist.UserName,
                    name = IdExist.Name,
                    mobile = IdExist.Mobile,
                    email = IdExist.Email
                };

            }
            else
            {
                throw new ArgumentException("Result Not Found");
            }
            return returnval;
        }

        public void DeleteUsers(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }
    }

}
