using Figures_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = Figures_WinForms.Properties.Rectangle;

namespace WF_nov
{
    public partial class Main : Form
    {
        private List<Figures> figures = new List<Figures>();

        private Rectangle rectangle;

        private Circle circle;

        private Triangle triangle;

        private Ellipse ellipse;

        private Point mouseDown;

        private Point change;

        bool isMoving;

        int Diff_X;

        int Diff_Y;
        
        public Main()
        {
            InitializeComponent();
        }
        private double FaceCalculation()
        {
            double face = 0;
            for (int i = 0; i < figures.Count(); i++)
            {
                face += figures[i].FaceCalculate();
            }
            return face;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            figures.OrderBy(x => x.FaceCalculate()).ToList();
            foreach (var fig in figures)
            {
                fig.DrawFigure(e.Graphics);
            }

            rectangle?.DrawFigure(e.Graphics);

            circle?.DrawFigure(e.Graphics);

            triangle?.DrawFigure(e.Graphics);

            ellipse?.DrawFigure(e.Graphics);

            toolStripStatusLabel.Text = FaceCalculation().ToString();
        }
        private void Main_Load(object sender, EventArgs e)
        {
            if (!File.Exists("file") || new FileInfo("file").Length == 0)
                return;

            IFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream("file", FileMode.Open))
            {
                figures = (List<Figures>)formatter.Deserialize(fs);
            }
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            IFormatter formatter = new BinaryFormatter();

