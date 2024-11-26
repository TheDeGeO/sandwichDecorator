public class AvocadoDecorator : SubwayDecorator
{
    public AvocadoDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Aguacate{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + (Size == 15 ? 1.5m : 2.5m) * _count;
    }
}

public class ExtraProteinDecorator : SubwayDecorator
{
    public ExtraProteinDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Doble proteína{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + (Size == 15 ? 4.5m : 8.0m) * _count;
    }
}

public class MushroomDecorator : SubwayDecorator
{
    public MushroomDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Hongos{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + (Size == 15 ? 0.85m : 1.45m) * _count;
    }
}

public class DrinkDecorator : SubwayDecorator
{
    public DrinkDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Refresco{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 1.0m * _count;
    }
}

public class SoupDecorator : SubwayDecorator
{
    public SoupDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Sopa{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 4.2m * _count;
    }
}

public class DessertDecorator : SubwayDecorator
{
    public DessertDecorator(ISubwayComponent component) : base(component) { }

    public override string GetDescription()
    {
        return $"{_component.GetDescription()} + Postre{(_count > 1 ? $" x{_count}" : "")}";
    }

    public override decimal GetCost()
    {
        return _component.GetCost() + 3.5m * _count;
    }
} 