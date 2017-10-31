using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Configuration;

namespace OS
{
    public partial class Patient : UserControl
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);

        private static Patient _instance;

        public static Patient Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new Patient();
                return _instance;
            }
        }
        public Patient()
        {
            InitializeComponent();
        }

        private void Patient_Load(object sender, EventArgs e)
        {
            


        }
        String imgLocation = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*.png) |*.png|jpg files(*.jpg)|*.jpg|all files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);
            
            con.Open();
            String query = "insert into patient (Fname,Lname,Gender,Mobile,DOB,Address,City,Postal_code,Preferred,picture) values('" + txtFname.Text + "','" + txtLname.Text + "','" + ComGender.SelectedItem + "','" + txtMobile.Text + "','" + Dob.Value + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtPostal.Text + "','" + txtPreferred.Text + "','" + images + "')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("New Patient Add Successfully!");
            con.Close();
        }
       

    }
}
