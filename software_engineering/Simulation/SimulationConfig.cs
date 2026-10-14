namespace Simulation
{
    public class SimulationConfig
    {
        public int SimulationDays { get; } = 180;   // ~6 months
        public int HoursPerDay { get; } = 24;

        public double TruckSpeedKmPerHour { get; } = 100;
        public double CostPer100Km { get; } = 10.0;
        public double RevenuePerUnitPer100Km { get; } = 10.0;
    }
}
