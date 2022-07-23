using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_record
{
    public partial class PatientInfo : Form
    {
        public PatientInfo()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source = DESKTOP-MQT14CA\\SQLEXPRESS; Initial Catalog = HospitalRecords; Integrated Security = True; Pooling = False");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into PInfo values (@Name, @Address, @PhoneNumber, @DOB, @BloodGroup, @GenoType, @Occupation)", con);
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox7.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
                cmd.Parameters.AddWithValue("@DOB", DateTime.Parse(textBox2.Text));
                cmd.Parameters.AddWithValue("@BloodGroup", textBox4.Text);
                cmd.Parameters.AddWithValue("@Genotype", textBox5.Text);
                cmd.Parameters.AddWithValue("@Occupation", textBox6.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("You have successfully submitted customer's info");
            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable table = new DataTable();
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-MQT14CA\\SQLEXPRESS; Initial Catalog = HospitalRecords; Integrated Security = True; Pooling = False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM PInfo ", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(table);
            dataGridView1.DataSource = table;
        
        }
    }
}
