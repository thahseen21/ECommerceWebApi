using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Transactions;
using Identity;
using Identity.IdentityModels;
using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PresentationLayer.Utils;
using CustomModel;

namespace PresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private readonly RoleManager<Role> _roleManager;

        private readonly JwtHelper _jwtHelper;

        public AuthController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<Role> roleManager, IConfiguration config)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;

            this._jwtHelper = new JwtHelper(config);
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser(RegisterCustomModel model)
        {
            try
            {
                var entity = new User();

                if (ModelState.IsValid)
                {
                    if (await _userManager.FindByNameAsync(model.UserName) != null)
                    {
                        return StatusCode(403, "Username already exists");
                    }

                    if (await _userManager.FindByEmailAsync(model.Email) != null)
                    {
                        return StatusCode(403, "User already exists");
                    }

                    entity = model.Adapt<User>();

                    using (TransactionScope scope = new TransactionScope(System.Transactions.TransactionScopeAsyncFlowOption.Enabled))
                    {
                        var isUserCreated = await _userManager.CreateAsync(entity, model.Password);
                        if (isUserCreated.Succeeded)
                        {
                            var role = await _roleManager.FindByNameAsync("Customer");

                            var roleResult = await _userManager.AddToRoleAsync(entity, role.Name);

                            if (roleResult.Succeeded)
                            {
                                scope.Complete();
                                return Ok("User Created");
                            }

                        }

                    }
                }
                return BadRequest("Something went wrong");

            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Something went wrong");
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginCustomModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await this._userManager.FindByNameAsync(model.UserName);

                    if (user == null)
                    {
                        return StatusCode(401, "Invalid email or password");
                    }

                    var tokenModel = new GenerateTokenCustomModel();
                    tokenModel = user.Adapt<GenerateTokenCustomModel>();

                    var result = await _signInManager
                        .PasswordSignInAsync(user,
                        model.Password,
                        false, false);

                    if (result.Succeeded)
                    {
                        var roleList = await this._userManager.GetRolesAsync(user);

                        tokenModel.RoleName = roleList[0];

                        var token = this._jwtHelper.GenerateToken(tokenModel);
                        return Ok(token);
                    }
                }
            }
            catch (System.Exception)
            {
            }
            return BadRequest("Something went wrong!!!");
        }
    }
}