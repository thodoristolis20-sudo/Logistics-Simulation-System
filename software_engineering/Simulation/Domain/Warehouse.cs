using Domain;

namespace Domain
{
    public class Warehouse
    {
        public string Location { get; }
        public int ShortTermCapacity { get; }
        public int LongTermCapacity { get; }

        public int CurrentShortTermLoad { get; private set; }
        public int CurrentLongTermLoad { get; private set; }

        public Warehouse(string location, int shortTermCapacity, int longTermCapacity)
        {
            Location = location;
            ShortTermCapacity = shortTermCapacity;
            LongTermCapacity = longTermCapacity;
        }

        public bool CanStoreShortTerm(int volume)
        {
            return CurrentShortTermLoad + volume <= ShortTermCapacity;
        }

        public bool CanStoreLongTerm(int volume)
        {
            return CurrentLongTermLoad + volume <= LongTermCapacity;
        }

        public void StoreShortTerm(int volume)
        {
            CurrentShortTermLoad += volume;
        }

        public void StoreLongTerm(int volume)
        {
            CurrentLongTermLoad += volume;
        }
    }
}
