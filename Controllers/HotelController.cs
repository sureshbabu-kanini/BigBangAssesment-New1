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
    public class HotelController : ControllerBase
    {
            private readonly IHotelRepositories _hotelRepo;

            public HotelController(IHotelRepositories hotelRepo)
            {
                _hotelRepo = hotelRepo;
            }

            [HttpGet]
            public async Task<IActionResult>GetAllHotels()
            {
                try
                {
                    var hotels = await _hotelRepo.GetAllHotels();
                    return Ok(hotels);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            [HttpGet("{id}")]
            public async Task<IActionResult>GetHotelById(int id)
            {
                try
                {
                    var hotel = await _hotelRepo.GetHotelById(id);
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
            public async Task<IActionResult>PostHotels([FromBody] HotelDTO hotel)
            {
                try
                {
                    if (hotel == null)
                    {
                        return BadRequest();
                    }
                    var addedHotel = await _hotelRepo.PostHotels(hotel);
                    return CreatedAtAction(nameof(GetHotelById), new { id = addedHotel.HotelId }, addedHotel);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }


            [HttpPut("{id}")]
            public async Task<IActionResult>PutHotel(int id, [FromBody] Hotel hotel)
            {
                try
                {
                    if (hotel == null || hotel.HotelId != id)
                    {
                        return BadRequest();
                    }
                    var updatedHotel = await _hotelRepo.PutHotel(id, hotel);
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
                    var hotel = await _hotelRepo.DeleteHotels(id);
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

            [HttpGet("Room-count")]
            public async Task<IActionResult>GetRoomCount(string hotelName)
            {
                try
                {
                    var hotel = await _hotelRepo.GetRoomCount(hotelName);
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

            [HttpGet("Address")]
            public async Task<IActionResult>GetAddress(string Address)
            {
                try
                {
                    var hotel = await _hotelRepo.GetPhoneNumber(Address);
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
        }
}
