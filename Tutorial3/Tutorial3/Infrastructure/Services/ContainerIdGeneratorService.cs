namespace Tutorial3.Infrastructure.Services;

public sealed class ContainerIdGeneratorService
{
    private int _count = 0;
    private ContainerIdGeneratorService() { }
    private static ContainerIdGeneratorService? _instance;
    private static readonly object Lock = new();

    public static ContainerIdGeneratorService? GetInstance()
    {
        lock (Lock)
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    _instance = new ContainerIdGeneratorService();
                }
            }
            return _instance;
        }
    }

    public string Increment(string contType)
    {
        return $"KON-{contType[0]}-{++_count}";
    }
}