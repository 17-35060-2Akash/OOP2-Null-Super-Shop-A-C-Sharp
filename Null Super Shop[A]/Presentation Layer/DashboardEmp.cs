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
    public partial class DashboardEmp : Form
    {
        public DashboardEmp()
        {
            InitializeComponent();
        }

        private void dash3dot_Click(object sender, EventArgs e)
        {
            //if (panel_Slider.Width == 40)
            //{
            //    panel_Slider.Width = 165;
            //}
            //else
            //{
            //    panel_Slider.Width = 40;
            //}
        }

        private void panel_Upper_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dash3dot_Click_1(object sender, EventArgs e)
        {

        }

        private void dash3dot_Click_2(object sender, EventArgs e)
        {
            if (panel_Slider.Width == 40)
            {
                panel_Slider.Width = 165;
            }
            else
            {
                panel_Slider.Width = 40;
            }
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
        private void AddCategoryEmp_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new ManageCategory());
        }

        private void AddProductEmp_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new ManageProduct());
        }

        private void Report_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new ReportToAdmin());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrFormInpanel(new updateEmpInfo());

        }

        private void LogOut_Click(object sender, EventArgs e)
        {
            Form1 f2 = new Form1();
            this.Hide();
            f2.Show();
        }

        private void PaymentUpdate_Click(object sender, EventArgs e)
        {
            //AbrFormInpanel(new pay());

        }
    }
}
