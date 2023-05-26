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
            [ProducesResponseType(statusCode: 204)]
            [ProducesResponseType(statusCode: 200)]
            public async Task<IActionResult> GetAllHotels()
            {
                try
                {
                    var hotels = await _hotelRepo.GetAllHotelsAsync();
                    return Ok(hotels);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }

            [HttpGet("{id}")]
            [ProducesResponseType(statusCode: 204)]
            [ProducesResponseType(statusCode: 200)]
            public async Task<IActionResult> GetHotelById(int id)
            {
                try
                {
                    var hotel = await _hotelRepo.GetHotelByIdAsync(id);
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

            [ProducesResponseType(statusCode: 201)]
            [ProducesResponseType(statusCode: 409)]
            public async Task<IActionResult> PostHotels([FromBody] HotelDTO hotel)
            {
                try
                {
                    if (hotel == null)
                    {
                        return BadRequest();
                    }
                    var addedHotel = await _hotelRepo.PostHotelsAsync(hotel);
                    return CreatedAtAction(nameof(GetHotelById), new { id = addedHotel.HotelId }, addedHotel);
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }


            // PUT api/<ProjectController>/5
            [HttpPut("{id}")]
            public async Task<IActionResult> PutHotel(int id, [FromBody] Hotel hotel)
            {
                try
                {
                    if (hotel == null || hotel.HotelId != id)
                    {
                        return BadRequest();
                    }
                    var updatedHotel = await _hotelRepo.PutHotelAsync(id, hotel);
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
            public async Task<IActionResult> DelHotels(int id)
            {
                try
                {
                    var hotel = await _hotelRepo.DelHotelsAsync(id);
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


            [HttpGet("count-id")]
            public async Task<IActionResult> countHotels(int id)
            {
                try
                {
                    var hotel = await _hotelRepo.GetByIdAsync(id);
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
            [HttpGet("count")]
            public async Task<IActionResult> countrooms(int id)
            {
                try
                {
                    var hotel = await _hotelRepo.GetRoomCountMessageByHotelIdAsync(id);
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


            [HttpGet("address")]
            public async Task<IActionResult> address(string id)
            {
                try
                {
                    var hotel = await _hotelRepo.GetPhoneNumberByAddressAsync(id);
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
