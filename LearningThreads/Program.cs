using System;
using System.Threading;
using System.Threading.Tasks;

namespace LearningThreads
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 50; i++)
            {
                // Threads create new threads for each task as they are all started at the same time.
                Thread myThread = new Thread(new ThreadStart(Work));
                myThread.Start();

                // Whereas Tasks reuse the same thread once that thread has completed a previous task. (Tasks are managed by the Thread Pool.)
                Task.Run(() =>
               {
                   Console.WriteLine("Starting Task: " + Thread.CurrentThread.ManagedThreadId);
                   Thread.Sleep(3000);
                   Console.WriteLine("Task Complete");
               });
               // Moral of the story: Tasks are often more efficient to use than threads but offer less control.
               // Tasks are managed by the threadpool so they are more efficient. However, threads allow you to have more control.
            }

            Console.ReadLine();
        }

        static void Work()
        {
            Console.WriteLine("Starting Thread: " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            Console.WriteLine("Thread Complete");
        }
    }
}
