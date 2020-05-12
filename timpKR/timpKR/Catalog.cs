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
    public partial class Catalog : Form
    {
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public Catalog()
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

        private void Catalog_Load(object sender, EventArgs e)
        {
            try
            {
                string[] readText = File.ReadAllLines(DataBank.pathK);
                int sch = 0;
                for (int i = 0; i < (readText.Length / 3); i++)
                {
                    label1.Text += readText[sch].ToString() + "\n";
                    sch++;
                    label2.Text += readText[sch].ToString() + "\n";
                    sch++;
                    label3.Text += readText[sch].ToString() + "\n";
                    sch++;
                }
            }
            catch (FileNotFoundException)
            {
                DialogResult dialogResult = MessageBox.Show("Каталог отсутствует! Пополнить базу кассет?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Hide();
                    AddKass AK = new AddKass();
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
            Change_Kass_Info go = new Change_Kass_Info();
            go.ShowDialog();
            Close();
        }
    }
}
