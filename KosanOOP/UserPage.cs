using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KosanOOP
{
    public partial class UserPage : Form, Page
    {
        public UserPage(string username)
        {
            InitializeComponent();
            label5.Text = username;
            populate();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Doc\University\Materials\Semester2\oop\UTS\Kosan Manager\Rooms.mdf;Integrated Security=True;Connect Timeout=30");
        
        public void populate()
        {
            try
            {
                Con.Open();
                string query = "SELECT roomName, roomPrice, isFilled FROM Rooms";
                SqlDataAdapter sda = new SqlDataAdapter(query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                DGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Refresh_Click(object sender, EventArgs e)
        {
            populate();
        }



        public void LogOut_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            this.Hide();
            l.Show();
        }
    }
}
