using Figures_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using WF_nov;

namespace Figures_WinForms.Properties
{
    [Serializable]
    public class Circle : Figures
    {
        public Color Color1 { get; set; }
        public int Radius { get; set; }
        public override double FaceCalculate()
        {
            return Math.Pow(Radius, 2) * Math.PI; 
        }
        public override void DrawFigure(Graphics g)
        {
            var brushColor = Color1;
            using (var brush = new SolidBrush(brushColor))
            g.FillEllipse(brush, Point1.X, Point1.Y, Radius * 2, Radius * 2);
        }
        public override bool IsPointInFigure(Point point)
        {
            var p = new Point(Point1.X + Radius, Point1.Y + Radius);
            return ((p.X - point.X) * (p.X - point.X)) + ((p.Y - point.Y) * (p.Y - point.Y)) <= Radius * Radius;
        }
        public override string Type()
        {
            return "Circle";
        }

    }
}

