namespace Spp3;

class MainClass
{
    static Mutex mutex = new Mutex();

    static void Main(string[] args)
    {
        Thread thread1 = new Thread(ThreadFunction);
        Thread thread2 = new Thread(ThreadFunction);

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        Console.WriteLine("All threads finished.");
    }

    static void ThreadFunction()
    {
        mutex.Lock();
        
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} in critical section.");
        Thread.Sleep(2000);
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} leaved critical section.");

        mutex.Unlock();
    }
}