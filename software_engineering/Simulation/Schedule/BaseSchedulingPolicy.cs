using Domain;
using Simulation;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    public class BaseSchedulingPolicy : ISchedulingPolicy
    {
        public void AssignOrders(
            List<Order> orders,
            List<Truck> trucks,
            RoadGraph roadGraph,
            SimulationConfig config,
            MetricsCollector metrics)
        {
            foreach (Order order in orders.Where(o => !o.IsCompleted))
            {
                Truck truck = trucks.FirstOrDefault(t => t.IsAvailable);
                if (truck == null)
                    break;

                int distance = roadGraph.GetDistance(truck.CurrentCity, order.Customer.City);
                double cost = (distance / 100.0) * config.CostPer100Km;
                double revenue = (distance / 100.0) * config.RevenuePerUnitPer100Km * order.Volume;

                metrics.RecordTrip(truck.Id, distance, order.Volume, cost, revenue);

                truck.MoveTo(order.Customer.City);
                truck.SetAvailable();

                order.Complete();
            }
        }
    }
}
