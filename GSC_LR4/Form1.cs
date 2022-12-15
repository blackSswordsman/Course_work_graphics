using GSC_LR4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSC_Lr4
{
    public partial class Form1 : Form
    {

        private List<IShape> Shapes = new List<IShape>();
        List<IShape> Selected = new List<IShape>();
        int Operation = -1; // Рисование
        bool moving = false;
        Point previousPoint = Point.Empty;
        int shapeType = 0;
        IShape selectedShape;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Color color = Color.Gray;
        int rotateCount = 1;
        PointF ReflectPoint=PointF.Empty;
        PointF crossHair;
        IShape TMO;
        int TMOIndex = -1;
        List<PointF> SplinePnts = new List<PointF>();
        int splineCount;


        public Form1()
        {
            InitializeComponent();

        }
       
        // Обработчик события
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (shapeType == 1)
            {
                SplinePnts.Add(new PointF(e.X, e.Y));
                pictureBox1.Invalidate();
                //if (SplinePnts.Count == 4)
                //{
                //    pictureBox1.Invalidate();
                //}

            }
            if (Operation == 2) // select
            {

                for (var i = Shapes.Count - 1; i >= 0; i--)
                    if (Shapes[i].Selected(e.Location)) { selectedShape = Shapes[i]; break; }
                if (selectedShape != null ) 
                {
                    moving = true; previousPoint = e.Location; 
                }
                
            }
            if (Operation == 7)
            {
                while (Selected.Count() < 2)
                {
                    for (var i = Shapes.Count - 1; i >= 0; i--)
                        if (Shapes[i].Selected(e.Location))
                        {
                            Selected.Add(Shapes[i]);
                            break;
                        }
                    break;
                }
            }
           
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving)
            {
                var d = new Point(e.X - previousPoint.X, e.Y - previousPoint.Y);
                selectedShape.Move(d);
                previousPoint = e.Location;
                pictureBox1.Invalidate();
            }
            base.OnMouseMove(e);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving) {  moving = false; Operation = 1; }
            base.OnMouseUp(e);
            //selectedShape = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.ShowDialog();
        }

        private void starBtn_Click(object sender, EventArgs e)
        {
            Operation = 1;
            //shapeType = 1;
            Shapes.Add(new Star(color));
            pictureBox1.Invalidate();

        }
        private void RhombBtn_Click(object sender, EventArgs e)
        {
            Operation = 1;
            //shapeType = 2;
            Shapes.Add(new Rhombus(color));
            pictureBox1.Invalidate();
        }
        private void colorBtn_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // установка цвета фигуры
            this.showColor.BackColor = colorDialog1.Color;
            myBrush.Color = colorDialog1.Color;
            color = colorDialog1.Color;

        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            Operation = 2;
        }

        public void DrawSpline()
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (shapeType == 1)
            {
                using(Pen pen = new Pen(Color.DarkGreen))
                if (SplinePnts.Count > 0)
                {
                    foreach (var point in SplinePnts)
                    {
                        e.Graphics.DrawEllipse(pen, point.X-3, point.Y-3, 5, 5);
                    }
                    switch (splineCount)
                    {
                        case 1:
                            {
                               e.Graphics.DrawLine(pen, SplinePnts[0], SplinePnts[1]);
                               splineCount++;
                            }
                            break;
                            case 3:
                                {
                                    e.Graphics.DrawLine(pen, SplinePnts[2], SplinePnts[3]);
                                    DrawCubeSpline(new Pen(color), SplinePnts, e.Graphics);
                                    e.Graphics.DrawLine(pen, SplinePnts[0], SplinePnts[1]);
                                    e.Graphics.DrawLine(pen, SplinePnts[2], SplinePnts[3]);
                                    SplinePnts.Clear();
                                    splineCount = 0;
                                }
                                break;
                            default:splineCount++;break;
                    }
                }
            }
            if (Shapes.Count()!=0)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                foreach (var shape in Shapes)

                    shape.Draw(e.Graphics);
            }
            if (Operation ==2)  // select
            {
                selectedShape.DrawSelection(e.Graphics);
            }
            if (Operation == 4) //delete 
            {
                Shapes.Remove(selectedShape);
                pictureBox1.Invalidate();
                
            }
            if (Operation == 5)  //reflect
            {
                using (var pen = new Pen(new SolidBrush(Color.Red))) 
                    e.Graphics.DrawLine(pen,new PointF(0,ReflectPoint.Y), 
                        new PointF(pictureBox1.Width,ReflectPoint.Y));
                pictureBox1.Invalidate();
            }

            if (Operation == 6) //scale
            {
                using (var pen = new Pen(new SolidBrush(Color.Red))) 
                {
                    e.Graphics.DrawLine(pen, new PointF(crossHair.X, crossHair.Y - 7),
                        new PointF(crossHair.X, crossHair.Y + 7));
                    e.Graphics.DrawLine(pen, new PointF(crossHair.X - 7, crossHair.Y), 
                        new PointF(crossHair.X + 7, crossHair.Y));
                }
                pictureBox1.Invalidate();
            }
            if (Operation == 8 )
            {
                Region f1 = new Region(Selected[0].GetPath());
                Region f2 = new Region(Selected[1].GetPath());
                Selected[0].GetPath().AddPath(Selected[1].GetPath(),false);
                switch (TMOIndex)
                {
                    case 1: //xor
                        f1.Intersect(Selected[1].GetPath());
                        using (var tmoBrush = new SolidBrush(this.BackColor))
                            e.Graphics.FillRegion(tmoBrush, f1);

                        break;
                    case 2: //subtract
                        f1.Exclude(f2);
                        using (var tmoBrush = new SolidBrush(this.BackColor))
                        {
                            e.Graphics.DrawPath(new Pen(this.BackColor), Selected[1].GetPath());
                            e.Graphics.FillRegion(tmoBrush, f2);
                        }
                        break;
                }
            }

        }

        private void DrawCubeSpline(Pen drPen, List<PointF> P,Graphics e /*Point[] P*/)
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

                e.DrawLine(drPen, Ppred, Pt);
                Ppred = Pt;
                t += dt;
            }
        }
        private void RotateBtn_Click(object sender, EventArgs e)
        {
            Operation = 3; //rotate
            selectedShape.RotationAngle = 45*rotateCount;
            rotateCount++;
            pictureBox1.Invalidate();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            Operation = 4; //delete
            pictureBox1.Invalidate();
        }

        private void ReflectBtn_Click(object sender, EventArgs e)
        {
            Operation = 5; //reflect
            if (ReflectPoint != PointF.Empty)
            {
                selectedShape.ReflectionPoint = ReflectPoint;
                selectedShape.Reflect(ReflectPoint);
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Operation == 5)  // reflect 
            {
                ReflectPoint = e.Location;
            }
            if (Operation == 6)  //scale
            {
                crossHair = e.Location;
            }
        }

        private void ScaleBtn_Click(object sender, EventArgs e)
        {
            Operation = 6;
            pictureBox1.Invalidate();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            Shapes.Clear();
            pictureBox1.Invalidate();
        }


        private void ExecuteTMO_Click(object sender, EventArgs e)
        {
            Operation = 8;
            pictureBox1.Invalidate();
        }

        private void TMO_Mode_CheckedChanged(object sender, EventArgs e)
        {
            if (TMO_Mode.Checked)
            {
                Operation = 7;
            }
            if(TMO_Mode.Checked == false)
            {
                Operation = 1;
            }
        }

        private void TMOCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TMOCmbBox.SelectedIndex)
            {
                case 0: TMOIndex = 1;
                    break;
                case 1: TMOIndex = 2;
                    break;
            }
        }

        private void EnlargeBtn_Click(object sender, EventArgs e)
        {
            selectedShape.ScalePoint = crossHair;
            pictureBox1.Invalidate();
            selectedShape.ScaleFactor+=0.7f;
           // selectedShape = null;
        }

        private void splineBtn_Click(object sender, EventArgs e)
        {
            shapeType = 1;
        }
    }
}

