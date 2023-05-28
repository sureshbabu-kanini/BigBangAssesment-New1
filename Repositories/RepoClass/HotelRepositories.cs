using BigBangAssessmentNew.Data;
using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;
using BigBangAssessmentNew.Repositories.RepoInterface;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace BigBangAssessmentNew.Repositories.RepoClass
{
    public class HotelRepositories : IHotelRepositories
    {
        private readonly APIdbContext projectcontext;

        public HotelRepositories(APIdbContext context)
        {
            this.projectcontext = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            try
            {
                return await projectcontext.hotels.Include(x => x.Rooms).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Hotel> GetHotelById(int id)
        {
            try
            {
                return await projectcontext.hotels.Include(x => x.Rooms).FirstOrDefaultAsync(x => x.HotelId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PostHotels(HotelDTO hotel)
        {
            try
            {

                var newHotel = new Hotel
                {
                    Name = hotel.Name,
                    Address = hotel.Address,
                    PhoneNumber = hotel.PhoneNumber

                };
                projectcontext.hotels.Add(newHotel);
                await projectcontext.SaveChangesAsync();
                return newHotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> PutHotel(int id, Hotel hotel)
        {
            try
            {
                projectcontext.Entry(hotel).State = EntityState.Modified;
                await projectcontext.SaveChangesAsync();
                return hotel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Hotel> DeleteHotels(int id)
        {
            try
            {
                Hotel del = await projectcontext.hotels.FirstOrDefaultAsync(x => x.HotelId == id);
                projectcontext.hotels.Remove(del);
                await projectcontext.SaveChangesAsync();
                return del;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<string> GetRoomCount(string hotelName)
        {
            try
            {
                // Find the hotel with the specified name
                Hotel hotel = await projectcontext.hotels
                    .Include(h => h.Rooms)
                    .FirstOrDefaultAsync(h => h.Name == hotelName);

                if (hotel != null)
                {
                    // Get the count of rooms in the hotel
                    int roomCount = hotel.Rooms.Count;

                    // Construct the message with the room count and details
                    StringBuilder messageBuilder = new StringBuilder();
                    messageBuilder.AppendLine($"Hotel: {hotel.Name}");
                    messageBuilder.AppendLine($"Address: {hotel.Address}");
                    messageBuilder.AppendLine($"Phone Number: {hotel.PhoneNumber}");
                    messageBuilder.AppendLine($"Room Count: {roomCount}");

                    // Append the details of each room
                    if (roomCount > 0)
                    {
                        messageBuilder.AppendLine("Room Details:");
                        foreach (Room room in hotel.Rooms)
                        {
                            messageBuilder.AppendLine($"- Room Number: {room.RoomNumber}");
                            messageBuilder.AppendLine($"  Room Type: {room.Type}");
                            // Add more room details if necessary
                        }
                    }

                    return messageBuilder.ToString();
                }

                return $"No hotel found with the name: {hotelName}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<string> GetPhoneNumber(string address)
        {
            try
            {
                Hotel hotel = await projectcontext.hotels.FirstOrDefaultAsync(h => h.Address == address);

                if (hotel != null)
                {
                    string hotelInfo = $"{hotel.Name} hotel is available at {hotel.Address}" + $" - Phone Number :  {hotel.PhoneNumber} ";
                    return hotelInfo;
                }
                return $"No hotel found at the address: {address}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
