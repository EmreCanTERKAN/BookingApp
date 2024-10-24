
using BookingApp.Business.Operations.Hotel;
using BookingApp.Business.Operations.Hotel.Dtos;
using BookingApp.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

    }
}
