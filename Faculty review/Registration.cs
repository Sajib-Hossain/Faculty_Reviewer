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
    public partial class Registration : Form
    {

        string connectionString = string.Format(
                "server={0};uid={1};pwd={2};database={3}",
                "localhost",
                "root",
                "1813059642",
                "frapp"
                );


        public Registration()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            int type = 0;

            if (comboBox1.Text == "Advisor")
            {
                type = 1;
            }
            else if (comboBox1.Text == "Faculty")
            {
                type = 2;
            }
            else
            {
                type = 3;
            }

            string s = textBox3.Text;

            int sl = s.Length;

            if (sl > 14)
            {
                string dom = s.Substring(sl - 14);

                if (dom == "northsouth.edu")
                {

                    bool IsValidEmail(string email)
                    {
                        try
                        {
                            var addr = new System.Net.Mail.MailAddress(email);
                            return addr.Address == email;
                        }
                        catch
                        {
                            return false;
                        }
                    }


                    if (IsValidEmail(s))
                    {

                        using (var conn = new MySqlConnection(connectionString))
                        {
                            conn.Open();

                            using (var cmd = new MySqlCommand("INSERT into frapp.user(User_id,User_name,email,password,type_id,reviewed,isactive) values ('"+ this.textBox1.Text + "', '" + this.textBox2.Text + "', '" + this.textBox3.Text + "', '" + this.textBox4.Text + "', '" + type + "', '" + 0 + "', '" + 0 + "')", conn))
                            {
                                using (var reader = cmd.ExecuteReader())
                                {
                                    MessageBox.Show("Data Inserted");
                                }
                            }

                        }
                        this.Hide();
                        Login lin = new Login();
                        lin.Show();
                    }
                    else
                    {
                        MessageBox.Show("Use Valid Academic Mail");
                    }
                }

                else
                {
                    MessageBox.Show("Use Your Academic Mail");
                }
            }

            else
            {
                MessageBox.Show("Use Your Academic Mail");
            }


        }
    }
}
