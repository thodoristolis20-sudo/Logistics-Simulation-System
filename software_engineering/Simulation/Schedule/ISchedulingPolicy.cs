using Domain;
using System.Collections.Generic;

namespace Scheduling
{
    public interface ISchedulingPolicy
    {
        void AssignOrders(
            List<Order> orders,
            List<Truck> trucks,
            RoadGraph roadGraph,
            Simulation.SimulationConfig config,
            Simulation.MetricsCollector metrics
        );
    }
}
