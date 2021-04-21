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

namespace WindowsFormsApp6
{
    public partial class CRUDOperation : Form
    {
        public CRUDOperation()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query="insert into Employee values('"+textBox2.Text+"','"+textBox3.Text+"')";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Record saved");
            populateDataGritView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query = "update Employee set Emp_Name='" + textBox2.Text + "',Mail_ID='" + textBox3.Text + "'where Emp_id="+Convert.ToInt32(textBox1.Text);
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Record Modified");
            populateDataGritView();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query = "delete from Employee where Emp_id=" + Convert.ToInt32(textBox1.Text);
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            sqlcommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Record deleted");
            populateDataGritView();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateDataGritView();
  
        }
        public void populateDataGritView()
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query = "select *from Employee";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
