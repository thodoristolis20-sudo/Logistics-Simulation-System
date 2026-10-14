using Domain;

namespace Domain
{
    public enum OrderType
    {
        ShortTerm,
        LongTerm
    }

    public class Order
    {
        public Customer Customer { get; }
        public int Volume { get; }
        public OrderType Type { get; }

        public bool IsCompleted { get; private set; }

        public Order(Customer customer, int volume, OrderType type)
        {
            Customer = customer;
            Volume = volume;
            Type = type;
        }

        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
