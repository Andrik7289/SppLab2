namespace CountdownClock;

public class Clock
{
    public event EventHandler<ClockEventArgs> CountdownFinished;

    private TimeSpan duration;
    private Timer timer;

    public Clock(TimeSpan duration)
    {
        this.duration = duration;
    }

    public void Start()
    {
        timer = new Timer(OnCountdownFinished, null, duration, Timeout.InfiniteTimeSpan);
    }

    private void OnCountdownFinished(object? state)
    {
        timer.Dispose();
        CountdownFinished.Invoke(this, new ClockEventArgs("Timer finished.", DateTime.Now));
    }
}