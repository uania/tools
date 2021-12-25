using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Uania.Tools.Web.Controllers
{
    [Authorize]
    [ApiController]
    public class UaniaBaseController : ControllerBase
    {

    }
}