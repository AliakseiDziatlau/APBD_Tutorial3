using Tutorial3.Application.Items;
using Tutorial3.Domain.Ships;
using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Application.Services;

public static class ShipService
{
    public static void CreateShip(int? maxSpeed, int? maxContainers, int? maxWeight)
    {
        if (!InputService.ValidateNotNull(maxSpeed, maxContainers, maxWeight)) return;

        var ship = new Ship(maxSpeed!.Value, maxContainers!.Value, maxWeight!.Value);
        Inventory.Ships.Add(ship);
    }

    public static void RemoveShip(int? id)
    {
        var shipToRemove = Inventory.Ships.Find(ship => ship.Id == id);

        if (shipToRemove == null)
        {
            Console.WriteLine("The ship you want to remove was not found");
            return;
        }
        
        Inventory.Ships.Remove(shipToRemove);
        ShipIdGeneratorService.GetInstance()!.Decrement();
    }

    public static void PlaceContainerOnShip(int? idShip, string? idContainer)
    {
        var shipToPlace = Inventory.Ships.Find(ship => ship.Id == idShip);
        var containerToPlace = Inventory.Containers.Find(cont => cont.SerialNumber == idContainer);
        
        if (InputService.ValidateNotNull(idContainer, shipToPlace, containerToPlace)) return;

        shipToPlace?.LoadContainer(containerToPlace!);
    }

    public static void RemoveContainerFromShip(int? idShip, string? idContainer)
    {
        var shipToRemove = Inventory.Ships.Find(ship => ship.Id == idShip);
        var containerToRemove = Inventory.Containers.Find(cont => cont.SerialNumber == idContainer);
        
        if (InputService.ValidateNotNull(idContainer, shipToRemove, containerToRemove)) return;

        shipToRemove?.RemoveContainer(idContainer!);
    }

    public static void TransferContainerToAnotherShip(int? idOriginalShip, string? idContainer, int? idNewShip)
    {
        var originalShip = Inventory.Ships.Find(ship => ship.Id == idOriginalShip);
        var cont = originalShip?.Containers.Find(cont => cont.SerialNumber == idContainer);
        var newShip = Inventory.Ships.Find(ship => ship.Id == idNewShip);

        if (InputService.ValidateNotNull(idContainer, originalShip, cont, newShip)) return;
        
        originalShip?.TransferContainerTo(newShip!, idContainer!);
    }
    
}