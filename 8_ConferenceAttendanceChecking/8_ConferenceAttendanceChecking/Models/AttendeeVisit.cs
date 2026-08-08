using System.ComponentModel.DataAnnotations;

namespace _8_ConferenceAttendanceChecking.Models
{
    public class AttendeeVisit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ticket Number is required.")]
        [Display(Name = "Ticket Number")]
        public string TicketNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company or School is required.")]
        [Display(Name = "Company / School")]
        public string Organization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact number is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event name is required.")]
        [Display(Name = "Event Name")]
        public string EventName { get; set; } = string.Empty;

        [Display(Name = "Check-In Time")]
        public DateTime CheckInTime { get; set; } = DateTime.Now;

        [Display(Name = "Check-Out Time")]
        public DateTime? CheckOutTime { get; set; }

        public string Status { get; set; } = "Present";

        public string? Notes { get; set; }
    }
}
