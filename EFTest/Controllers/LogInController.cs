using EFTest.Models;
using EFTest.Models.ForgotPassword;
using System.Web.Mvc;

namespace EFTest.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        #region Log In
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ForgotPassword model)
        {
            ModelState.Remove("Email");
            ModelState.Remove("MobileNumber");
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        #endregion

        #region Register
        [HttpPost]
        public ActionResult Register(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "LogIn");
            }
            return RedirectToAction("Index", "LogIn");
        }
        #endregion

        #region Forgot Password
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("SendOTP", "LogIn");
            }
            return View();
        }
        #endregion

        #region Send OTP
        [HttpGet]
        public ActionResult SendOTP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SendOTP(OTPCode model)
        {
            return RedirectToAction("PasswordReset", "LogIn");
        }
        #endregion

        #region Reset Password
        [HttpGet]
        public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(ResetPassword model)
        {
            return RedirectToAction("Index", "LogIn");
        }
        #endregion
    }
}