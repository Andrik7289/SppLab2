namespace CountdownClock;

public class ClockObserver
{
    private int observerId;

    public ClockObserver(int observerId)
    {
        this.observerId = observerId;
    }
    
    public void SubscribeClock(Clock clock)
    {
        clock.CountdownFinished += OnCountdownFinished;
    }
    
    private void OnCountdownFinished(object? sender, ClockEventArgs e)
    {
        Console.WriteLine($"Observer {observerId}, Event message: {e.Message}. Event time: {e.EventTime}");
    }
}