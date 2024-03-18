using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WF_nov;

namespace Figures_WinForms.Properties
{
    [Serializable]  
    public class Triangle : Figures
    {
        public Color Color1 { get; set; }
        public int Side { get; set; }
        private Point Point2 { get; set; }
        private Point Point3 { get; set; }
        
        public override double FaceCalculate()
        {
            return Math.Round(Math.Sqrt(3) / 4 * Side * Side);
        }
        public override void DrawFigure(Graphics g)
        {
            int x1 = Point1.X + Side / 2;
            int y1 = Convert.ToInt32(Point1.Y + Math.Sqrt(Side * Side + (Side / 2) * (Side / 2)));
            var p1 = new Point(x1, y1);
            int x2 = Point1.X - Side / 2;
            int y2 = Convert.ToInt32(Point1.Y + Math.Sqrt(Side * Side + (Side / 2) * (Side / 2)));
            var p2 = new Point(x2, y2);
            Point2 = p1;
            Point3 = p2;
            var Points = new Point[3] { Point1, Point2, Point3 };
            var colorFill = Color;
            using (var brush = new SolidBrush(colorFill))
            g.FillPolygon(brush, Points);          
        }
        private double AreaForPointInShape(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return Math.Abs((x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * (y1 - y2)) / 2.0);
        }
        public override bool IsPointInFigure(Point point)
        {
            double A = AreaForPointInShape(Point3.X, Point3.Y, Point1.X, Point1.Y, Point2.X, Point2.Y);           
            double A1 = AreaForPointInShape(Point3.X, Point3.Y, Point1.X, Point1.Y, point.X, point.Y);            
            double A2 = AreaForPointInShape(Point3.X, Point3.Y, point.X, point.Y, Point2.X, Point2.Y);            
            double A3 = AreaForPointInShape(point.X, point.Y, Point1.X, Point1.Y, Point2.X, Point2.Y);
            return A == A1 + A2 + A3;
        }
        public override string Type()
        {
            return "Triangle";
        }
    }
}

