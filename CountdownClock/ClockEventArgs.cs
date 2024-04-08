namespace CountdownClock;

public class ClockEventArgs : EventArgs
{
    public string Message { get; }
    public DateTime EventTime { get; }

    public ClockEventArgs(string message, DateTime eventTime)
    {
        Message = message;
        EventTime = eventTime;
    }
}