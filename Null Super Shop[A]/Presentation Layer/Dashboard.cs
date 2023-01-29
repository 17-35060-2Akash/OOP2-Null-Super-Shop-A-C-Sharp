using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null_Super_Shop_A_.Presentation_Layer
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel_Slider_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dash3dot_Click(object sender, EventArgs e)
        {
            if(panel_Slider.Width == 40)
            {
                panel_Slider.Width = 165;
            }
            else
            {
                panel_Slider.Width = 40;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new AddEmploye());
        }

        private void panel_workarea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrFormInpanel(object sender)
        {
            if (this.panel_workarea.Controls.Count > 0)
                this.panel_workarea.Controls.RemoveAt(0);
            Form fm = sender as Form;
            fm.TopLevel = false;
            fm.Dock = DockStyle.Fill;
            this.panel_workarea.Controls.Add(fm);
            this.panel_workarea.Tag = fm;
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new ManageCategory());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new UpdateEmployee());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new ManageProduct());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.Show();
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
