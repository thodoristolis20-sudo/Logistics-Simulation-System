using Domain;

namespace Domain
{
    public enum CustomerType
    {
        Industry,
        Merchant
    }

    public class Customer
    {
        public string Id { get; }
        public City City { get; }
        public CustomerType Type { get; }

        public Customer(string id, City city, CustomerType type)
        {
            Id = id;
            City = city;
            Type = type;
        }
    }
}
