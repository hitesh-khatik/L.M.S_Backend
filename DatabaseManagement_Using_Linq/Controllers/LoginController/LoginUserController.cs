using DatabaseManagement_Using_Linq.Common;
using DatabaseManagement_Using_Linq.InterFace;
using DatabaseManagement_Using_Linq.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatabaseManagement_Using_Linq.Controllers.LoginController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginUserController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogin _login;
        Response res = new Response();

        public LoginUserController( ILogin login , IConfiguration config)
        {
            _login = login;
            _config = config;
        }

        [HttpPost("Loginuser")]
        public IActionResult LoginUser([FromBody] LoginModel request)
        {
            IActionResult returnvalue = Unauthorized();

            var result = _login.Login(request);
            if (result.Msg == 1)
            {
                var token = generateToken(Convert.ToString(result.Id));

                res.ErrorCode = 0;
                res.Message = "Login Sucessfully";
                res.Data = new { token };
                returnvalue = Ok(new { res = res });
            }
            else
            {
                res.ErrorCode = 100;
                res.Message = "Incorrect Username & Password";
                returnvalue = Ok(new { res = res });
            }
            return returnvalue;
        }

        private string generateToken( string Userid)
        {
            var claims = new List<Claim>()
            {
                 new Claim("Status" ,"Success"),
                  new Claim("Userid", Userid)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey , SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(20);

             var token = new JwtSecurityToken(
               _config["Jwt:Issuer"],
               _config["Jwt:Audience"],
               claims,
               expires: expires,
               signingCredentials: credentials
           );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
