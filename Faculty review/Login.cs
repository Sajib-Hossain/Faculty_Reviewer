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
    public partial class Login : Form
    {

        string connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );

        public static string name, typ, uid, review;

        public Login()
        {
            InitializeComponent();
        }


        public void signin()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (var sqd = new MySqlDataAdapter("SELECT Count(*) FROM user WHERE User_id = '" + this.textBox1.Text + "' AND password = '" + this.textBox2.Text + "'", conn))
                {

                    DataTable dt = new DataTable();
                    sqd.Fill(dt);
                    if (dt.Rows[0][0].ToString() == "1")
                    {

                        using (var cmd = new MySqlCommand("SELECT User_name, type_id,User_id, reviewed FROM user Where User_id = '" + this.textBox1.Text + "'", conn))
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                reader.Read();
                                name = reader.GetString(0);
                                typ = reader.GetString(1);
                                uid = reader.GetString(2);
                                review = reader.GetString(3);
                                /*var rvwd = reader.GetString(2);*/
                            }
                        }

                        this.Hide();
                        Search src = new Search();
                        src.Show();
                    }
                    else
                        MessageBox.Show("Invalid username or password");
                }

            }
        }


        private void Signin_Click(object sender, EventArgs e)
        {
            signin();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Register_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration rg = new Registration();
            rg.Show();
        }
    }
}
