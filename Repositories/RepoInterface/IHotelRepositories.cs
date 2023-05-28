using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;

namespace BigBangAssessmentNew.Repositories.RepoInterface
{
    public interface IHotelRepositories
    {
        Task<IEnumerable<Hotel>> GetAllHotels();
        Task<Hotel> GetHotelById(int id);
        Task<Hotel> PostHotels(HotelDTO hotel);
        Task<Hotel> PutHotel(int id, Hotel hotel);
        Task<Hotel> DeleteHotels(int id);
        Task<string> GetRoomCount(string hotelName);
        Task<string> GetPhoneNumber(string address);
    }
}
