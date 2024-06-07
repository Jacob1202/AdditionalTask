using AdditionalTask2.Models.DTOs;

namespace AdditionalTask2.Services
{
    public interface ITripService
    {
        public Task<TripDTO?> GetTripById(int id);

        public Task<IEnumerable<TripDTO>> GetTrips();

        public Task<string?> DeleteTrip(int id);
    }
}
