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

namespace WF_nov
{
    internal partial class EllipseForm : Form
    {
        private Ellipse ellipse;
        public Ellipse Ellipse
        {
            get
            {
                return ellipse;
            }
            set
            {
                ellipse = value;
                textBoxWidth.Text = ellipse.Width.ToString();
                textBoxHeight.Text = ellipse.Height.ToString();
                Color.BackColor = ellipse.Color;
            }
        }
        public EllipseForm()
        {
            InitializeComponent();
        }

        private void EllipseForm_Load(object sender, EventArgs e)
        {
            label1.Text = ellipse.FaceCalculate().ToString();
        }

        private void Ok_Click(object sender, EventArgs e)
        {
            ellipse.Width = int.Parse(textBoxWidth.Text);
            ellipse.Height = int.Parse(textBoxHeight.Text);


            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Color_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ellipse.Color = colorDialog.Color;
            }
        }

        
    }
}
