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
    public partial class Hospital : Form
    {
        public Hospital()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source = DESKTOP-MQT14CA\\SQLEXPRESS; Initial Catalog = HospitalRecords; Integrated Security = True; Pooling = False");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM HospitalLogin where Username ='" + textBox1.Text + " ' AND Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                new PatientInfo().Show();
            }
            else
                MessageBox.Show("Incorrect username or password");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }
    }
}
