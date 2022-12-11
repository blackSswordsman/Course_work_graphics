using GSC_Lr4;
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
    class Star : IShape
    {
        List<PointF> VertexList { get; set; }
        public PointF maxPoint;
        public PointF minPoint;
        public PointF center { get; set; }
        public Color oColor { get; set; }
        public float RotationAngle { get; set; }
        public PointF ReflectionPoint { get; set; }
        public PointF ScalePoint { get; set; }
        public Star(PointF p, Color color)
        {
            center = p;
            VertexList = new List<PointF>();
            maxPoint = new PointF();
            minPoint = new PointF();
            oColor = color;
        }
        public Star(Color Color) // default 
        {
            center = new PointF(150, 150);
            oColor = Color;
        }
        public Star(List<PointF> vertexes, Color color)
        {
            VertexList = vertexes.ConvertAll(item => new PointF(item.X, item.Y));
            maxPoint = new PointF();
            minPoint = new PointF();
            oColor = color;
        }
        public GraphicsPath GetPath()
        {
            // center = p;
            var path = new GraphicsPath();
            float x_center = center.X;
            float y_center = center.Y;
            int sides = 12;
            PointF[] VertexStar = new PointF[sides];
            float radius = 130;
            float radius_2 = radius * 1 / 2;
            for (int i = 0; i < sides; i++)
            {
                if (i % 2 == 0)
                {
                    VertexStar[i] = new PointF(
                    x_center + radius * (float)Math.Cos(i * 360 / sides * Math.PI / 180f),
                    y_center + radius * (float)Math.Sin(i * 360 / sides * Math.PI / 180f));
                }
                else
                {
                    VertexStar[i] = new PointF(
                    x_center + radius_2 * (float)Math.Cos(i * 360 / sides * Math.PI / 180f),
                    y_center + radius_2 * (float)Math.Sin(i * 360 / sides * Math.PI / 180f));
                }

            }
            //VertexList.AddRange(VertexStar.ToArray());
            path.AddPolygon(VertexStar.ToArray());
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
            return path;
        }
        //public bool CheckScale(MouseEventArgs p)
        //{
        //    if ((p.X >= Min().X - 7 && p.X <= Min().X + 7) && ((p.Y >= Min().Y - 7 && p.Y <= Min().Y + 7) || (p.Y >= Max().Y - 7 && p.Y <= Max().Y + 7))) return true;
        //    if ((p.X >= Max().X - 7 && p.X <= Max().X + 7) && ((p.Y >= Min().Y - 7 && p.Y <= Min().Y + 7) || (p.Y >= Max().Y - 7 && p.Y <= Max().Y + 7))) return true;
        //    return false;
        //}
        public void Draw(Graphics g)
        {
            using (var path = GetPath())
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
            int Xmin = (int)Min().X,
                  Ymin = (int)Min().Y;
            int Xmax = (int)Max().X,
                Ymax = (int)Max().Y;

            Pen pen = new Pen(Color.Gray);
            pen.DashStyle = DashStyle.Dash; // штрихованная линия
            e.DrawRectangle(pen, new Rectangle(Xmin, Ymin, Xmax - Xmin, Ymax - Ymin));
        }



        //public GraphicsPath GetRotatedPath()
        //{
        //    double cos = Math.Cos(45 * Math.PI / 180); //maybe refactor 
        //    double sin = Math.Sin(45 * Math.PI / 180);
        //    for (int i=0;i<GetPath().PathPoints.Count(); i++) //sides = 6? 
        //    {
        //        PointF p = new PointF();
        //        p.X = (float)(cos * ((GetPath().PathPoints[i].X) - center.X) - sin * ((GetPath().PathPoints[i].Y) - center.Y) + (center.X));
        //        p.Y = (float)(sin * ((GetPath().PathPoints[i].X) - center.X) + cos * ((GetPath().PathPoints[i].Y) - center.Y) + (center.Y));
        //        GetPath().PathPoints[i] = new PointF(p.X, p.Y);
        //    }
        //}
        //    var path = new GraphicsPath();
        //    List<PointF> temp = new List<PointF>();
        //    temp.AddRange(GetPath().PathPoints);
        //    path.AddPolygon(temp.ToArray());
        //    Matrix rotateMtx = new Matrix();
        //    rotateMtx.Translate(center.X, center.Y);
        //    rotateMtx.RotateAt(45f, center);
        //    rotateMtx.Translate(-center.X, -center.Y);
        //    path.Transform(rotateMtx);
        //    return path;
        //}
    }
}
