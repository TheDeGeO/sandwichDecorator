public class BasicSubway : ISubwayComponent
{
    public string GetDescription()
    {
        return "Basic Subway";
    }

    public decimal GetCost()
    {
        return 5.00m;
    }
} 