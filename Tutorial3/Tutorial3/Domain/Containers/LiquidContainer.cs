using Tutorial3.Application.Exceptions;
using Tutorial3.Application.Interfaces;

namespace Tutorial3.Domain.Containers;

public class LiquidContainer : BaseContainer, IHazardNotifier
{
    public LiquidContainer(int maxPayload, bool isHazardous, int tareWeight, int? payload = null) : base(tareWeight)
    {
        MaxPayload = maxPayload;
        IsHazardous = isHazardous;
        MassCargo = payload ?? 0;
    }

    public override void LoadContainer(int payload)
    {
        if (IsHazardous)
        {
            if ((MassCargo + payload) > MaxPayload*0.2)
                throw new DangerousOperationException("Liquid container is over the max payload");
        }
        else if ((MassCargo + payload) > MaxPayload*0.9)
            throw new DangerousOperationException("Liquid container is over the max payload");
        
        MassCargo += payload;
    }

    public override void EmptyingCargo()
    {
        MassCargo = 0;
    }

    public void SendNotification()
    {
        Console.WriteLine($"[Hazard Warning] Potential danger detected in container: {SerialNumber}");
    }
}