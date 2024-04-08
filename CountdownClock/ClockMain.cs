namespace CountdownClock;

public class ClockMain
{
    static void Main(string[] args)
    {
        Console.Write("Enter time for clock: ");

        if (!int.TryParse(Console.ReadLine(), out int seconds) || seconds <= 0)
        {
            Console.WriteLine("Invalid seconds number.");
            return;
        }

        Clock clock = new Clock(TimeSpan.FromSeconds(seconds));

        int observersCount = 5;
        for (int i = 1; i <= observersCount; i++)
        {
            ClockObserver observer = new ClockObserver(i);
            observer.SubscribeClock(clock);
        }

        clock.Start();
        Console.WriteLine($"Clock started, time = {DateTime.Now}");
        Console.ReadLine();
    }
}