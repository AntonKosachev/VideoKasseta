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
    public partial class List_of_clients : Form
    {
        public List_of_clients()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 back = new Form1();
            back.ShowDialog();
            Close();
        }

        private void List_of_clients_Load(object sender, EventArgs e)
        {
            if (File.Exists(DataBank.pathC))
            {
                string[] rented = File.ReadAllLines(DataBank.pathC);
                int sch = 0;
                for (int i = 0; i < (rented.Length / 3); i++)
                {
                    label1.Text += rented[sch].ToString() + "\n";
                    sch++;
                    label2.Text += rented[sch].ToString() + "\n";
                    sch++;
                    label3.Text += rented[sch].ToString() + "\n";
                    sch++;
                }
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Каталог отсутствует! Пополнить базу клиентов?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Hide();
                    AddClient AK = new AddClient();
                    AK.ShowDialog();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Hide();
                    Form1 back = new Form1();
                    back.ShowDialog();
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Change_Client_Info back = new Change_Client_Info();
            back.ShowDialog();
            Close();
        }
    }
}
