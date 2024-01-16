namespace gdi_PointAndClick;

public sealed record Drawable
{
    public Rectangle Rectangle { get; init; }

    public SolidBrush Brush { get; init; }

    public Drawable() : this(Rectangle.Empty, new SolidBrush(Color.Black)) { }

    public Drawable(Rectangle rectangle, SolidBrush brush)
    {
        Rectangle = rectangle;
        Brush = brush;
    }
}