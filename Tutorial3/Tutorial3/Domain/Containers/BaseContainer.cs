using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Domain.Containers;

public abstract class BaseContainer
{
    public int MassCargo { get; set; }
    public int Height { get; set; }
    public int TareWeight { get; set; }
    public int Depth { get; set; }
    public string SerialNumber { get; set; }
    public int MaxPayload { get; set; }
    public bool IsHazardous { get; set; }
    
    public abstract void EmptyingCargo();
    public abstract void LoadContainer(int payload);

    protected BaseContainer(int tareWeight)
    {
        TareWeight = tareWeight;
        SerialNumber = ContainerIdGeneratorService.GetInstance().Increment(this.GetType().Name);
    }
    
    public virtual void PrintInfo()
    {
        Console.WriteLine($"Container [{SerialNumber}] - Max Payload: {MaxPayload} kg, Current Load: {MassCargo} kg");
    }

    public override string ToString()
    {
        return $"Container {SerialNumber} (massCargo={MassCargo} tareWeight={TareWeight} maxPayload={MaxPayload})";
    }
}