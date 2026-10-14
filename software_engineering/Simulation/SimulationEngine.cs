using Domain;
using Scheduling;
using System;
using System.Collections.Generic;

namespace Simulation
{
    public class SimulationEngine
    {
        private readonly SimulationConfig _config;
        private readonly SimulationClock _clock;

        private RoadGraph _roadGraph;
        private List<City> _cities;
        private List<Warehouse> _warehouses;
        private List<Truck> _trucks;
        private List<Customer> _customers;
        private List<Order> _pendingOrders;

        private MetricsCollector _metrics;
        private ISchedulingPolicy _schedulingPolicy;

        private Random _random = new Random();

        public SimulationEngine(SimulationConfig config)
        {
            _config = config;
            _clock = new SimulationClock();
        }

        public void Run()
        {
            InitialiseSimulation();

            while (!_clock.IsFinished(_config.SimulationDays))
            {
                UpdateWorld();
                _clock.Tick();
            }

            PrintSummary();
        }

        private void InitialiseSimulation()
        {
            Console.WriteLine("Initialising simulation...");
            InitialiseCitiesAndRoads();
            InitialiseWarehouses();
            InitialiseTrucks();
            InitialiseCustomers();

            _pendingOrders = new List<Order>();
            _metrics = new MetricsCollector();

            // 🔁 Εναλλαγή πολιτικής εδώ
            //_schedulingPolicy = new AlternativeSchedulingPolicy();
             _schedulingPolicy = new BaseSchedulingPolicy();
        }

        private void InitialiseCitiesAndRoads()
        {
            _roadGraph = new RoadGraph();
            _cities = new List<City>();

            City athens = new City("Athens");
            City thessaloniki = new City("Thessaloniki");
            City larisa = new City("Larisa");
            City volos = new City("Volos");
            City kozani = new City("Kozani");

            _cities.AddRange(new[] { athens, thessaloniki, larisa, volos, kozani });

            _roadGraph.AddRoad(athens, larisa, 350);
            _roadGraph.AddRoad(larisa, thessaloniki, 150);
            _roadGraph.AddRoad(larisa, volos, 60);
            _roadGraph.AddRoad(thessaloniki, kozani, 140);
            _roadGraph.AddRoad(kozani, larisa, 120);
        }

        private void InitialiseWarehouses()
        {
            _warehouses = new List<Warehouse>
            {
                new Warehouse("Thessaloniki", 1000, 8000),
                new Warehouse("Athens", 2000, 15000),
                new Warehouse("Larisa", 500, 5000),
                new Warehouse("Volos", 1000, 3000),
                new Warehouse("Kozani", 2000, 8000)
            };
        }

        private void InitialiseTrucks()
        {
            _trucks = new List<Truck>();
            City startCity = _cities[0];

            for (int i = 0; i < 25; i++)
                _trucks.Add(new Truck($"S{i}", 10, startCity));

            for (int i = 0; i < 20; i++)
                _trucks.Add(new Truck($"M{i}", 23, startCity));

            for (int i = 0; i < 10; i++)
                _trucks.Add(new Truck($"L{i}", 45, startCity));
        }

        private void InitialiseCustomers()
        {
            _customers = new List<Customer>();
            int id = 1;

            foreach (City city in _cities)
            {
                int count = _random.Next(2, 9);

                for (int i = 0; i < count; i++)
                {
                    CustomerType type = _random.NextDouble() < 0.5
                        ? CustomerType.Industry
                        : CustomerType.Merchant;

                    _customers.Add(new Customer($"C{id++}", city, type));
                }
            }
        }

        private void UpdateWorld()
        {
            GenerateOrdersIfNeeded();

            _schedulingPolicy.AssignOrders(
                _pendingOrders,
                _trucks,
                _roadGraph,
                _config,
                _metrics
            );
        }

        private void GenerateOrdersIfNeeded()
        {
            if (_clock.CurrentDay % 3 != 0)
                return;

            foreach (Customer customer in _customers)
            {
                int volume = _random.Next(5, 51);
                OrderType type = _random.NextDouble() < 0.5
                    ? OrderType.ShortTerm
                    : OrderType.LongTerm;

                _pendingOrders.Add(new Order(customer, volume, type));
            }
        }

        private void PrintSummary()
        {
            Console.WriteLine("=== Simulation Summary ===");
            Console.WriteLine($"Days simulated: {_clock.CurrentDay}");
            Console.WriteLine($"Total distance: {_metrics.TotalDistance} km");
            Console.WriteLine($"Total cost: {_metrics.TotalCost} €");
            Console.WriteLine($"Total revenue: {_metrics.TotalRevenue} €");
            Console.WriteLine($"PROFIT: {_metrics.Profit} €");
        }
    }
}
