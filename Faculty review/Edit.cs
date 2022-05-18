using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Faculty_review
{
    public partial class Edit : Form
    {
        string connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );

        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
             using (var conn = new MySqlConnection(connectionString))
             {
                
                /*MySqlCommand cmd = new MySqlCommand("UPDATE user SET name='"+ this.textBox1.Text + "', password= '" + this.textBox2.Text + "' WHERE User_id=1813059642");
                MySqlDataReader MyReader2;*/
                conn.Open();

                using (var cmd = new MySqlCommand("UPDATE user SET User_name='" + this.textBox1.Text + "', password= '" + this.textBox2.Text + "' WHERE User_id= '"+ Login.uid +"'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        MessageBox.Show("Data Updated");
                    }
                }

                /*MyReader2 = cmd.ExecuteReader();
                MessageBox.Show("Data Updated");
                while (MyReader2.Read())
                {
                }
                MessageBox.Show($"{textBox1.Text}");*/
            }

            this.Hide();
            Login lg = new Login();
            lg.Show();
            
        }
    }
}
