using Simulation;

class Program
{
    static void Main(string[] args)
    {
        SimulationConfig config = new SimulationConfig();
        SimulationEngine engine = new SimulationEngine(config);

        engine.Run();

        Console.WriteLine("Simulation completed.");
    }
}

