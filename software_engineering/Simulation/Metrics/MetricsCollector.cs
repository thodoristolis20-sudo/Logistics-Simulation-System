using System.Collections.Generic;

namespace Simulation
{
    public class MetricsCollector
    {
        public double TotalDistance { get; private set; }
        public double TotalCost { get; private set; }
        public double TotalRevenue { get; private set; }

        public Dictionary<string, double> DistancePerTruck { get; } = new();
        public Dictionary<string, double> VolumePerTruck { get; } = new();

        public void RecordTrip(string truckId, int distance, int volume, double cost, double revenue)
        {
            TotalDistance += distance;
            TotalCost += cost;
            TotalRevenue += revenue;

            if (!DistancePerTruck.ContainsKey(truckId))
            {
                DistancePerTruck[truckId] = 0;
                VolumePerTruck[truckId] = 0;
            }

            DistancePerTruck[truckId] += distance;
            VolumePerTruck[truckId] += volume;
        }

        public double Profit => TotalRevenue - TotalCost;
    }
}
