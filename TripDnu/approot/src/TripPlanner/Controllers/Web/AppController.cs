using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripPlanner.Models;
using TripPlanner.Services;
using TripPlanner.ViewModels;

namespace TripPlanner.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private ITripRepository _repository;

        public AppController(IMailService service, ITripRepository repository)
        {
            _mailService = service;
            _repository = repository;
        }

        public ActionResult Index()
        {
           
            return View();
        }
       [Authorize]
        public IActionResult Trips()
        {
          
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (String.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem");
                }

                if(_mailService.SendMail(email,
                    email,
                    $"Contact Page from {model.Name} ({model.Email})",
                    model.Message))
                {
                    ModelState.Clear();

                    ViewBag.Message = "Mail Sent. Thanks!";
                }
            }

            return View();
        }
    }
}
