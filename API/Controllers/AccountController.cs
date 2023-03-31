using API.Repositories.Data;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountRepository accountRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly IConfiguration configuration;

        public AccountController(AccountRepository accountRepository, EmployeeRepository employeeRepository, IConfiguration configuration)
        {
            this.accountRepository = accountRepository;
            this.employeeRepository = employeeRepository;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                var result = await accountRepository.Register(registerVM);
                return result is 0
                    ? Conflict(new { statusCode = 409, message = "Data fail to Insert!" })
                    : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });
            }
            catch
            {
                return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var userdata = accountRepository.GetUserdata(loginVM.Email);
                var roles = accountRepository.GetRolesByNIK(loginVM.Email);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, userdata.Email),
                    new Claim(ClaimTypes.Name, userdata.FullName)
                };
                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
                if (userdata is null)
                {
                    return BadRequest(new
                    {
                        StatusCode = 409,
                        massage = "Login Failed"
                    });

                }
                else
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                         issuer: configuration["JWT:Issuer"],
                        audience: configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signIn);
                    var generateToken = new JwtSecurityTokenHandler().WriteToken(token);

                    return Ok(new
                    {
                        StatusCode = 200,
                        Massage = "Login Success!",
                        Data = generateToken
                    });
                }


            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Massage = "Opps Login Failed!",

                });
            }

        }

    }
}
