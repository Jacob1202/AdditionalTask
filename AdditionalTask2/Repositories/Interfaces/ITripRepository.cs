using AdditionalTask2.Models;

namespace AdditionalTask2.Repositories.Interfaces
{
    public interface ITripRepository
    {
        public Task<Trip?> GetTripByIdAsync(int id);

        public Task<IEnumerable<Trip>> GetTripsAsync();

        public Task<string?> DeleteTripAsync(int id);
    }
}
