using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timpKR
{
    public partial class Form1 : Form
    {
        public string pathC = @"C:\Program Files\The Best Programm\Clients.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string newDir = Path.Combine(DataBank.root, "The Best Programm");
            Directory.CreateDirectory(newDir);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Catalog go = new Catalog();
            go.ShowDialog();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            CheckExist go = new CheckExist();
            go.ShowDialog();
            Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Hide();
            RentOutNew go = new RentOutNew();
            go.ShowDialog();
            Close();            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide();
            Client_information go = new Client_information();
            go.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            List_of_Rented go = new List_of_Rented();
            go.ShowDialog();
            Close();            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Hide();
            List_of_clients go = new List_of_clients();
            go.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            List_of_requests go = new List_of_requests();
            go.ShowDialog();
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Hide();
            Rent_in go = new Rent_in();
            go.ShowDialog();
            Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            string newDir = Path.Combine(DataBank.root, "The Best Programm");
            Directory.CreateDirectory(newDir);
        }
    }
}
