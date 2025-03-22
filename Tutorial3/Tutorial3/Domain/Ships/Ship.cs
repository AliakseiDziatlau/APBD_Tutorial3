using Tutorial3.Application.Exceptions;
using Tutorial3.Domain.Containers;
using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Domain.Ships;

public class Ship
{
    public List<BaseContainer> Containers { get; }
    private readonly int _maxSpeed;
    private readonly int _maxContainersNumber;
    private readonly int _maxWeight;
    public int Id { get; }

    public Ship(int maxSpeed, int maxContainersNumber, int maxWeight)
    {
        Containers = new List<BaseContainer>();
        _maxSpeed = maxSpeed;
        _maxContainersNumber = maxContainersNumber;
        _maxWeight = maxWeight;
        Id = ShipIdGeneratorService.GetInstance().Increment();
    }

    public override string ToString()
    {
        return $"Ship {Id} (speed={_maxSpeed}, maxContainerNum={Containers.Count}, maxWeight={_maxWeight})";
    }

    public void LoadContainer(BaseContainer container)
    {
        if (Containers.Count >= _maxContainersNumber)
            throw new OverfillException("Ship cannot hold more containers!");

        int totalWeight = Containers.Sum(c => c.MassCargo + c.TareWeight) + container.MassCargo + container.TareWeight;
        if (totalWeight > _maxWeight)
            throw new OverfillException("Ship exceeds maximum weight!");

        Containers.Add(container);
    }

    public void LoadContainers(IEnumerable<BaseContainer> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container == null) throw new ContainerNotFound($"Container {serialNumber} not found!");
        Containers.Remove(container);
    }

    public void TransferContainerTo(Ship targetShip, string serialNumber)
    {
        var container = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (container != null)
        {
            RemoveContainer(serialNumber);
            targetShip.LoadContainer(container);
        }
        else
        {
            throw new ContainerNotFound($"Container {serialNumber} not found for transfer!");
        }
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship Info: Max Speed {_maxSpeed}, Max Containers {_maxContainersNumber}, Max Weight {_maxWeight}");
        Console.WriteLine("Current Containers:");
        foreach (var container in Containers)
        {
            Console.WriteLine($"- {container.SerialNumber}, Mass: {container.MassCargo}kg");
        }
    }
}