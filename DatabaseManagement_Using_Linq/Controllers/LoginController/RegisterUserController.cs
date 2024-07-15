using DatabaseManagement_Using_Linq.Common;
using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseManagement_Using_Linq.Controllers.LoginController
{
    [Route("api/[controller]")]
   // [Authorize]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        Response res = new Response();
        IRegister Register;

        public RegisterUserController(IRegister register)
        {
            Register = register;
        }
        [HttpPost("AddUser")]
        public Response AddUser(User request)
        {
            try
            {
                var result = Register.AddUsers(request);

                res.Data = result;
                res.ErrorCode = 0;
                res.Message = "Register Sucessfully";
            }
            catch (Exception ex)
            {
                res.Data = ex.Message;
                res.ErrorCode = 101;
                res.Message  = ex.Message;

            }
            return res;
        }
        //[Authorize]
        [HttpGet("getUserbyId")]
        public Response getUserbyId(int UserId)
        {
            try
            {
                var result = Register.GetUserData(UserId);
                res.Data = result;
                res.ErrorCode = 0;
            }
            catch(Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;
        
        }

        [HttpPut("EditUSer")]
        public Response EditUSer( User Request)
        {
            try
            {
                var result =  Register.EditUsers(Request);
                
               if (result != null)
                {
                    res.Data = result;
                    res.ErrorCode = 0;
                    res.Message = "Update Sucessfully";
                }

            }
            catch (Exception ex)
            {
                res.ErrorCode = 101;
                res.Message = ex.Message;
            }
            return res;

        }
        [HttpDelete("DeleteUser")]
        public Response DeleteUser(int id)
        {
            return null;
        }
       
    }
}
