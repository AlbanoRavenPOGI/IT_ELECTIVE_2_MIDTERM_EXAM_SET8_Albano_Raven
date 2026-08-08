using _8_ConferenceAttendanceChecking.Models;

namespace _8_ConferenceAttendanceChecking.Repositories
{
    public interface IUserRepository
    {
        User? GetByUsername(string username);
        void Add(User user);
        bool ValidateUser(string username, string password);
    }
}
