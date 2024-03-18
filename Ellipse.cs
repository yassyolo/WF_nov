using Figures_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_nov
{
    [Serializable]
    public class Ellipse : Figures
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public override double FaceCalculate()
        {
            return Width * Height * Math.PI / 4;
        }

        public override void DrawFigure(Graphics g)
        {
            var colorFill = Color;
            using (var brush = new SolidBrush(colorFill))
                g.FillEllipse(brush, Point1.X, Point1.Y, Width, Height);
        }

        public override bool IsPointInFigure(Point point)
        {
            var center = new Point(Point1.X + Width / 2, Point1.Y + Height / 2);
            var x = (point.X - center.X) * (point.X - center.X);
            var y = (point.Y - center.Y) * (point.Y - center.Y);
            return ((double)x / (Width * Width / 4)) + ((double)y / (Height * Height / 4)) <= 1;
        }

        public override string Type()
        {
            return "Ellipse";
        }
    }
}
