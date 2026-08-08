using _8_ConferenceAttendanceChecking.Models;
using _8_ConferenceAttendanceChecking.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _8_ConferenceAttendanceChecking.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private readonly IAttendeeVisitRepository _attendeeRepository;

        public AttendeeController(IAttendeeVisitRepository attendeeRepository)
        {
            _attendeeRepository = attendeeRepository;
        }

        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var list = _attendeeRepository.Search(searchString);
            return View(list);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AttendeeVisit visit)
        {
            if (ModelState.IsValid)
            {
                _attendeeRepository.Add(visit);
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var visit = _attendeeRepository.GetById(id);
            if (visit == null) return NotFound();
            return View(visit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, AttendeeVisit visit)
        {
            if (id != visit.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _attendeeRepository.Update(visit);
                return RedirectToAction(nameof(Index));
            }
            return View(visit);
        }

        public IActionResult Details(int id)
        {
            var visit = _attendeeRepository.GetById(id);
            if (visit == null) return NotFound();
            return View(visit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(int id)
        {
            var visit = _attendeeRepository.GetById(id);
            if (visit != null && visit.Status == "Present")
            {
                visit.CheckOutTime = DateTime.Now;
                visit.Status = "Left Event";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}