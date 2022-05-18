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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();



            /*Database connector*/

            var connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );

            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new MySqlCommand("SELECT User_name, User_id, reviewed FROM user Where User_id = '"+ Login.uid +"'", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        var nam = reader.GetString(0);
                        var uid = reader.GetString(1);
                        var rvwd = reader.GetString(2);
                        label1.Text = nam;
                        label2.Text = uid;
                        label3.Text = "Faculty Reviewed: "+rvwd;
                    }
                }

                if (Login.typ == "3")
                {
                    button3.Hide();
                    label4.Hide();
                }
                else
                {
                    using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM notification", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            var cn = reader.GetString(0);
                            label4.Text = cn;
                            if(cn == "0")
                            {
                                label4.Hide();
                            }
                        }
                    }
                }
            }


        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("You clicked me");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Edit edit = new Edit();
            edit.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            notify nf = new notify();
            nf.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
