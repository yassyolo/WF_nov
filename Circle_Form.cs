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
    public partial class Circle_Form : Form
    {
        private Circle circle;

        public Circle Circle
        {
            get
            {
                return circle;
            }
            set
            {
                circle = value;
                textBoxRadius.Text = circle.Radius.ToString();
                Color.BackColor = circle.Color1;             
            }
        }
        public Circle_Form()
        {
            InitializeComponent();
        }

        private void CircleForm_Load(object sender, EventArgs e)
        {
            label3.Text = circle.FaceCalculate().ToString();
        }
        private void Ok_Click(object sender, EventArgs e)
        {
            circle.Radius = int.Parse(textBoxRadius.Text);           
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
                circle.Color1 = colorDialog.Color;
            }
        }
    }
}
