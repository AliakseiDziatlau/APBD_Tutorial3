namespace Tutorial3.Domain.Products;

public static class Food
{
    public static Dictionary<string, double> Products { get; } = new Dictionary<string, double>
    {
        ["Bananas"] = 13.3,
        ["Chocolate"] = 18,
        ["Fish"] = 2,
        ["Meat"] = 15,
        ["Ice Cream"] = -18,
        ["Frozen Pizza"] = 30,
        ["Cheese"] = 7.2,
        ["Sausages"] = 5,
        ["Butter"] = 20.5,
        ["Eggs"] = 19,
    };
}