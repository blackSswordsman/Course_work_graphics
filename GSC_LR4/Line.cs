using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_LR4
{
    class Line : IShape
    {
        public float RotationAngle { get; set; }
        public PointF ReflectionPoint { get; set; }
        public PointF ScalePoint { get; set; }
        public float ScaleFactor { get; set; }
        public  bool TMO { get; set; }
        public PointF TMOCenter { get; set; }
        public int LineWidth { get; set; }
        public Color LineColor { get; set; }
        public PointF Point1 { get; set; }
        public PointF Point2 { get; set; }
        public List<PointF> points { get; set; }
        public PointF center { get; set; }

        public Line(Color color, PointF point1, PointF point2)
        {
            LineWidth = 3; LineColor=color; Point1 = point1; Point2 = point2;
        }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddLine(Point1, Point2);
            if (RotationAngle != 0 )
            {
                center = Center();
                var mx = new Matrix();
                mx.RotateAt(RotationAngle, center);
                path.Transform(mx);
            }
            return path;
        }
        public bool Selected(PointF p)
        {
            float distance1 = (float)Math.Sqrt(Math.Pow(Point1.X - p.X, 2) + Math.Pow(Point1.Y - p.Y, 2));
            float distance2 = (float)Math.Sqrt(Math.Pow(Point2.X - p.X, 2) + Math.Pow(Point2.Y - p.Y, 2));
            float distance3 = (float)Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
            return distance1 + distance2 - distance3 < 1f;
        }
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawPath(pen, path);
        }
        public void Move(PointF d)
        {
            Point1 = new PointF(Point1.X + d.X, Point1.Y + d.Y);
            Point2 = new PointF(Point2.X + d.X, Point2.Y + d.Y);
        }
        public void Reflect(PointF r)
        {

        }
        public PointF Min()
        {
            return new PointF();
        }
        public PointF Max()
        {
            return new PointF();
        }
        public PointF Center ()
        {
            center = new PointF((Point1.X + Point2.X) / 2, (Point1.Y + Point2.Y) / 2);
            return center;
        }

        public void DrawSelection(Graphics e)
        {
            RectangleF bounds = GetPath().GetBounds();
            Pen pen = new Pen(Color.Gray)
            {
                DashStyle = DashStyle.Dash
            };
            e.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }
    }
}
