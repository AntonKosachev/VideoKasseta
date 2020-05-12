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
    public partial class Change_Kass_Info : Form
    {
        public Change_Kass_Info()
        {
            InitializeComponent();
        }
        public void getMainMenu()
        {
            Hide();
            Form1 back = new Form1();
            back.ShowDialog();
            Close();
        }

        public void getBack()
        {
            Hide();
            Change_Kass_Info RI = new Change_Kass_Info();
            RI.ShowDialog();
            Close();
        }

        private void Change_Kass_Info_Load(object sender, EventArgs e)
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
                    getBack();
                }
                else if (dialogResult == DialogResult.No)
                {
                    getMainMenu();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getMainMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] requests = File.ReadAllLines(DataBank.pathK);
            int sch = 0;
            foreach (string s in requests)
            {
                if (s == textBox1.Text) sch++;
            }

            if (sch == 0)
            {
                MessageBox.Show("Такой кассеты в каталоге нет");
            }

            else if (radioButton1.Checked)
            {

                int ind1 = Array.IndexOf(requests, textBox1.Text);
                File.Delete(DataBank.pathK);
                requests[ind1] = textBox2.Text;
                for (int i = 0; i < requests.Length; i++)
                {
                    using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                    {
                        stream.WriteLine(requests[i]);
                    }
                }
                getBack();

            }

            else if (radioButton2.Checked)
            {
                bool isNum = int.TryParse(textBox3.Text, out int num);
                if (isNum && Convert.ToInt32(textBox3.Text)>0)
                {
                    int ind1 = Array.IndexOf(requests, textBox1.Text);
                    File.Delete(DataBank.pathK);
                    requests[ind1 + 1] = textBox3.Text;
                    for (int i = 0; i < requests.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                    getBack();
                }
                else MessageBox.Show("Цена должна быть положительным числом");
            }

            else if (radioButton3.Checked)
            {
                bool isNum = int.TryParse(textBox4.Text, out int num);
                if (isNum && Convert.ToInt32(textBox4.Text)>0)
                {
                    int ind1 = Array.IndexOf(requests, textBox1.Text);
                    File.Delete(DataBank.pathK);
                    requests[ind1 + 2] = textBox4.Text;
                    for (int i = 0; i < requests.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                    getBack();
                }
                else MessageBox.Show("Количество должно быть положительным числом");
            }

            else if (radioButton4.Checked)
            {

                int ind1 = Array.IndexOf(requests, textBox1.Text);
                File.Delete(DataBank.pathK);
                requests[ind1 + 2] = textBox4.Text;
                for (int i = 0; i < requests.Length; i++)
                {
                    if (i != ind1 && i != ind1 + 1 && i != ind1 + 2)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                }
                getBack();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            AddKass go = new AddKass();
            go.ShowDialog();
            Close();
        }
    }
}
