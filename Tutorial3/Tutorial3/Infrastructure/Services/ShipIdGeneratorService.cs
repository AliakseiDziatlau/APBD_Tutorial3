namespace Tutorial3.Infrastructure.Services;

public class ShipIdGeneratorService
{
    private int _count = 0;
    private ShipIdGeneratorService() { }
    private static ShipIdGeneratorService? _instance;
    private static readonly object Lock = new();

    public static ShipIdGeneratorService? GetInstance()
    {
        lock (Lock)
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    _instance = new ShipIdGeneratorService();
                }
            }
            return _instance;
        }
    }

    public int Increment()
    {
        return ++_count;
    }

    public void Decrement()
    {
        _count--;
    }
}