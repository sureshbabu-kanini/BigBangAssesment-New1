using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;

namespace BigBangAssessmentNew.Repositories.RepoInterface
{
    public interface IHotelRepositories
    {
        Task<IEnumerable<Hotel>> GetAllHotelsAsync();
        Task<Hotel> GetHotelByIdAsync(int id);
        Task<Hotel> PostHotelsAsync(HotelDTO hotel);
        Task<Hotel> PutHotelAsync(int id, Hotel hotel);
        Task<Hotel> DelHotelsAsync(int id);
        Task<string> GetRoomCountMessageByHotelIdAsync(int hotelId);
        Task<string> GetPhoneNumberByAddressAsync(string address);


        Task<Hotel> GetByIdAsync(int id);
    }
}
