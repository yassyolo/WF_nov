using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF_nov;

namespace Figures_WinForms.Properties
{
    [Serializable]
    public class Rectangle : Figures
    {
        public new Color Color { get; set; }
        public int Height { get; set; }

        public int Width { get; set; }
        public override double FaceCalculate()
        {
            return Height * Width;
        }
        public override void DrawFigure(Graphics g)
        {
            var colorFill = Color;

            using (var brush = new SolidBrush(colorFill))
                g.FillRectangle(brush, Point1.X, Point1.Y, Width, Height);
        }
        public override bool IsPointInFigure(Point point)
        {
            return Point1.X <= point.X && point.X <= Point1.X + Width &&
                   Point1.Y <= point.Y && point.Y <= Point1.Y + Height;
        }
        public override string Type()
        {
            return "Rectangle";
        }
    }
}


