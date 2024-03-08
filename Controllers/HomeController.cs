using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskApi.ModelViews;

namespace TaskApi.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public HomeController()
        {

        }

        [HttpGet]
        public HomeView Index()
        {
            return new HomeView
            {
                Message = "Welcome to tasks api",
                Documentation = "/swagger"
            };
        }
    }
}
