using AdditionalTask2.Models.DTOs;
using AdditionalTask2.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdditionalTask2.Controllers
{
    [ApiController]
    [Route("api/trips")]
    public class TripController : ControllerBase
    {
        private readonly ITripService tripService;

        public TripController(ITripService tripService)
        {
            this.tripService = tripService;
        }

        [HttpGet]
        public async Task<IEnumerable<TripDTO>> GetTrips()
        {
            return await tripService.GetTrips();
        }

        [HttpGet("{tripId}")]
        public async Task<ActionResult<TripDTO>> GetTripById(int tripId)
        {
            var trip = await tripService.GetTripById(tripId);

            if(trip == null)
            {
                return NotFound();
            }

            return Ok(trip);

        }

        [HttpDelete("{tripId}")]
        public async Task<ActionResult<string>> DeleteTrip(int tripId)
        {
            var trip = await tripService.DeleteTrip(tripId);

            if(trip == null)
            {
                return NotFound();
            }

            return Ok(trip);
        }
    }
}
