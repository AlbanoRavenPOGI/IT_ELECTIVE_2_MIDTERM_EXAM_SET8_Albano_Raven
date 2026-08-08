using _8_ConferenceAttendanceChecking.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _8_ConferenceAttendanceChecking.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}