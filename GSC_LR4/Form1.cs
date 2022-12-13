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
        //Bitmap myBitmap;
        //Graphics g;

        //Pen DrawPen = new Pen(Color.Black, 1);
        //List<PointF> VertexList = new List<PointF>();
        private List<IShape> Shapes = new List<IShape>();
        List<IShape> Selected = new List<IShape>();
        int Operation = -1; // Рисование
        // bool checkPgn = false;
        bool moving = false;
        Point previousPoint = Point.Empty;
        PointF prevPoint = PointF.Empty;
       // Point pictureBox1MousePos = new Point();
        //int shapeType = 0;
        //PointF MousePos;
        IShape selectedShape;
        SolidBrush myBrush = new SolidBrush(Color.Black);
        Color color = Color.Gray;
        int rotateCount = 1;
        int scaleCount = 1;
        PointF ReflectPoint=PointF.Empty;
        PointF crossHair;
        IShape TMO;
        int TMOIndex = -1;
        bool scaling = false;



        public Form1()
        {
            InitializeComponent();
            //myBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //g = Graphics.FromImage(myBitmap);
            //var path = new GraphicsPath();

        }
       
        // Обработчик события
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Operation == 2) // select
            {

                for (var i = Shapes.Count - 1; i >= 0; i--)
                    if (Shapes[i].Selected(e.Location)) { selectedShape = Shapes[i]; break; }
                if (selectedShape != null ) 
                { moving = true; previousPoint = e.Location; 
                    //selected.Add(selectedShape);
                }
                //if (selectedShape.CheckScale(e)) { scaling = true; prevPoint = e.Location; }
                //base.OnMouseDown(e);
                //pictureBox1.Invalidate();
                
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
            //if (scaling)
            //{
            //    var p = new PointF(e.X - prevPoint.X, e.Y - prevPoint.Y);
            //    selectedShape.ScalePoint = p;
            //    prevPoint = e.Location;
            //    pictureBox1.Invalidate();
            //}
            base.OnMouseMove(e);
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (moving) {  moving = false; Operation = 1; }
            //if (scaling) { scaling = false; }
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath _path = new GraphicsPath();
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
                switch (TMOIndex)
                {
                    case 1: //xor
                        f1.Intersect(Selected[1].GetPath());
                        using (var tmoBrush = new SolidBrush(this.BackColor))
                            e.Graphics.FillRegion(tmoBrush, f1);
                        break;
                    case 2: //subtract
                        //f1.Complement(f2);
                        f1.Complement(f2);
                        using (var tmoBrush = new SolidBrush(Color.Black))
                            e.Graphics.FillRegion(tmoBrush, f1);
                        break;
                }

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
            selectedShape.ScalePoint = 1.2f * scaleCount;
            pictureBox1.Invalidate();
            scaleCount++;
            selectedShape = null;
        }
    }
}

