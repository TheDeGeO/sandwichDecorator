public class BasicSubway : ISubwayComponent
{
    private readonly string _type;
    private readonly decimal _baseCost15;
    private readonly decimal _baseCost30;
    
    public int Size { get; set; }

    public BasicSubway(string type, decimal cost15, decimal cost30, int size = 15)
    {
        _type = type;
        _baseCost15 = cost15;
        _baseCost30 = cost30;
        Size = size;
    }

    public string GetDescription()
    {
        return $"{_type} de {Size} cm";
    }

    public decimal GetCost()
    {
        return Size == 15 ? _baseCost15 : _baseCost30;
    }
} 