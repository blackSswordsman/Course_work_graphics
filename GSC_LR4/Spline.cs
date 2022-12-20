using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSC_LR4
{
    class Spline : IShape
    {
        public float RotationAngle { get; set; }
        public PointF ReflectionPoint { get; set; }
        public PointF ScalePoint { get; set; }
        public float ScaleFactor { get; set; }
        public bool TMO { get; set; }
        public PointF TMOCenter { get; set; }
        public int LineWidth { get; set; }
        public Color LineColor { get; set; }
        public PointF Point1 { get; set; }
        public PointF Point2 { get; set; }
        public List<PointF> Vertexes { get; set; }
        public List <PointF> SplineCount { get; set; }
        public PointF center { get; set; }

        public Spline(Color color, List<PointF> count)
        {
            LineWidth = 3; LineColor = color; SplineCount = count; Vertexes = new List<PointF>();
            AddSpline(SplineCount);
        }
        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            path.AddCurve(Vertexes.ToArray());
            if (RotationAngle != 0)
            {
                center = Center();
                var mx = new Matrix();
                mx.RotateAt(RotationAngle, center);
                path.Transform(mx);
            }
            return path;
        }
        private void AddSpline( List<PointF> P)
        {
            // Матрица вещественных коэффициентов L
            PointF[] L = new PointF[4];

            // Касательные векторы
            PointF vector1 = P[0];
            PointF vector2 = P[0];

            const double dt = 0.04;
            double t = 0;
            double xt, yt;

            PointF Ppred = P[0], Pt = P[0];

            vector1.X = 4 * (P[1].X - P[0].X);
            vector1.Y = 4 * (P[1].Y - P[0].Y);
            vector2.X = 4 * (P[3].X - P[2].X);
            vector2.Y = 4 * (P[3].Y - P[2].Y);

            // Расчет коэффициентов полинома
            L[0].X = 2 * P[0].X - 2 * P[2].X + vector1.X + vector2.X; // Ax
            L[0].Y = 2 * P[0].Y - 2 * P[2].Y + vector1.Y + vector2.Y; // Ay
            L[1].X = -3 * P[0].X + 3 * P[2].X - 2 * vector1.X - vector2.X; // Bx
            L[1].Y = -3 * P[0].Y + 3 * P[2].Y - 2 * vector1.Y - vector2.Y; // By
            L[2].X = vector1.X; // Cx
            L[2].Y = vector1.Y; // Cy
            L[3].X = P[0].X; // Dx
            L[3].Y = P[0].Y; // Dy

            while (t < 1 + dt / 2)
            {
                xt = ((L[0].X * t + L[1].X) * t + L[2].X) * t + L[3].X;
                yt = ((L[0].Y * t + L[1].Y) * t + L[2].Y) * t + L[3].Y;

                Pt.X = (int)Math.Round(xt);
                Pt.Y = (int)Math.Round(yt);
                Vertexes.Add(Pt);
                //e.DrawLine(drPen, Ppred, Pt);

                Ppred = Pt;
                t += dt;
            }
        }
        public bool Selected(PointF point)
        {
            int k;
            PointF Pi, Pk;
            int n = Vertexes.Count;
            for (int i = 0; i < n; i++)
            {
                if (i < n - 1) k = i + 1; else k = 0;
                Pi = Vertexes[i]; Pk = Vertexes[k];
                if ((Pi.Y <= point.Y) & (Pk.Y >= point.Y) | (Pi.Y >= point.Y) & (Pk.Y <= point.Y))
                {
                    float x;
                    if (Pi.Y == Pk.Y) x = Pi.X;
                    else x = (Pk.X - Pi.X) * (point.Y - Pi.Y) / (Pk.Y - Pi.Y) + Pi.X;
                    //допускается отступ от координаты X на 5 пикселей в любую сторону
                    if (x >= point.X - 5 & x <= point.X + 5) return true;
                }
            }
            return false;
        }
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
            using (var pen = new Pen(LineColor, LineWidth))
                g.DrawPath(pen, path);
        }
        public void Move(PointF d)
        {
            PointF temp = new PointF();
            for (int i = 0; i < Vertexes.Count; i++)
            {
                temp.X = Vertexes[i].X + d.X;
                temp.Y = Vertexes[i].Y + d.Y;
                Vertexes[i] = temp;
            }
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
        public PointF Center()
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

