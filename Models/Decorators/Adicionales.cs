public class AvocadoDecorator : SubwayDecorator
{
    public AvocadoDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Aguacate";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + (Size == 15 ? 1.5m : 2.5m);
    }
}

public class ExtraProteinDecorator : SubwayDecorator
{
    public ExtraProteinDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Doble proteína";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + (Size == 15 ? 4.5m : 8.0m);
    }
}

public class SoupDecorator : SubwayDecorator
{
    public SoupDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Sopa";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 4.2m;
    }
} 