using _8_ConferenceAttendanceChecking.Models;

namespace _8_ConferenceAttendanceChecking.Repositories
{
    public interface IAttendeeVisitRepository
    {
        IEnumerable<AttendeeVisit> GetAll();
        AttendeeVisit? GetById(int id);
        void Add(AttendeeVisit visit);
        void Update(AttendeeVisit visit);
        IEnumerable<AttendeeVisit> Search(string query);
    }
}
