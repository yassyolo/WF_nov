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
    public partial class Triangle_Form : Form
    {
        private Triangle triangle;

        public Triangle Triangle
        {
            get
            {
                return triangle;
            }
            set
            {
                triangle = value;
                textBoxSide.Text = triangle.Side.ToString();
                buttonColorTriangle.BackColor = triangle.Color;
            }
        }
        public Triangle_Form()
        {
            InitializeComponent();
        }

        private void Triangle_Form_Load(object sender, EventArgs e)
        {
            label3.Text = triangle.FaceCalculate().ToString();
        }

        private void Ok_Click(object sender, EventArgs e)
        {  
            triangle.Side = int.Parse(textBoxSide.Text);
            triangle.Color1 = buttonColorTriangle.BackColor;        
            DialogResult = DialogResult.OK;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonColorTriangle_Click(object sender, EventArgs e)
        {    
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                triangle.Color = colorDialog.Color;
            }
        }

        
    }
}
