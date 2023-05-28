using BigBangAssessmentNew.DTO;
using BigBangAssessmentNew.Model;
using BigBangAssessmentNew.Repositories.RepoInterface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigBangAssessmentNew.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepositories _hotelRepo;

        public RoomController(IRoomRepositories hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }


        [HttpGet]
        public async Task<IActionResult>GetAllHotels()
        {
            try
            {
                var hotels = await _hotelRepo.GetAllRoom();
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult>GetRoomById(int id)
        {
            try
            {
                var hotel = await _hotelRepo.GetRoomById(id);
                if (hotel == null)
                {
                    return NotFound();
                }
                return Ok(hotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult>PostHotels([FromBody] RoomDTO room)
        {
            try
            {
                if (room == null)
                {
                    return BadRequest();
                }
                var addedHotel = await _hotelRepo.PostRoom(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = addedHotel.RoomId }, addedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult>PutHotel(int id, [FromBody] Room room)
        {
            try
            {
                if (room == null || room.RoomId != id)
                {
                    return BadRequest();
                }
                var updatedHotel = await _hotelRepo.PutRoom(id, room);
                if (updatedHotel == null)
                {
                    return NotFound();
                }
                return Ok(updatedHotel);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteHotels(int id)
        {
            try
            {
                var room = await _hotelRepo.DeleteRoom(id);
                if (room == null)
                {
                    return NotFound();
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Room-Type")]
        public async Task<IActionResult> GetHotelsByRoomType(string Roomtype)
        {
            try
            {
                var hotels = await _hotelRepo.GetHotelsByRoomType(Roomtype);
                if (hotels == null)
                {
                    return NotFound();
                }
                return Ok(hotels);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
