using Tutorial3.Application.Items;
using Tutorial3.Domain.Containers;
using Tutorial3.Domain.Products;
using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Application.Services;

public static class ContainerService
{
    public static void CreateContainer(string? containerType, int? maxPayload, int? tareWeight)
    {
        if (containerType is not ("G" or "L" or "R"))
        {
            Console.WriteLine("Invalid container type!");
            return;
        }
        
        if (!InputService.ValidateNotNull(maxPayload, tareWeight)) return;

        BaseContainer? container = containerType switch
        {
            "G" => CreateGasContainer(maxPayload!.Value, tareWeight!.Value),
            "L" => CreateLiquidContainer(maxPayload!.Value, tareWeight!.Value),
            "R" => CreateRefrigeratedContainer(maxPayload!.Value, tareWeight!.Value),
            _ => null
        };

        if (container == null) return;
        Inventory.Containers.Add(container);
    }
    
    private static GasContainer? CreateGasContainer(int maxPayload, int tareWeight)
    {
        var pressure = InputService.ReadDouble("Input pressure: ", "Invalid pressure!");
        return pressure == null ? null : new GasContainer(pressure.Value, maxPayload, tareWeight);
    }

    private static LiquidContainer? CreateLiquidContainer(int maxPayload, int tareWeight)
    {
        string? input = InputService.ReadString("Is cargo hazardous? (0 = no, 1 = yes):");
        if (input != "0" && input != "1")
        {
            Console.WriteLine("Invalid input! Use 0 or 1.");
            return null;
        }

        bool isHazardous = input == "1";
        return new LiquidContainer(maxPayload, isHazardous, tareWeight);
    }

    private static RefrigeratedContainer? CreateRefrigeratedContainer(int maxPayload, int tareWeight)
    {
        var temperature = InputService.ReadDouble("Input temperature: ", "Invalid temperature!");
        var product = InputService.ReadString("Input product name: ");
        
        if (!InputService.ValidateNotNull(temperature, product)) return null;
        if (!Food.Products.ContainsKey(product!))
        {
            Console.WriteLine("Invalid product!");
            return null;
        }

        return new RefrigeratedContainer(temperature!.Value, maxPayload, product!, tareWeight);
    }

    public static void RemoveContainer(string? id)
    {
        var container = Inventory.Containers.Find(c => c.SerialNumber == id);
        if (container == null)
        {
            Console.WriteLine("Container not found!");
            return;
        }
        Inventory.Containers.Remove(container);
        Console.WriteLine("Container removed.");
    }

    public static void LoadContainer(string? id, int? mass)
    {
        var container = Inventory.Containers.Find(c => c.SerialNumber == id);
        if (container == null)
        {
            Console.WriteLine("Container not found!");
            return;
        }
        if (mass == null) return;

        container.LoadContainer(mass.Value);
        Console.WriteLine("Cargo loaded.");
    }

    public static void EmptyCargo(string? id)
    {
        var container = Inventory.Containers.Find(c => c.SerialNumber == id);
        if (container == null)
        {
            Console.WriteLine("Container not found!");
            return;
        }

        container.EmptyingCargo();
        Console.WriteLine("Container emptied.");
    }
}