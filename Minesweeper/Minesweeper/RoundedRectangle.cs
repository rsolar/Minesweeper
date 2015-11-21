using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Minesweeper {
  public abstract class RoundedRectangle {
    public enum RectangleCorners {
      None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,
      All = TopLeft | TopRight | BottomLeft | BottomRight
    }
    
    public static GraphicsPath Create(Rectangle r, int radius, RectangleCorners corners) {
      Rectangle tlc = new Rectangle(r.Left, r.Top, Math.Min(2 * radius, r.Width), Math.Min(2 * radius, r.Height));
      Rectangle trc = tlc;
      trc.X = r.Right - 2 * radius;
      Rectangle blc = tlc;
      blc.Y = r.Bottom - 2 * radius;
      Rectangle brc = blc;
      brc.X = r.Right - 2 * radius;

      Point[] n = new Point[] {
        new Point(tlc.Left, tlc.Bottom), tlc.Location, 
        new Point(tlc.Right, tlc.Top), trc.Location, 
        new Point(trc.Right, trc.Top), 
        new Point(trc.Right, trc.Bottom),
        new Point(brc.Right, brc.Top), 
        new Point(brc.Right, brc.Bottom), 
        new Point(brc.Left, brc.Bottom), 
        new Point(blc.Right, blc.Bottom), 
        new Point(blc.Left, blc.Bottom), blc.Location
    };

      GraphicsPath p = new GraphicsPath();
      p.StartFigure();

      //Top Left Corner
      if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft) {
        p.AddArc(tlc, 180, 90);
      } else {
        p.AddLines(new Point[] { n[0], n[1], n[2] });
      }

      //Top Edge
      p.AddLine(n[2], n[3]);

      //Top Right Corner
      if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight) {
        p.AddArc(trc, 270, 90);
      } else {
        p.AddLines(new Point[] { n[3], n[4], n[5] });
      }

      //Right Edge
      p.AddLine(n[5], n[6]);

      //Bottom Right Corner
      if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight) {
        p.AddArc(brc, 0, 90);
      } else {
        p.AddLines(new Point[] { n[6], n[7], n[8] });
      }

      //Bottom Edge
      p.AddLine(n[8], n[9]);

      //Bottom Left Corner
      if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft) {
        p.AddArc(blc, 90, 90);
      } else {
        p.AddLines(new Point[] { n[9], n[10], n[11] });
      }

      //Left Edge
      p.AddLine(n[11], n[0]);

      p.CloseFigure();
      return p;
    }

    public static GraphicsPath Create(Rectangle r, int radius) {
      return Create(r, radius, RectangleCorners.All);
    }

    public static GraphicsPath Create(int x, int y, int width, int height, int radius) {
      return Create(new Rectangle(x, y, width, height), radius, RectangleCorners.All);
    }

    public static GraphicsPath Create(int x, int y, int width, int height, int radius, RectangleCorners corners) {
      return Create(new Rectangle(x, y, width, height), radius, corners);
    }

  }
}