namespace gdi_PointAndClick;

public sealed record Drawable
{
    public Rectangle Rectangle { get; init; }

    public Brush Brush { get; init; }

    public Drawable() : this(Rectangle.Empty, Brushes.Black) { }

    public Drawable(Rectangle rectangle, Brush brush)
    {
        Rectangle = rectangle;
        Brush = brush;
    }
}