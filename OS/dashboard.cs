﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS
{
    public partial class dashboard : UserControl
    {
        private static dashboard _instance;

        public static dashboard Instance {

            get
            {
                if (_instance == null)
                    _instance = new dashboard();
                return _instance;
            }
        }


        public dashboard()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void deshboard_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }
       


        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lbltime.Text = datetime.ToString("hh:mm:ss tt");
        }
    }
}
