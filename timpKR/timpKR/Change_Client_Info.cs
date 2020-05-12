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
    public partial class Change_Client_Info : Form
    {
        public Change_Client_Info()
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
            Change_Client_Info RI = new Change_Client_Info();
            RI.ShowDialog();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            AddClient back = new AddClient();
            back.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] requests = File.ReadAllLines(DataBank.pathC);
            int sch = 0;
            foreach (string s in requests)
            {
                if (s == textBox1.Text) sch++;
            }
            if (sch == 0)
            {
                MessageBox.Show("Такого клиента в базе нет");
            }

            else if (radioButton1.Checked)
            {

                bool isNum = int.TryParse(textBox2.Text, out int num);
                if (isNum && Convert.ToInt32(textBox2.Text)>0)
                {
                    int ind1 = Array.IndexOf(requests, textBox1.Text);
                    File.Delete(DataBank.pathC);
                    requests[ind1] = textBox2.Text;
                    for (int i = 0; i < requests.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                    getBack();

                }
                else MessageBox.Show("Номер телефона должен являться положительным числом");
            }

            else if (radioButton2.Checked)
            {
                int ind1 = Array.IndexOf(requests, textBox1.Text);
                File.Delete(DataBank.pathC);
                requests[ind1 + 1] = textBox3.Text;
                for (int i = 0; i < requests.Length; i++)
                {
                    using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                    {
                        stream.WriteLine(requests[i]);
                    }
                }
                Hide();
                getBack();
            }

            else if (radioButton3.Checked)
            {
                bool isNum = int.TryParse(textBox4.Text, out int num);

                if (isNum && Convert.ToInt32(textBox4.Text)>0)
                {
                    int ind1 = Array.IndexOf(requests, textBox1.Text);
                    File.Delete(DataBank.pathC);
                    requests[ind1 + 2] = textBox4.Text;
                    for (int i = 0; i < requests.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                    getBack();
                }
                else MessageBox.Show("Количество обращений должно быть положительным числом");
            }

            else if (radioButton4.Checked)
            {
                int ind1 = Array.IndexOf(requests, textBox1.Text);
                File.Delete(DataBank.pathC);
                for (int i = 0; i < requests.Length; i++)
                {
                    if (i != ind1 && i != ind1 + 1 && i != ind1 + 2)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                        {
                            stream.WriteLine(requests[i]);
                        }
                    }
                }
                getBack();
            }
        }

        private void Change_Client_Info_Load(object sender, EventArgs e)
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getMainMenu();
        }
    }
}
