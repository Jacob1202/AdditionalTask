using AdditionalTask2.Context;
using AdditionalTask2.Models;
using AdditionalTask2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AdditionalTask2.Repositories.Implementations
{

    public class TripRepository : ITripRepository
    {
        private readonly AdditionalTaskContext _context;

        public TripRepository(AdditionalTaskContext context)
        {
            _context = context;
        }

        public async Task<string?> DeleteTripAsync(int id)
        {
            var wantedTrip = await _context.Trips.FirstOrDefaultAsync(p => p.IdTrip == id);

            if(wantedTrip == null)
            {
                return null;
            }

            return "Success";
        }

        public async Task<Trip?> GetTripByIdAsync(int id)
        {
            return await _context.Trips.FirstOrDefaultAsync(p => p.IdTrip == id);
        }

        public async Task<IEnumerable<Trip>> GetTripsAsync()
        {
            return await _context.Trips.ToListAsync();
        }
    }
}
