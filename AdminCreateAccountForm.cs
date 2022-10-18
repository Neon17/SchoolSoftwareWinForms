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

namespace AllFormsDesign
{
    public partial class AdminCreateAccountForm : Form
    {
        public AdminCreateAccountForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int SendStatus = 1; //If SendStatus = 1 (true) it sends to database
            if ((textBox1.Text.Length == 0) || (textBox2.Text.Length == 0) || (textBox3.Text.Length == 0))
            {
                MessageBox.Show("All fields should be filled!");
                SendStatus = 0;
            }
            if (SendStatus == 1)
            {
                if (InsertToDatabase())
                {
                    MessageBox.Show("Success!");
                    this.Close();
                }
            }
        }
        private bool InsertToDatabase()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=JourneySchool;Integrated Security=True");
            conn.Open();
            SqlCommand query = new SqlCommand("Insert into Admin (Id, Name, Password) VALUES (@Id, @Name, @Password)", conn);
            try
            {
                query.Parameters.AddWithValue("@Id", int.Parse(textBox1.Text));
                query.Parameters.AddWithValue("@Name", textBox2.Text);
                query.Parameters.AddWithValue("@Password", textBox3.Text);
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show("Only Numbers are allowed in ID!");
                return false;
            }
            try
            {
                query.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                conn.Close();
                MessageBox.Show("Invalid ID..");
                return false;
            }
            conn.Close();
            return true;
        }
    }
}
