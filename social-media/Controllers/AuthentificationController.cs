using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace social_media.Controllers
{
    public class AuthentificationController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register()
        {
            return View();
        }

    }
}
