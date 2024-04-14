namespace Spp3;

public class Mutex
{
    private int _lockStatus = 0;

    public void Lock()
    {
        while (Interlocked.CompareExchange(ref _lockStatus, 1, 0) != 0)
        {
            Thread.Sleep(10);
        }
    }

    public void Unlock()
    {
        Interlocked.Exchange(ref _lockStatus, 0);
    }
}