using BookingApp.Business.Operations.Hotel;
using BookingApp.Business.Operations.Hotel.Dtos;
using BookingApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotel(int id)
        {
            var hotel = await _hotelService.GetHotel(id);

            if (hotel is null)
            {
                return NotFound();
            }
            return Ok(hotel);

        }

        [HttpGet("GetAllHotel")]
        public async Task<IActionResult> GetHotels()
        {
            var hotels = await _hotelService.GetAllHotels();
                

                return Ok(hotels);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddHotel(AddHotelRequest request)
        {

            var hotelDto = new AddHotelDto
            {
                Name = request.Name,
                Stars = request.Stars,
                AccomodationType = request.AccomodationType,
                Location = request.Location,
                FeatureIds = request.FeatureIds,
            };

            var result = await _hotelService.AddHotel(hotelDto);

            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPatch("{id}/stars")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdjustHotelStars(int id , int changeBy)
        {
            var result = await _hotelService.AdjustHotelStars(id, changeBy);

            if (!result.IsSucceed)
            {
                return NotFound();
            }
            else
                return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            var result = await _hotelService.DeleteHotel(id);
            if (!result.IsSucceed)
            {
                return BadRequest(result.Message);
            }
            else
            {
                return Ok("Kayıt Başarıyla Silinmiştir");
            }

        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHotel (int id , UpdateHotelRequest request)
        {
            var updateHotelDto = new UpdateHotelDto
            {
                Id = id,
                Name = request.Name,
                Stars = request.Stars,
                Location = request.Location,
                AccomodationType = request.AccomodationType,
                FeatureIds = request.FeatureIds
            };



            var result = await _hotelService.UpdateHotel(updateHotelDto);

            if (!result.IsSucceed)
            {
                return NotFound(result.Message);
            }
            else
            {
                return await GetHotel(id);
            }
        }

    }
}
