namespace TaskQueue;

using System;
using System.Collections.Generic;
using System.Threading;

public class TaskQueue
{
    private readonly int threadCount;
    private readonly Queue<Action> tasks = new Queue<Action>();
    private readonly List<Thread> threads = new List<Thread>();
    private readonly object lockObject = new object();
    private bool isRunning = true;

    public TaskQueue(int threadCount)
    {
        this.threadCount = threadCount;
        for (int i = 0; i < threadCount; i++)
        {
            var thread = new Thread(ExecuteTasks);
            thread.Start();
            threads.Add(thread);
        }
    }

    public void AddTask(Action task)
    {
        lock (lockObject)
        {
            tasks.Enqueue(task);
            Monitor.Pulse(lockObject);
        }
    }

    private void ExecuteTasks()
    {
        while (isRunning)
        {
            Action task = null;
            lock (lockObject)
            {
                while (tasks.Count == 0 && isRunning)
                {
                    Monitor.Wait(lockObject);
                }

                if (tasks.Count > 0)
                {
                    task = tasks.Dequeue();
                }
            }

            task?.Invoke();
        }
    }

    public void Stop()
    {
        isRunning = false;
        lock (lockObject)
        {
            Monitor.PulseAll(lockObject);
        }
    }
}