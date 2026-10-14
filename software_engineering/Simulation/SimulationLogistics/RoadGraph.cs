using System.Collections.Generic;
using Domain;

namespace Domain
{
    public class RoadGraph
    {
        private readonly Dictionary<City, Dictionary<City, int>> _distances;

        public RoadGraph()
        {
            _distances = new Dictionary<City, Dictionary<City, int>>();
        }

        public void AddCity(City city)
        {
            if (!_distances.ContainsKey(city))
            {
                _distances[city] = new Dictionary<City, int>();
            }
        }

        public void AddRoad(City from, City to, int distanceKm)
        {
            AddCity(from);
            AddCity(to);

            _distances[from][to] = distanceKm;
            _distances[to][from] = distanceKm;
        }

        public bool HasRoad(City from, City to)
        {
            return _distances.ContainsKey(from) && _distances[from].ContainsKey(to);
        }

        public int GetDistance(City from, City to)
        {
            if (HasRoad(from, to))
                return _distances[from][to];

            return -1; // ❗ defensive: no connection
        }
    }
}