            using (var fs = new FileStream("data", FileMode.Create))
                formatter.Serialize(fs, figures);
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 2)
                {
                    foreach (var fig in figures)
                        if (fig.IsPointInFigure(e.Location))
                        {
                            if (fig.Type() == "Rectangle")
                            {
                                var r = new Rectangle_Form();
                                r.Rectangle = (Rectangle)fig;
                                r.ShowDialog();

                                break;
                            }
                            if (fig.Type() == "Circle")
                            {
                                var c = new Circle_Form();
                                c.Circle = (Circle)fig;
                                c.ShowDialog();

                                break;
                            }
                            if (fig.Type() == "Triangle")
                            {
                                var tr = new Triangle_Form();
                                tr.Triangle = (Triangle)fig;
                                tr.ShowDialog();

                                break;
                            }
                            if (fig.Type() == "Ellipse")
                            {
                                var r = new EllipseForm();
                                r.Ellipse = (Ellipse)fig;
                                r.ShowDialog();

                                break;
                            }
                        }
                    Invalidate();
                }
                if (radioButtonMove.Checked)
                {
                    foreach (var fig in figures)
                    {
                        fig.Selected = false;
                    }
                    foreach (var fig in figures)
                        if (fig.IsPointInFigure(e.Location))
                        {
                            fig.Selected = true;
                            Diff_X = e.X - fig.Point1.X;
                            Diff_Y = e.Y - fig.Point1.Y;
                            isMoving = true;
                            return;
                        }
                }
                else if (radioButtonRectangle.Checked)
                {
                    mouseDown = e.Location;

                    rectangle = new Rectangle
                    {
                        Color = Color.Gray
                    };


                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    for (int i = figures.Count() - 1; i >= 0; i--)
                        if (figures[i].IsPointInFigure(e.Location))
                        {
                            figures[i].Selected = true;
                            break;
                        }
                    Invalidate();
                }
                else if (radioButtonCircle.Checked)
                {

                    mouseDown = e.Location;

                    circle = new Circle
                    {
                        Color1 = Color.Gray
                    };

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    for (int i = figures.Count() - 1; i >= 0; i--)
                        if (figures[i].IsPointInFigure(e.Location))
                        {
                            figures[i].Selected = true;
                            break;
                        }
                    Invalidate();
                }
                else if (radioButtonTriangle.Checked)
                {

                    mouseDown = e.Location;

                    triangle = new Triangle
                    {
                        Color = Color.Gray
                    };


                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    for (int i = figures.Count() - 1; i >= 0; i--)
                        if (figures[i].IsPointInFigure(e.Location))
                        {
                            figures[i].Selected = true;
                            break;
                        }
                    Invalidate();
                }
                else if (radioButtonEllipse.Checked)
                {

                    mouseDown = e.Location;

                    ellipse = new Ellipse
                    {
                        Color = Color.Gray
                    };

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    for (int i = figures.Count() - 1; i >= 0; i--)
                        if (figures[i].IsPointInFigure(e.Location))
                        {
                            figures[i].Selected = true;
                            break;
                        }
                    Invalidate();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                mouseDown = e.Location;

                circle = new Circle
                {
                    Color1 = Color.Gray
                };
            }
            Invalidate();
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (radioButtonMove.Checked && isMoving)
                {
                    change.X = e.X - Diff_X;
                    change.Y = e.Y - Diff_Y;
                    foreach (var fig in figures)
                    {
                        if (fig.Selected)
                        {
                            fig.Point1 = change;
                        }
                    }
                    Invalidate();
                }
                else if (radioButtonRectangle.Checked)
                {
                    if (rectangle == null)
                    {
                        return;
                    }
                    rectangle.Point1 = new Point
                    {
                        X = Math.Min(mouseDown.X, e.Location.X),
                        Y = Math.Min(mouseDown.Y, e.Location.Y),
                    };

                    rectangle.Width = Math.Abs(mouseDown.X - e.Location.X);
                    rectangle.Height = Math.Abs(mouseDown.Y - e.Location.Y);

                }
                else if (radioButtonCircle.Checked)
                {
                    if (circle == null)
                    {
                        return;
                    }
                    circle.Point1 = new Point
                    {
                        X = Math.Min(mouseDown.X, e.Location.X),
                        Y = Math.Min(mouseDown.Y, e.Location.Y),
                    };

                    circle.Radius = Math.Abs(mouseDown.X - e.Location.X);


                }
                else if (radioButtonTriangle.Checked)
                {
                    if (triangle == null)
                    {
                        return;
                    }
                   
                    triangle.Point1 = new Point
                    {
                        X = Math.Min(mouseDown.X, e.Location.X),
                        Y = Math.Min(mouseDown.Y, e.Location.Y),
                    };

                    triangle.Side = Math.Abs(mouseDown.X - e.Location.X);
                    triangle.Side = Math.Abs(mouseDown.Y - e.Location.Y);

                }
                else if (radioButtonEllipse.Checked)
                {
                    if (ellipse == null)
                    {
                        return;
                    }
                    ellipse.Point1 = new Point
                    {
                        X = Math.Min(mouseDown.X, e.Location.X),
                        Y = Math.Min(mouseDown.Y, e.Location.Y),
                    };

                    ellipse.Width = Math.Abs(mouseDown.X - e.Location.X);
                    ellipse.Height = Math.Abs(mouseDown.Y - e.Location.Y);

                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (rectangle == null)
                        return;

                    rectangle.Point1 = new Point
                    {
                        X = Math.Min(mouseDown.X, e.Location.X),
                        Y = Math.Min(mouseDown.Y, e.Location.Y),
                    };

                    rectangle.Width = Math.Abs(mouseDown.X - e.Location.X);
                    rectangle.Height = Math.Abs(mouseDown.Y - e.Location.Y);
                }
                Invalidate();
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                rectangle = null;
                circle = null;
                triangle = null;
                ellipse = null;
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (isMoving)
                {
                    isMoving = false;
                }
                if (radioButtonRectangle.Checked)
                {
                    if (rectangle == null)
                        return;
                    rectangle.Color = Color.BlueViolet;

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    figures.Add(rectangle);
                    rectangle.Selected = true;
                }
                if (radioButtonCircle.Checked)
                {
                    if (circle == null)
                        return;
                    circle.Color1 = Color.DarkRed;

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    figures.Add(circle);
                    circle.Selected = true;
                }
                if (radioButtonTriangle.Checked)
                {
                    if (triangle == null)
                    {
                        return;
                    }

                    triangle.Color = Color.SkyBlue;

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    figures.Add(triangle);
                    triangle.Selected = true;
                }
                if (radioButtonEllipse.Checked)
                {
                    if (ellipse == null)
                        return;
                    ellipse.Color = Color.HotPink;

                    for (int i = 0; i < figures.Count(); i++)
                        figures[i].Selected = false;

                    figures.Add(ellipse);
                    ellipse.Selected = true;
                }
                Invalidate();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {           
            var selectedFigure = figures.FirstOrDefault(f => f.Selected);            
            figures.Remove(selectedFigure ?? figures.LastOrDefault());
            Invalidate();
        }

       
    }
}
