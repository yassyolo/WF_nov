using Figures_WinForms;
using Figures_WinForms.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = Figures_WinForms.Properties.Rectangle;

namespace WF_nov
{
    internal partial class Rectangle_Form : Form
    {
        private Rectangle rectangle;
        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
            set
            {
                rectangle = value;
                textBoxWidth.Text = rectangle.Width.ToString();
                textBoxHeight.Text = rectangle.Height.ToString();
                buttonColorRectangle.BackColor = rectangle.Color;
            }
        }
        public Rectangle_Form()
        {
            InitializeComponent();
        }

        private void RectangleForm_Load(object sender, EventArgs e)
        {
            label4.Text = rectangle.FaceCalculate().ToString();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            rectangle.Width = int.Parse(textBoxWidth.Text);
            rectangle.Height = int.Parse(textBoxHeight.Text);
            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private void buttonColorRectangle_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                rectangle.Color = colorDialog.Color;
            }
        }
    }
}
