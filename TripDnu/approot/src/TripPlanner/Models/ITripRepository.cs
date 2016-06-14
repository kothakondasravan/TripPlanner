using System.Collections.Generic;

namespace TripPlanner.Models
{
    public interface ITripRepository
    {
        IEnumerable<Trip> GetAllTrips();
        IEnumerable<Trip> GetAllTripsWithStops();
        void AddTrip(Trip newTrip);
        bool SaveAll();
        Trip GetTripByName(string tripName,string username);
        void AddStop(string tripName, string username, Stop newStop);
        IEnumerable<Trip> GetAllTripsWithStops(string name);
    }
}