using System.ComponentModel.DataAnnotations;

namespace BigBangAssessmentNew.Model
{
    public class Hotel
    {
        [Key]
        public int HotelId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        public virtual ICollection<Room>? Rooms { get; set; }
    }
}
