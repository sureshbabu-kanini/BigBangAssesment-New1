using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;

namespace BigBangAssessmentNew.Repositories.RepoInterface
{
    public interface IRoomRepositories
    {
        Task<IEnumerable<Room>> GetAllRoomAsync();
        Task<Room> GetRoomByIdAsync(int id);
        Task<Room> PostRoomAsync(RoomDTO room);
        Task<Room> PutRoomAsync(int id, Room room);
        Task<Room> DelRoomAsync(int id);
        Task<IEnumerable<Room>> GetRoomsByTypeAndCapacityAsync(string type, int capacity);
    }
}
