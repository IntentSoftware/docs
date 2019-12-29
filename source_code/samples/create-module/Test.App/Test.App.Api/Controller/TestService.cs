using Intent.RoslynWeaver.Attributes;
using Microsoft.AspNetCore.Mvc;


[assembly: DefaultIntentManaged(Mode.Merge)] // Allowing additive updating of this file, while keeping user implementations
[assembly: IntentTemplate("MyModule.Templates.ControllerTemplate", Version = "1.0")]

namespace Test.App.Api.Controllers
{
    [Route("api/[controller]")]
    public class TestService : Controller
    {

        [HttpGet("[action]")]
        public IActionResult TestMe()
        {
            return Ok("It's working!");
        }

    }
}