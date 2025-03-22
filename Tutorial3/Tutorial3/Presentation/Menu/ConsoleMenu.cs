using Tutorial3.Application.Items;
using Tutorial3.Presentation.Controllers;

namespace Tutorial3.Presentation.Menu;

public static class ConsoleMenu
{
    public static void Run()
    {
        while (true)
        {
            WriteMenu();
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out var number))
            {
                Console.WriteLine("Please enter a valid number");
                continue;
            }

            switch (number)
            {
                case 1:
                    ShipController.CreateShip();
                    break;
                case 2:
                    ShipController.RemoveShip();
                    break;
                case 3:
                    ContainerController.CreateContainer();
                    break;
                case 4:
                    ContainerController.RemoveContainer();
                    break;
                case 5:
                    ShipController.PlaceContainerOnShip();
                    break;
                case 6:
                    ShipController.RemoveContainerFromShip();
                    break;
                case 7:
                    ShipController.TransferContainerToAnotherShip();
                    break;
                case 8:
                    ContainerController.LoadContainer();
                    break;
                case 9:
                    ContainerController.EmptyCargo();
                    break;
                case 10:
                    Console.WriteLine("Exiting...");
                    return;
            }
        }
    }

    private static void WriteMenu()
    {
        Console.WriteLine(
            $"List of container ships: {(!Inventory.Ships.Any() ? "None" : string.Join(',', Inventory.Ships))}");
        Console.WriteLine(
            $"\nList of containers: {(!Inventory.Containers.Any() ? "None" : string.Join(',', Inventory.Containers))}");

        Console.WriteLine("\nPossible Actions:");
        Console.WriteLine("1. Add container ship");
        if (Inventory.Ships.Any())
        {
            Console.WriteLine("2. Remove a container ship");
            Console.WriteLine("3. Add a container");
        }

        if (Inventory.Containers.Any())
        {
            Console.WriteLine("4. Remove a container");
            Console.WriteLine("5. Place a container on the ship");
            Console.WriteLine("6. Remove a container from the ship");
            Console.WriteLine("7. Transfer container to another ship");
            Console.WriteLine("8. Load Container");
            Console.WriteLine("9. Empty cargo on a container");
        }
        
        Console.WriteLine("10. Exit");
    }
}