using Domain;

namespace Domain
{
    public class Truck
    {
        public string Id { get; }
        public int Capacity { get; }
        public City CurrentCity { get; private set; }

        public bool IsAvailable { get; private set; } = true;

        public Truck(string id, int capacity, City startCity)
        {
            Id = id;
            Capacity = capacity;
            CurrentCity = startCity;
        }

        public void MoveTo(City destination)
        {
            CurrentCity = destination;
            IsAvailable = false;
        }

        public void SetAvailable()
        {
            IsAvailable = true;
        }
    }
}
