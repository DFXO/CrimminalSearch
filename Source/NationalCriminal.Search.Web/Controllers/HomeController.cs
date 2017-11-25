using System;
using System.Web.Mvc;
using NationalCriminal.Search.Service.ServiceTests.CriminalSearchRefernce;
using NationalCriminal.Search.Web.Models;
using NationalCriminal.Search.Web.Models.DataContext;
using UserProfile = NationalCriminal.Search.Web.Models.DataContext.UserProfile;

namespace NationalCriminal.Search.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }
            string message=Session["Message"] as string;

            if (!string.IsNullOrEmpty(message))
            {
                ViewBag.Message = message;
            }
            
            ViewBag.Welcome = "Welcome to Criminal Search Engine!";
            return View();
        }

        [HttpPost]
        public ActionResult Index(JsonUserSearchCriteria jsonRequest)
        {
            if (!IsUserLoggedIn())
            {
                return RedirectToAction("Login", "Account");
            }

            var loggedInUser = GetLoggedInUser();
            if (loggedInUser != null)
            {
                try
                {
                    Validator.ValidateJsonRequest(jsonRequest);
                    UserSearchCriteria searchCriteria = Translators.TranslateToServiceObjects(jsonRequest);
                    CriminalSearchRequest searchRequest = GetUserSearchRequest(searchCriteria, loggedInUser);
                    ServiceAccess.ServiceAccess serviceLayer = new ServiceAccess.ServiceAccess();
                    bool isServiceCallSuccess = serviceLayer.CriminalSearch(searchRequest);
                    if (isServiceCallSuccess)
                    {
                        Session["Message"]=
                            "Your request is in process, we will email you criminal records matched to your search criteria!";
                    }
                    else
                    {
                        Session["Message"] =
                            "Currently we can not process your request. please try after sometime.";
                    }
                }
                catch (Exception exception)
                {
                    Session["Message"] =
                            "An unknown error has occured while searching criminal records.";
                    return View();
                }
                return View();
            }
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public ActionResult LogOut(string redirecturl)
        {
            return RedirectToAction("Login", "Account");
        }

        private static CriminalSearchRequest GetUserSearchRequest(UserSearchCriteria searchCriteria, UserProfile loggedInUser)
        {
            CriminalSearchRequest ciminalSearchRequest = null;
            if (searchCriteria != null)
            {
                ciminalSearchRequest = new CriminalSearchRequest()
                {
                    SearchCriteria = Translators.TranslateToCriminalSearchCriteria(searchCriteria),
                    EmailId = loggedInUser.email_id,
                    //TODO: Set Max Results
                    MaxResults = 20,
                    SessionId = new Guid().ToString(),
                };
            }
            return ciminalSearchRequest;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private bool IsUserLoggedIn()
        {
            bool isUserLoggedIn = false;
            Models.DataContext.UserProfile profile = Session["user"] as Models.DataContext.UserProfile;
            if (profile != null)
            {
                isUserLoggedIn = true;
            }
            return isUserLoggedIn;
        }


        private Models.DataContext.UserProfile GetLoggedInUser()
        {
            return Session["user"] as Models.DataContext.UserProfile;
        }
    }
}
