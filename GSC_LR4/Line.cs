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

        public Line(Color color, PointF point1, PointF point2)
        {
            LineWidth = 3; LineColor=color; Point1 = point1; Point2 = point2;
        }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddLine(Point1, Point2);
            return path;
        }
        public bool Selected(PointF p)
        {
            var result = false;
            using (var path = GetPath())
            using (var pen = new Pen(LineColor, LineWidth + 2))
                result = path.IsOutlineVisible(p, pen);
            return result;
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
        public PointF center { get; set; }

        public void DrawSelection(Graphics e)
        {

        }
    }
}
