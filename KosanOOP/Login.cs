using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KosanOOP
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        Admin adm = new Admin("adminUser", "adminPass");
        Member[] mem = new Member[] { new Member("mem1User", "mem1Pass"), 
            new Member("mem2User", "mem2Pass"), new Member("mem3User", "mem3Pass"), new Member("mem4User", "mem4Pass"), 
            new Member("mem5User", "mem5Pass"), new Member("mem6User", "mem6Pass"), new Member("mem7User", "mem7Pass") };
        private void admLogin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == adm.Username && textBox2.Text == adm.Password)
            {
                managementPage pg = new managementPage();
                this.Hide();
                pg.Show();
            }
            else
            {
                MessageBox.Show("You have no authorization as an admin");
            }
        }

        private void loginMember_Click(object sender, EventArgs e)
        {
            bool Auth = false;
            foreach (Member x in mem)
            {
                if (textBox1.Text == x.Username && textBox2.Text == x.Password)
                {
                    UserPage pg = new UserPage(x.Username);
                    Auth = true;
                    this.Hide();
                    pg.Show();
    
                }
                
            }
            if (Auth == false)
            {
                MessageBox.Show("Please check your username or password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
