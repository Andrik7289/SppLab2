namespace TaskQueue;

public class TaskQueueMain
{
    static void Main(string[] args)
    {
        TaskQueue taskQueue = new TaskQueue(3);

        int tasksCount = 10;
        int currentTaskNumber = 0;

        for (int i = 0; i < tasksCount; i++)
        {
            int taskNumber = i + 1;
            taskQueue.AddTask(() =>
            {
                int numberToSum = taskNumber * 100;
                int sum = 0;
                for (int i = 1; i <= numberToSum; i++)
                {
                    sum += i;
                }

                currentTaskNumber++;
                Console.WriteLine($"Sum from 1 to {numberToSum} = {sum}");
                if (currentTaskNumber == tasksCount)
                {
                    taskQueue.Stop();
                }
            });
        }
    }
}