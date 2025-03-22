using Tutorial3.Application.Exceptions;
using Tutorial3.Application.Interfaces;

namespace Tutorial3.Domain.Containers;

public class RefrigeratedContainer : BaseContainer, IHazardNotifier
{
    private readonly double _temperature;
    private readonly string? _product;

    public RefrigeratedContainer(
        double temperature, 
        int maxPayload, 
        string product, 
        int tareWeight,
        int? productPayload = null
        ) : base(tareWeight)
    {
        _temperature = temperature;
        ProductValidation(product);
        _product = product;
        MaxPayload = maxPayload;
        MassCargo = productPayload ?? 0;
    }

    private void ProductValidation(string product)
    {
        if (!Products.Food.Products.ContainsKey(product))
            throw new InvalidDataException("Invalid product name");
        
        if (_temperature < Products.Food.Products[product])
            throw new InvalidDataException("Invalid temperature");
    }

    public override void LoadContainer(int payload)
    {
        if (MaxPayload < (MassCargo + payload))
            throw new OverfillException("Invalid payload");
        
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
    
    public override void PrintInfo()
    {
        base.PrintInfo();
        Console.WriteLine($"Product: {_product}, Temperature: {_temperature}°C");
    }
}