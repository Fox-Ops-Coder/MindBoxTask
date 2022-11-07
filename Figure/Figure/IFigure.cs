namespace Figure
{
    public interface IFigure : IArea
    {
        bool Equal(IFigure figure);
    }
}