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
    public partial class ComboboxLoadData : Form
    {
        public ComboboxLoadData()
        {
            InitializeComponent();
        }

        

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query = "select Emp_id from Employee";
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcommand);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DataRow row=dt.NewRow();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "Emp_id";

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString());
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=craftsman;Integrated Security=True");
            connection.Open();
            string query;
            query = "select *from Employee where Emp_id=" + Convert.ToInt32(comboBox1.SelectedValue.ToString());
            SqlCommand sqlcommand = new SqlCommand(query, connection);
            SqlDataReader sdr = sqlcommand.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    textBox1.Text = sdr.GetString(1);
                    textBox2.Text = sdr.GetString(2);
                }
            }
            sdr.Close();
        }
    }
}
