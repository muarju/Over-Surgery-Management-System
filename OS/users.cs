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
using System.Drawing.Imaging;
using System.Configuration;

namespace OS
{

    public partial class users : UserControl
    {
        SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString);

        private static users _instance;

        public static users Instance
        {

            get
            {
                if (_instance == null)
                    _instance = new users();
                return _instance;
            }
        }

        public object ConfigurationManager { get; private set; }

        public users()
        {
            InitializeComponent();
        }

        private void users_Load(object sender, EventArgs e)
        {
            this.usersTableAdapter.Fill(this.osDataSet.Users);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
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
                PbUserPic.ImageLocation = imgLocation;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            byte[] images = null;
            FileStream streem = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
            BinaryReader brs = new BinaryReader(streem);
            images = brs.ReadBytes((int)streem.Length);

           
            con.Open();
            String query = "insert into Users(Username,Password,Fname,Lname,Mobile,Email,Gender,Address,City,Postal_code,Dob,Picture,UserType,Status) values('" + txtUsername.Text + "','" + txtPassword.Text + "','" + txtFname.Text + "','" + txtLname.Text + "','" + txtMobile.Text + "','" + txtEmail.Text + "','" + cmbGender.SelectedItem + "','" + txtAddress.Text + "','" + txtCity.Text + "','" + txtPostalCode.Text + "','" + dateTimePickerDOB.Value + "','" + images + "','" + cmbUserType.SelectedItem + "','1')";
            SqlDataAdapter SDA = new SqlDataAdapter(query, con);
            SDA.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("New User Add Successfully!");
            con.Close();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
