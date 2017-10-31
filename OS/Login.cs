using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace OS
{
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            con.Open();

            String query = "Select Username, Password from Users where username='"+txtUsername.Text+"' and Password='"+txtPassword.Text+"'";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            SDA.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                this.Hide();
                main home = new main();
                home.Show();
            }
            else
            {
                MessageBox.Show("Invalid Login please check username and password");
            }
            con.Close();
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
