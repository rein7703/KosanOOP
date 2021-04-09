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



namespace KosanOOP
{
    public partial class managementPage : Form, Page
    {
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Doc\University\Materials\Semester2\oop\UTS\Kosan Manager\Rooms.mdf;Integrated Security=True;Connect Timeout=30");

        public managementPage()
        {
            InitializeComponent();
            populate();
        }


        
        private void add_Click(object sender, EventArgs e)
        {
            string fullOrNot = "belum";
            string paidOrnot = "belum";
            if (checkBox1.CheckState == CheckState.Checked)
            {
                fullOrNot = "sudah";
            }
            if (checkBox2.CheckState == CheckState.Checked)
            {
                paidOrnot = "sudah";
            }

            
            
            try
            {
                Property props = new Property(textBox1.Text, Int64.Parse(textBox2.Text), fullOrNot, paidOrnot);

                string query = "INSERT INTO Rooms (roomName, roomPrice, isFilled, isPaid) VALUES ( '" + props.Name + "', '" + props.Price + "', '" + props.isFull + "', '" + props.isPaid + "' )";
                Con.Open();
                SqlCommand cmd = new SqlCommand(query, Con);
                
                cmd.ExecuteNonQuery();
                Con.Close();
                populate();
                MessageBox.Show("Saved!");
            } catch (Exception ex)
            {
                Con.Close();
                MessageBox.Show(ex.Message + "\nplease try again");
            }
            
        }
        public void populate()
        {
            try
            {
                Con.Open();
                string query = "SELECT * FROM Rooms";
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

        public void Refresh_Click(object sender, EventArgs e)
        {
            populate();
        }
        private void DGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)

            {

                DataGridViewRow row = this.DGV.Rows[e.RowIndex];

                if (row.Cells != null)
                {

                    textBox1.Text = row.Cells["roomName"].Value.ToString();
                    textBox2.Text = row.Cells["roomPrice"].Value.ToString();
                    MessageBox.Show(row.Cells["isFilled"].Value.ToString() + "terisi\n\n" + row.Cells["isPaid"].Value.ToString() + " dibayar");

                }
            }

        }

        public void LogOut_Click(object sender, EventArgs e)
        {
            Login reopen = new Login();
            this.Hide();
            reopen.Show();

        }

        private void editTab_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Missing information.");
                }
                else
                {
                    string fullOrNot = "belum";
                    string paidOrnot = "belum";
                    if (checkBox1.CheckState == CheckState.Checked)
                    {
                        fullOrNot = "sudah";
                    }
                    if (checkBox2.CheckState == CheckState.Checked)
                    {
                        paidOrnot = "sudah";
                    }

                    Con.Open();
                    string query = "UPDATE Rooms SET roomPrice = " + Int64.Parse(textBox2.Text) + ", isFilled = '" + fullOrNot + "', isPaid = '" + paidOrnot + "' WHERE roomName = '" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("successfully updated.");

                }

            }
            catch (Exception exx)
            {
                MessageBox.Show(exx.Message);
            }
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Missing information.");
                }
                else
                {
                    Con.Open();
                    string query = "DELETE FROM Rooms WHERE roomName = '" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    populate();
                    MessageBox.Show("successfully deleted.");
                    
                }
                }
             catch (Exception exx)
             {
                  MessageBox.Show(exx.Message);
             }
           
        }

       
    }
 }

    
