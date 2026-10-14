using Domain;
using Simulation;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    public class AlternativeSchedulingPolicy : ISchedulingPolicy
    {
        public void AssignOrders(
            List<Order> orders,
            List<Truck> trucks,
            RoadGraph roadGraph,
            SimulationConfig config,
            MetricsCollector metrics)
        {
            var pendingOrders = orders
                .Where(o => !o.IsCompleted)
                .GroupBy(o => o.Customer.City);

            foreach (var cityGroup in pendingOrders)
            {
                City destination = cityGroup.Key;

                Truck truck = trucks.FirstOrDefault(t => t.IsAvailable);
                if (truck == null)
                    return;

                if (!roadGraph.HasRoad(truck.CurrentCity, destination))
                    continue; // ❗ skip unreachable city

                int remainingCapacity = truck.Capacity;
                int totalVolume = 0;

                foreach (Order order in cityGroup)
                {
                    if (order.Volume <= remainingCapacity)
                    {
                        remainingCapacity -= order.Volume;
                        totalVolume += order.Volume;
                        order.Complete();
                    }
                }

                if (totalVolume == 0)
                    continue;

                int distance = roadGraph.GetDistance(truck.CurrentCity, destination);
                double cost = (distance / 100.0) * config.CostPer100Km;
                double revenue = (distance / 100.0) * config.RevenuePerUnitPer100Km * totalVolume;

                metrics.RecordTrip(truck.Id, distance, totalVolume, cost, revenue);

                truck.MoveTo(destination);
                truck.SetAvailable();
            }
        }
    }
}
