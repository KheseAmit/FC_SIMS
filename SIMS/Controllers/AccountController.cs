using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FC.Entities;
using FC.Repositories;


namespace UI.Controllers
{
    

   
    public class AccountController : Controller
    {
        private IUserRepository UserRepository;
        public AccountController()
        {
            UserRepository = new UserRepository();

        }
        public ActionResult Index()
        {
          
            return View();
        }

        public ActionResult Login()
        {
            FC_Users fcUser = new FC_Users();
            return View("Login", fcUser);
        }

        [HttpPost]
        public ActionResult Login(FC_Users fcUser)
        {
            int id = 1;
            if (UserRepository.IsValidUser(fcUser,out id))
            {
                FormsAuthentication.SetAuthCookie(fcUser.Name, false);
                Session["UserId"] = id;
                Session["UserRole"] = fcUser.IsAdmin;
                return RedirectToAction("index", "Home");
            }
            else
            {
                fcUser = new FC_Users();
                ViewBag.InvalidLoginMessage = "Invalid Username and Password!";
                return View("Login", fcUser);
            }

        }
    }
}