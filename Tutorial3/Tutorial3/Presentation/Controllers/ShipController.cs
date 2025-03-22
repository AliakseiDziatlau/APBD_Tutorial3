using Tutorial3.Application.Services;
using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Presentation.Controllers;

public static class ShipController
{
    public static void CreateShip()
    {
        var maxSpeed = InputService.ReadInt("Input maxSpeed for the ship: ", "maxSpeed is invalid");
        var maxContainers = InputService.ReadInt("Input maxContainers for the ship: ", "maxContainers is invalid");
        var maxWeight = InputService.ReadInt("Input maxWeight for the ship: ", "maxWeight is invalid");

        ShipService.CreateShip(maxSpeed, maxContainers, maxWeight);
    }

    public static void RemoveShip()
    {
        var id = InputService.ReadInt("Input id for the ship", "id for the ship is invalid");
        ShipService.RemoveShip(id);
    }

    public static void PlaceContainerOnShip()
    {
        var idShip = InputService.ReadInt("Input id for the ship", "id for the ship is invalid");
        var idContainer = InputService.ReadString("Input an id of the container:");
        ShipService.PlaceContainerOnShip(idShip, idContainer);
    }

    public static void RemoveContainerFromShip()
    {
        var idShip = InputService.ReadInt("Input id for the ship", "id for the ship is invalid");
        var idContainer = InputService.ReadString("Input an id of the container:");
        ShipService.RemoveContainerFromShip(idShip, idContainer);
    }

    public static void TransferContainerToAnotherShip()
    {
        var idOriginalShip = InputService.ReadInt("Input id for the ship", "id for the ship is invalid");
        var idContainer = InputService.ReadString("Input an id of the container:");
        var idNewShip = InputService.ReadInt("Input id for the ship", "id for the ship is invalid");
        ShipService.TransferContainerToAnotherShip(idOriginalShip, idContainer, idNewShip);
    }
}