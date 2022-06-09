using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Http;

namespace StudentskaSluzbaAPI.Controllers
{
    public class AuthController : ControllerBase
    {
        [Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/data/authenticate")]
        public IHttpActionResult GetForAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;
            return (IHttpActionResult)Ok();
        }
    }
}
