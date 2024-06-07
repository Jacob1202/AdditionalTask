using AdditionalTask2.Models;
using AdditionalTask2.Models.DTOs;
using AdditionalTask2.Repositories.Interfaces;

namespace AdditionalTask2.Services
{
    public class TripService : ITripService
    {

        private readonly ITripRepository _tripRepository;

        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task<string?> DeleteTrip(int id)
        {
            var trip = await _tripRepository.DeleteTripAsync(id);

            if(trip == null)
            {
                return null;
            }

            return "Success";
        }

        public async Task<TripDTO?> GetTripById(int id)
        {
            var trip = await _tripRepository.GetTripByIdAsync(id);

            if(trip == null)
            {
                return null;
            }

            var tripToReturn = new TripDTO
            {
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                Description = trip.Description,
                IdTrip = trip.IdTrip,
                MaxPeople = trip.MaxPeople,
                Name = trip.Name,
            };

            return tripToReturn;
        }

        public async Task<IEnumerable<TripDTO>> GetTrips()
        {
            var trips = await _tripRepository.GetTripsAsync();

            return trips.Select(e => new TripDTO
            {
                DateFrom = e.DateFrom,
                DateTo = e.DateTo,
                Description = e.Description,
                IdTrip = e.IdTrip,
                MaxPeople = e.MaxPeople,
                Name = e.Name,
            });
        }
    }
}
