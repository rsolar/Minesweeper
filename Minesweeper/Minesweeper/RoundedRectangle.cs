using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Minesweeper
{
    public abstract class RoundedRectangle
    {

        public enum RectangleCorners
        {
            None = 0,
            TopLeft = 1,
            TopRight = 2,
            BottomLeft = 4,
            BottomRight = 8,
            All = TopLeft | TopRight | BottomLeft | BottomRight
        }

        public static GraphicsPath Create(Rectangle r, int radius, RectangleCorners corners = RectangleCorners.All)
        {
            Rectangle tlc = new Rectangle(r.Left, r.Top, Math.Min(2 * radius, r.Width), Math.Min(2 * radius, r.Height));
            Rectangle trc = new Rectangle(r.Right - 2 * radius, r.Top, Math.Min(2 * radius, r.Width), Math.Min(2 * radius, r.Height));
            Rectangle blc = new Rectangle(r.Left, r.Bottom - 2 * radius, Math.Min(2 * radius, r.Width), Math.Min(2 * radius, r.Height));
            Rectangle brc = new Rectangle(r.Right - 2 * radius, r.Bottom - 2 * radius, Math.Min(2 * radius, r.Width), Math.Min(2 * radius, r.Height));

            Point[] n = new Point[] {
                new Point(tlc.Left, tlc.Bottom),
                new Point(tlc.Left, tlc.Top),
                new Point(tlc.Right, tlc.Top),
                new Point(trc.Left, trc.Top),
                new Point(trc.Right, trc.Top),
                new Point(trc.Right, trc.Bottom),
                new Point(brc.Right, brc.Top),
                new Point(brc.Right, brc.Bottom),
                new Point(brc.Left, brc.Bottom),
                new Point(blc.Right, blc.Bottom),
                new Point(blc.Left, blc.Bottom),
                new Point(blc.Left, trc.Top)
            };

            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            if (corners.HasFlag(RectangleCorners.TopLeft))
                p.AddArc(tlc, 180, 90);
            else
                p.AddLines(new Point[] { n[0], n[1], n[2] });
            p.AddLine(n[2], n[3]);

            if (corners.HasFlag(RectangleCorners.TopRight))
                p.AddArc(trc, 270, 90);
            else
                p.AddLines(new Point[] { n[3], n[4], n[5] });
            p.AddLine(n[5], n[6]);

            if (corners.HasFlag(RectangleCorners.BottomRight))
                p.AddArc(brc, 0, 90);
            else
                p.AddLines(new Point[] { n[6], n[7], n[8] });
            p.AddLine(n[8], n[9]);

            if (corners.HasFlag(RectangleCorners.BottomLeft))
                p.AddArc(blc, 90, 90);
            else
                p.AddLines(new Point[] { n[9], n[10], n[11] });
            p.AddLine(n[11], n[0]);

            p.CloseFigure();

            return p;
        }

        public static GraphicsPath Create(int x, int y, int width, int height, int radius, RectangleCorners corners = RectangleCorners.All)
        {
            return Create(new Rectangle(x, y, width, height), radius, corners);
        }

    }
}