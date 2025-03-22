using Tutorial3.Domain.Containers;
using Tutorial3.Domain.Ships;

namespace Tutorial3.Application.Items;

public static class Inventory
{
    public static List<Ship> Ships = new List<Ship>();
    public static List<BaseContainer> Containers = new List<BaseContainer>();
}