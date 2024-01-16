namespace gdi_PointAndClick;

using System.Security.Cryptography;

public sealed partial class FrmMain : Form
{
    private readonly List<Drawable> _drawables;

    private int movingIndex;
    private int selectedIndex;

    public FrmMain()
    {
        InitializeComponent();

        var screen = Screen.FromControl(this).WorkingArea;
        ClientSize = new((int)((screen.Width + screen.X) * 0.75), (int)((screen.Height + screen.Y) * 0.70));
        ResizeRedraw = true;

        _drawables = new();
        movingIndex = -1;
        selectedIndex = -1;
    }

    protected override void OnKeyDown(KeyEventArgs args)
    {
        base.OnKeyDown(args);

        if (args.KeyCode is Keys.Escape) _drawables.Clear();

        if (selectedIndex is not -1)
        {
            var rectangle = _drawables[selectedIndex].Rectangle;

            if (Win32.IsKeyPressed(Keys.Left)) rectangle.X -= 2;
            if (Win32.IsKeyPressed(Keys.Right)) rectangle.X += 2;
            if (Win32.IsKeyPressed(Keys.Down)) rectangle.Y += 2;
            if (Win32.IsKeyPressed(Keys.Up)) rectangle.Y -= 2;

            _drawables[selectedIndex] = _drawables[selectedIndex] with
            {
                Rectangle = KeepInBounds(rectangle)
            };
        }

        Refresh();
    }

    protected override void OnMouseClick(MouseEventArgs args)
    {
        base.OnMouseClick(args);

        switch (args.Button)
        {
            case MouseButtons.Left:
                selectedIndex = _drawables.FindLastIndex(x => x.Rectangle.Contains(args.Location));

                if (selectedIndex is not -1) return;

                _drawables.Add(GetRandomDrawable(args.Location, true, false));
                break;

            case MouseButtons.Right:
                var index = _drawables.FindLastIndex(x => x.Rectangle.Contains(args.Location));

                if (index is -1) return;
                
                _drawables.RemoveAt(index);
                break;

            default: return;
        }

        Refresh();
    }

    protected override void OnMouseMove(MouseEventArgs args)
    {
        base.OnMouseMove(args);

        if (args.Button is not MouseButtons.Left) return;

        if (movingIndex is -1)
        {
            movingIndex = _drawables.FindLastIndex(x => x.Rectangle.Contains(args.Location));

            if (movingIndex is -1) return;
        }

        var rectangle = _drawables[movingIndex].Rectangle;

        _drawables[movingIndex] = _drawables[movingIndex] with
        {
            Rectangle = KeepInBounds(rectangle with
            {
                X = args.X - rectangle.Width / 2,
                Y = args.Y - rectangle.Height / 2
            })
        };

        Refresh();
    }

    protected override void OnMouseUp(MouseEventArgs args)
    {
        base.OnMouseUp(args);

        if (args.Button is not MouseButtons.Left) return;

        movingIndex = -1;
    }

    protected override void OnPaint(PaintEventArgs args)
    {
        base.OnPaint(args);
        
        foreach (var drawable in _drawables)
        {
            args.Graphics.FillRectangle(drawable.Brush, drawable.Rectangle);

            foreach (var intersect in _drawables
                .Select(x => new Drawable(x.Rectangle == drawable.Rectangle
                ? Rectangle.Empty : Rectangle.Intersect(x.Rectangle, drawable.Rectangle),
                x.Brush)))
            {
                if (intersect.Rectangle.IsEmpty) continue;
                
                args.Graphics.FillRectangle(
                    new SolidBrush(GetOverlapColor(drawable.Brush.Color, intersect.Brush.Color)),
                    intersect.Rectangle);
            }
        }
    }

    private Rectangle KeepInBounds(Rectangle rectangle)
    {
        var x = rectangle.X;
        var y = rectangle.Y;

        x = x + rectangle.Width > ClientSize.Width ? ClientSize.Width - rectangle.Width : x;
        y = y + rectangle.Height > ClientSize.Height ? ClientSize.Height - rectangle.Height : y;

        return rectangle with
        {
            X = x < 0 ? 0 : x,
            Y = y < 0 ? 0 : y
        };
    }

    private Drawable GetRandomDrawable(Point midPoint, bool shouldBeSquare, bool strongRandom)
    {
        int width, height;

        if (strongRandom)
        {
            width = RandomNumberGenerator.GetInt32(1, ClientSize.Width);
            height = shouldBeSquare ? width : RandomNumberGenerator.GetInt32(1, ClientSize.Height);
        }
        else
        {
            width = Random.Shared.Next(1, ClientSize.Width);
            height = shouldBeSquare ? width : Random.Shared.Next(1, ClientSize.Height);
        }

        var x = midPoint.X - width / 2;
        var y = midPoint.Y - height / 2;

        if (x < 0) x = 0;
        if (y < 0) y = 0;

        width = x + width > ClientSize.Width ? ClientSize.Width - x : width;
        height = y + height > ClientSize.Height ? ClientSize.Height - y : height;

        return new Drawable
        {
            Brush = new SolidBrush(GetRandomColor(strongRandom)),
            Rectangle = new Rectangle
            {
                X = x,
                Y = y,
                Width = shouldBeSquare
                ? width > height
                ? height : width
                : width,
                Height = height
            }
        };
    }

    private static Color GetRandomColor(bool strongRandom)
    {
        Span<byte> rgb = stackalloc byte[3];

        if (strongRandom) RandomNumberGenerator.Fill(rgb);
        else Random.Shared.NextBytes(rgb);

        return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
    }

    private static Color GetOverlapColor(Color first, Color second, bool ignoreAlpha = true)
    {
        const float percentage = 0.5f;

        return Color.FromArgb(
            ignoreAlpha ? byte.MaxValue : (int)(first.A * percentage + second.A * percentage),
            (int)(first.R * percentage + second.R * percentage),
            (int)(first.G * percentage + second.G * percentage),
            (int)(first.B * percentage + second.B * percentage));
    }
}