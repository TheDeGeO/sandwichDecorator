public class TomatoDecorator : SubwayDecorator
{
    public TomatoDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Tomato";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 0.50m;
    }
} 