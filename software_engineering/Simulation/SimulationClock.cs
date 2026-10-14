namespace Simulation
{
    public class SimulationClock
    {
        public int CurrentDay { get; private set; }
        public int CurrentHour { get; private set; }

        public void Tick()
        {
            CurrentHour++;

            if (CurrentHour >= 24)
            {
                CurrentHour = 0;
                CurrentDay++;
            }
        }

        public bool IsFinished(int maxDays)
        {
            return CurrentDay >= maxDays;
        }
    }
}
