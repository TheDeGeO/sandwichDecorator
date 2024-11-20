public interface ISubwayComponent
{
    string GetDescription();
    decimal GetCost();
    int Size { get; set; }
} 