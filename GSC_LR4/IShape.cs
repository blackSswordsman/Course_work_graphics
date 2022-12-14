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
    interface IShape
    {
        GraphicsPath GetPath();
        float RotationAngle { get; set; }
        PointF ReflectionPoint { get; set; }
        PointF ScalePoint { get; set; }
        float ScaleFactor { get; set; }
        bool Selected(PointF p);
        void Draw(Graphics g);
        void Move(PointF m);
        void Reflect(PointF r);
         PointF Min();
         PointF Max();
        PointF center { get; set; }

        //void Zoom(PointF z);
        //void Mirrored(PointF h);

        //void Delete(PointF s);

        void DrawSelection(Graphics e);

    }
}
