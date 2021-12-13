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

namespace AZS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        void GetList()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-L4LGTTQ\SQLEXPRESS;Initial Catalog=azs;Integrated Security=True");
            da = new SqlDataAdapter("Select *Car_Filling_Station", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Car_Filling_Station");
            dataGridView1.DataSource = ds.Tables["Car_Filling_Station"];
            con.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "azsDataSet.Car_Filling_Station". При необходимости она может быть перемещена или удалена.
            this.car_Filling_StationTableAdapter.Fill(this.azsDataSet.Car_Filling_Station);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                try
                {
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = string.Format("insert into Car_Filling_Station (list_Address, list_Station_ID, list_data_Name, list_data_Price, list_data_AmountOfFuel) values('{0}','{1}','{2}','{3}','{4}')",
                    textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GetList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
