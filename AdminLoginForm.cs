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
    public partial class AdminLoginForm : Form
    {
        public AdminLoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (StudentLoginStatus())
            {
                MessageBox.Show("Success!");
                this.Close();
            }
        }

        private bool StudentLoginStatus()
        {
            SqlConnection connSLogin = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=JourneySchool;Integrated Security=True");
            connSLogin.Open();
            SqlCommand cmd = new SqlCommand("Select Password from Admin where Id = @Id", connSLogin);
            cmd.Parameters.AddWithValue("Id", textBox1.Text);
            SqlDataReader reader1;
            reader1 = cmd.ExecuteReader();
            if (reader1.Read())
            {
                if (textBox2.Text == reader1["Password"].ToString())
                {
                    connSLogin.Close();
                    return true;
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
            else
            {
                MessageBox.Show("Invalid UserID");
            }
            connSLogin.Close();
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.RunAdminCreateAccountForm();
        }
    }
}
