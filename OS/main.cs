using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (!panelcontainer.Controls.Contains(dashboard.Instance))
            {
                panelcontainer.Controls.Add(dashboard.Instance);
                dashboard.Instance.Dock = DockStyle.Fill;
                dashboard.Instance.BringToFront();
            }
            else
                dashboard.Instance.BringToFront();
                   
        }

        private void main_Load(object sender, EventArgs e)
        {
            
            if (!panelcontainer.Controls.Contains(dashboard.Instance))
            {
                panelcontainer.Controls.Add(dashboard.Instance);
                dashboard.Instance.Dock = DockStyle.Fill;
                dashboard.Instance.BringToFront();
            }
            else
                dashboard.Instance.BringToFront();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (!panelcontainer.Controls.Contains(users.Instance))
            {
                panelcontainer.Controls.Add(users.Instance);
                users.Instance.Dock = DockStyle.Fill;
                users.Instance.BringToFront();
            }
            else
                users.Instance.BringToFront();
        }

        private void panelcontainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnDoctor_Click(object sender, EventArgs e)
        {
            if (!panelcontainer.Controls.Contains(GP.Instance))
            {
                panelcontainer.Controls.Add(GP.Instance);
                GP.Instance.Dock = DockStyle.Fill;
                GP.Instance.BringToFront();
            }
            else
                GP.Instance.BringToFront();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {
            if (!panelcontainer.Controls.Contains(Patient.Instance))
            {
                panelcontainer.Controls.Add(Patient.Instance);
                Patient.Instance.Dock = DockStyle.Fill;
                Patient.Instance.BringToFront();
            }
            else
                Patient.Instance.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
