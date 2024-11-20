public abstract class SubwayDecorator : ISubwayComponent
{
    protected ISubwayComponent _component;

    public int Size
    {
        get => _component.Size;
        set => _component.Size = value;
    }

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