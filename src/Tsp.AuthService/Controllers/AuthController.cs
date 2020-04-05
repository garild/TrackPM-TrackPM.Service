﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tsp.Authorization;
using Tsp.Authorization.JWT;

namespace Tsp.AuthService.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IJwtAuthorizeHandler _authorizeHandler;

        public AuthController(IJwtAuthorizeHandler authorizeHandler)
        {
            _authorizeHandler = authorizeHandler;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("[action]")]
        public JsonResult Login([FromBody] JwtUserDto user)
        {
           _authorizeHandler.AuthorizeUser(user, HttpContext);

            return Json(user);
        }

        //[HttpPost]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Route("[action]")]
        //public JsonResult Login([FromBody] JwtUserDto user)
        //{
        //    //TODO EF inMemory User validate etc

        //    return Json(user);
        //}
    }
}