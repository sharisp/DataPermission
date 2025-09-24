using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DataPermission.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionKeyController : ControllerBase
    {
        [HttpGet]
        public ActionResult<ApiResponse<List<string>>> GetAllPermissionKeys()
        {
            var permissionKeys = PermissionScanner.GetAllPermissionKeys(Assembly.GetExecutingAssembly());

            return this.OkResponse(permissionKeys);
        }
    }
}
