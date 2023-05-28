using BigBangAssessmentNew.Data;
using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;
using BigBangAssessmentNew.Repositories.RepoInterface;
using Microsoft.EntityFrameworkCore;

namespace BigBangAssessmentNew.Repositories.RepoClass
{
    public class RoomRepositories : IRoomRepositories
    {
        private readonly APIdbContext projectcontext;

        public RoomRepositories(APIdbContext context)
        {
            this.projectcontext = context;
        }

        public async Task<IEnumerable<Room>> GetAllRoom()
        {
            try
            {
                return await projectcontext.Rooms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> GetRoomById(int id)
        {
            try
            {
                return await projectcontext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PostRoom(RoomDTO room)
        {
            try
            {
                var newRoom = new Room
                {
                    RoomNumber = room.RoomNumber,
                    Type = room.Type,
                    Capacity = room.Capacity,
                    HotelId = room.HotelId,

                };
                projectcontext.Rooms.Add(newRoom);
                await projectcontext.SaveChangesAsync();
                return newRoom;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Room> PutRoom(int id, Room room)
        {
            try
            {
                projectcontext.Entry(room).State = EntityState.Modified;
                await projectcontext.SaveChangesAsync();
                return room;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Room> DeleteRoom(int id)
        {
            try
            {
                Room del = await projectcontext.Rooms.FirstOrDefaultAsync(x => x.RoomId == id);
                projectcontext.Rooms.Remove(del);
                await projectcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<IEnumerable<Hotel>> GetHotelsByRoomType(string Roomtype)
        {
            try
            {
                return await projectcontext.hotels
                    .Include(h => h.Rooms)
                    .Where(h => h.Rooms.Any(r => r.Type == Roomtype))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
