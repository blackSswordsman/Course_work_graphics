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
        public PointF maxPoint;
        public PointF minPoint;
        public PointF center { get; set; }
        public Color oColor { get; set; }
        public float RotationAngle { get; set; }
        public PointF ReflectionPoint { get; set; }
        public PointF ScalePoint { get; set; }
        public float ScaleFactor { get; set; }
        public bool TMO { get; set; }
        public PointF TMOCenter { get; set; }
       
        public Star(Color Color) // default 
        {
            center = new PointF(150, 150);
            oColor = Color;
            TMO = false;
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
                    x_center + radius * (float)Math.Cos
                    (i * 360 / sides * Math.PI / 180f),
                    y_center + radius * (float)Math.Sin
                    (i * 360 / sides * Math.PI / 180f));
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
            if (RotationAngle != 0 && TMO == false)
            {
                var mx = new Matrix();
                mx.RotateAt(RotationAngle, center);
                path.Transform(mx);
            }

            if (RotationAngle != 0 && TMO == true)
            {
                var mx = new Matrix();
                mx.RotateAt(RotationAngle, TMOCenter);
                path.Transform(mx);
            }

            if (ScalePoint != PointF.Empty)
            {
                PointF transformPoint = ScalePoint;
                var tr = new Matrix();
                tr.Multiply(new Matrix(1, 0, 0, 1, -transformPoint.X, -transformPoint.Y), MatrixOrder.Append);
                tr.Multiply(new Matrix(1, 0, 0, ScaleFactor, 0, 0), MatrixOrder.Append);
                tr.Multiply(new Matrix(1, 0, 0, 1, transformPoint.X, transformPoint.Y), MatrixOrder.Append);
                path.Transform(tr);
            }
            return path;
        }
        public void Reflect(PointF r)
        {
            if (ReflectionPoint.Y < center.Y) //above shape
            {
                center = new PointF(center.X, center.Y - 2 * (center.Y - ReflectionPoint.Y));
                return;
            }
            if (ReflectionPoint.Y > center.Y) //below shape
            {
                center = new PointF(center.X, center.Y + 2 * (-center.Y + ReflectionPoint.Y));
                return;
            }
        }

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
