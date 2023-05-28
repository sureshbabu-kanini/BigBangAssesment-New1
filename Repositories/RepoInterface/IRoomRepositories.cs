using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;

namespace BigBangAssessmentNew.Repositories.RepoInterface
{
    public interface IRoomRepositories
    {
        Task<IEnumerable<Room>> GetAllRoom();
        Task<Room> GetRoomById(int id);
        Task<Room> PostRoom(RoomDTO room);
        Task<Room> PutRoom(int id, Room room);
        Task<Room> DeleteRoom(int id);
        Task<IEnumerable<Hotel>> GetHotelsByRoomType(string Roomtype);

    }
}
