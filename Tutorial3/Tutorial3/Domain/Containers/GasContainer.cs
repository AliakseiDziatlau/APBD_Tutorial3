using Tutorial3.Application.Exceptions;
using Tutorial3.Application.Interfaces;

namespace Tutorial3.Domain.Containers;

public class GasContainer : BaseContainer, IHazardNotifier
{
    public double Pressure { get; set; }
    public GasContainer(double pressure, int maxPayload, int tareWeight) : base(tareWeight)
    {
        Pressure = pressure;
        MaxPayload = maxPayload;
        IsHazardous = true;
    }

    public override void LoadContainer(int payload)
    {
        if ((MassCargo + payload) > MaxPayload)
            throw new OverfillException("Gas container is over the max payload");
    }

    public override void EmptyingCargo()
    {
        MassCargo = (int)(MassCargo * 0.05);
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Hazard Warning] Potential danger detected in container: {SerialNumber}");
    }
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Pressure: {Pressure} atm");
    }
}