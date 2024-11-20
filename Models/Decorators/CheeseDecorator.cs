public class CheeseDecorator : SubwayDecorator
{
    public CheeseDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Cheese";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 1.00m;
    }
} 