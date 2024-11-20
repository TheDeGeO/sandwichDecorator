public abstract class SubwayDecorator : ISubwayComponent
{
    protected ISubwayComponent _component;

    public SubwayDecorator(ISubwayComponent component)
    {
        _component = component;
    }

    public virtual string GetDescription()
    {
        return _component.GetDescription();
    }

    public virtual decimal GetCost()
    {
        return _component.GetCost();
    }
} 