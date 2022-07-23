using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_record
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {



        }

        private void Form1_Load(object sender, EventArgs e)
        {
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-MQT14CA\\SQLEXPRESS; Initial Catalog = HospitalRecords; Integrated Security = True; Pooling = False");
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM HrLogin where Username ='" +textBox1.Text + " ' AND Password = '" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            { 
                this.Hide();
                new Main().Show();
             } 
            else  
                MessageBox.Show("Invalid username or password");  
        }
    }
}
