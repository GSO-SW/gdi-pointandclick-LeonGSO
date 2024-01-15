namespace gdi_PointAndClick;

using System.Security.Cryptography;

public sealed partial class FrmMain : Form
{
    private readonly List<Drawable> _drawables;

    public FrmMain()
    {
        InitializeComponent();
        var screen = Screen.FromControl(this).WorkingArea;
        ClientSize = new((int)((screen.Width + screen.X) * 0.75), (int)((screen.Height + screen.Y) * 0.70));
        ResizeRedraw = true;

        _drawables = new();
    }

    protected override void OnKeyUp(KeyEventArgs args)
    {
        base.OnKeyUp(args);

        if (args.KeyCode is not Keys.Escape) return;

        _drawables.Clear();
        Update();
    }

    protected override void OnMouseClick(MouseEventArgs args)
    {
        base.OnMouseClick(args);

    }

    protected override void OnPaint(PaintEventArgs args)
    {
        base.OnPaint(args);

        foreach (var drawable in _drawables)
        {
            args.Graphics.FillRectangle(drawable.Brush, drawable.Rectangle);
        }
    }

    private static Drawable GetRandomDrawable(int maxWidth, int maxHeight, bool strongRandom)
    {
        int x, y, width, height;



        return new Drawable
        {
            Brush = new SolidBrush(GetRandomColor(strongRandom)),
            Rectangle = new Rectangle()
        };
    }

    private static Color GetRandomColor(bool strongRandom)
    {
        Span<byte> rgb = stackalloc byte[3];

        if (strongRandom) RandomNumberGenerator.Fill(rgb);
        else Random.Shared.NextBytes(rgb);

        return Color.FromArgb(rgb[0], rgb[1], rgb[2]);
    }
}