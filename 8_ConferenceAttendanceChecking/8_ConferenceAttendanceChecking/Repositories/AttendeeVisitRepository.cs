using _8_ConferenceAttendanceChecking.Models;

namespace _8_ConferenceAttendanceChecking.Repositories
{
    public class AttendeeVisitRepository : IAttendeeVisitRepository
    {
        private static readonly List<AttendeeVisit> _visits = new List<AttendeeVisit>
        {
            new AttendeeVisit
            {
                Id = 1,
                TicketNumber = "TICK-1001",
                FirstName = "Raven",
                LastName = "Albano",
                Organization = "Lyceum of Alabang",
                ContactNumber = "09171234567",
                Email = "reben@example.com",
                EventName = "Tech Summit 2026",
                CheckInTime = DateTime.Now.AddHours(-2),
                Status = "Present",
                Notes = "VIP Guest"
            }
        };

        public IEnumerable<AttendeeVisit> GetAll() => _visits;

        public AttendeeVisit? GetById(int id) => _visits.FirstOrDefault(v => v.Id == id);

        public void Add(AttendeeVisit visit)
        {
            visit.Id = _visits.Count > 0 ? _visits.Max(v => v.Id) + 1 : 1;
            visit.CheckInTime = DateTime.Now;
            visit.Status = "Present";
            _visits.Add(visit);
        }

        public void Update(AttendeeVisit visit)
        {
            var existing = GetById(visit.Id);
            if (existing != null)
            {
                existing.FirstName = visit.FirstName;
                existing.LastName = visit.LastName;
                existing.Organization = visit.Organization;
                existing.ContactNumber = visit.ContactNumber;
                existing.Email = visit.Email;
                existing.EventName = visit.EventName;
                existing.Notes = visit.Notes;
            }
        }

        public IEnumerable<AttendeeVisit> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return _visits;

            query = query.ToLower();
            return _visits.Where(v =>
                v.TicketNumber.ToLower().Contains(query) ||
                v.FirstName.ToLower().Contains(query) ||
                v.LastName.ToLower().Contains(query) ||
                v.Organization.ToLower().Contains(query) ||
                v.EventName.ToLower().Contains(query)
            );
        }
    }
}
