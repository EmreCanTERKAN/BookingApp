
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

           var result =  await _hotelService.AddHotel(hotelDto);

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
