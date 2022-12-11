using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSC_LR4
{
    class Rhombus : IShape
    {
        List<PointF> VertexList;
        public PointF maxPoint;
        public PointF minPoint;
        public PointF center { get; set; }
        public Color oColor { get; set; }
        public float RotationAngle { get; set; }
       public PointF ReflectionPoint { get; set; }
       public PointF ScalePoint { get; set; }

        public Rhombus(PointF p)
        {
            VertexList = new List<PointF>();
            maxPoint = new PointF();
            minPoint = new PointF();
            center = p;
           
        }
        public Rhombus(List<PointF> vertexes, Color color)
        {
            VertexList = vertexes.ConvertAll(item => new PointF(item.X, item.Y));
            maxPoint = new PointF();
            minPoint = new PointF();
            oColor = color;
        }

        public Rhombus(Color Color)
        {
            center = new PointF(300, 300);
            oColor = Color;
            VertexList =  new List<PointF>();
        }

        public GraphicsPath GetPath()
        {
            var path = new GraphicsPath();
            var VertexRhomb = new[]
        {
            new PointF(center.X - 80, center.Y),
            new PointF(center.X, center.Y - 100),
            new PointF(center.X + 80, center.Y),
            new PointF(center.X, center.Y + 100)
        };
            path.AddPolygon(VertexRhomb.ToArray());
            if (RotationAngle != 0)
            {
                var mx = new Matrix();
                mx.RotateAt(RotationAngle, center);
                path.Transform(mx);
            }
            if (ReflectionPoint != new PointF(0, 0))
            {
                var rf = new Matrix(1, 0, 0, -1, 0, 0);
                float dy = 0 - ReflectionPoint.Y;
                var tr = new Matrix();
                tr.Translate(0, -dy);
                tr.Multiply(rf);
                tr.Translate(0, dy);
                path.Transform(tr);
            }
            if (ScalePoint!=new PointF(0, 0))
            {
                Matrix m = new Matrix();
               // m.Scale(0,3,MatrixOrder.Append);
                m.Translate(ScalePoint.X, ScalePoint.Y);
                path.Transform(m);
            }

            return path;
        }

        //public bool CheckScale (MouseEventArgs p)
        //{
        //    if ((p.X >= Min().X - 7 && p.X <= Min().X + 7) && ((p.Y >= Min().Y - 7 && p.Y <= Min().Y + 7) || (p.Y >= Max().Y - 7 && p.Y <= Max().Y + 7))) return true;
        //    if ((p.X >= Max().X - 7 && p.X <= Max().X + 7) && ((p.Y >= Min().Y - 7 && p.Y <= Min().Y + 7) || (p.Y >= Max().Y - 7 && p.Y <= Max().Y + 7))) return true;
        //    return false;
        //}

        public void Draw(Graphics g)
        {
            using(var path = GetPath())
            using (var brush = new SolidBrush(oColor))
                g.FillPath(brush, path);

        }

        public void Move(PointF d)
        {
            center = new PointF(center.X + d.X, center.Y + d.Y);

        }

        public bool Selected(PointF p)
        {
            bool selected = false;
            using (var path = GetPath())
                selected = path.IsVisible(p);
            return selected;

        }
        public PointF Min()
        {
            PointF p = new PointF();
            p.X = GetPath().PathPoints.Min(item => item.X);
            p.Y = GetPath().PathPoints.Min(item => item.Y);
            return p;
        }

        public PointF Max()
        {
            PointF p = new PointF();
            p.X = GetPath().PathPoints.Max(item => item.X);
            p.Y = GetPath().PathPoints.Max(item => item.Y);
            return p;
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

        //public void Rotate()
        //{
            //double cos = Math.Cos(45 * Math.PI / 180); //maybe refactor 
            //double sin = Math.Sin(45 * Math.PI / 180);
            //PointF[] VertexRhomb = new PointF[4];
            //for (int i = 0; i < GetPath().PointCount; i++) //sides = 6? 
            //{
            //    PointF p = new PointF();
            //    p.X = (float)((VertexRhomb[i].X - center.X) * cos - (VertexRhomb[i].Y - center.Y) * sin + center.X);
            //    p.Y = (float)((VertexRhomb[i].X - center.X) * sin + (VertexRhomb[i].Y - center.Y) * cos + center.Y);
            //    VertexRhomb[i] = new PointF(p.X, p.Y);
            //    //p.X = (float)(cos * ((GetPath().PathPoints[i].X) - Center().X) - sin * ((GetPath().PathPoints[i].Y) - Center().Y) + (Center().X));
            //    //p.Y = (float)(sin * ((GetPath().PathPoints[i].X) - Center().X) + cos * ((GetPath().PathPoints[i].Y) - Center().Y) + (Center().Y));
            //    p.X = GetPath().PathPoints[i].X + 10;
            //    p.Y = GetPath().PathPoints[i].Y + 10;
            //    GetPath().PathPoints[i] = new PointF(p.X, p.Y);
            //}
            //GetPath().AddPolygon(VertexRhomb.ToArray());
            //Matrix rotateMtx = new Matrix();
            //rotateMtx.Translate(center.X, center.Y);
            //rotateMtx.RotateAt(45f, center);
            //rotateMtx.Translate(-center.X, -center.Y);
            //using (var path = GetPath())
            //GetPath().Transform(rotateMtx);
        //}
    }
}
