using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace OS
{
    public partial class GP : UserControl
    {
        private static GP _instance;

        public static GP Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new GP();
                return _instance;
            }
        }




        public GP()
        {
            InitializeComponent();
        }

        private void GP_Load(object sender, EventArgs e)
        {

        }
    }
}
