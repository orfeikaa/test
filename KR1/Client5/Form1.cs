using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");

            DataSet ds = client.GetData("", "");
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Update();

            DataSet ds1 = client.GetClients("");

            button2.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetData(dateTimePicker2.Value.ToString("yyyy-MM-dd"), dateTimePicker3.Value.ToString("yyyy-MM-dd"));

            dataGridView1.DataSource = ds.Tables["Shyrnal"];
            dataGridView1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetClients("");

            dataGridView1.DataSource = ds.Tables["Klient"];
            dataGridView1.Update();

            button2.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetServices(0, 0);

            dataGridView1.DataSource = ds.Tables["Yslygi"];
            dataGridView1.Update();

            button2.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetData("", "");

            dataGridView1.DataSource = ds.Tables["Shyrnal"];
            dataGridView1.Update();

            button2.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetClients(textBox1.Text);

            dataGridView1.DataSource = ds.Tables["Klient"];
            dataGridView1.Update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client("tcp");
            DataSet ds = client.GetServices(Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown2.Value));

            dataGridView1.DataSource = ds.Tables["Yslygi"];
            dataGridView1.Update();
        }
    }
}
