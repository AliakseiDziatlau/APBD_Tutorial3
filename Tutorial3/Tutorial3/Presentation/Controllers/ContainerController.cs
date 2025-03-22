using Tutorial3.Application.Services;
using Tutorial3.Infrastructure.Services;

namespace Tutorial3.Presentation.Controllers;

public static class ContainerController
{
    public static void CreateContainer()
    {
        var containerType = InputService.ReadString("Input type of container (G - Gas / L - Liquid / R - Refrigerated):");
        var maxPayload = InputService.ReadInt("Input maxPayload: ", "Invalid payload!");
        var tareWeight = InputService.ReadInt("Input tareWeight: ", "Invalid tareWeight!");
        ContainerService.CreateContainer(containerType, maxPayload, tareWeight);
    }

    public static void RemoveContainer()
    {
        var id = InputService.ReadString("Input container ID to remove:");
        ContainerService.RemoveContainer(id);
    }

    public static void LoadContainer()
    {
        var id = InputService.ReadString("Input container ID to load:");
        var mass = InputService.ReadInt("Input cargo mass to load:", "Invalid mass!");
        ContainerService.LoadContainer(id, mass);
    }

    public static void EmptyCargo()
    {
        var id = InputService.ReadString("Input container ID to empty:");
        ContainerService.EmptyCargo(id);
    }
}