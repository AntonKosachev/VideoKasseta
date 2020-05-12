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
    public partial class RentOutNew : Form
    {
        public RentOutNew()
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
            RentOutNew RI = new RentOutNew();
            RI.ShowDialog();
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() == string.Empty || richTextBox2.Text.Trim() == string.Empty || richTextBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Обязательно заполните все данные!");
                getBack();
            }

            else if (File.Exists(DataBank.pathC) && File.Exists(DataBank.pathK))
            {
                int schK = 0;  //есть ли такая кассета?
                string[] kassets = File.ReadAllLines(DataBank.pathK);
                foreach (string s in kassets)
                {
                    if (s == richTextBox1.Text) schK++;
                }

                int schC = 0;  //есть ли вообще такой клиент?
                string[] clients = File.ReadAllLines(DataBank.pathC);
                int indC = Array.IndexOf(clients,richTextBox2.Text);
                foreach (string s in clients)
                {
                    if (s == richTextBox2.Text) schC++;
                }

                if (schC != 0 && schK != 0)
                {
                    int indK = Array.IndexOf(kassets, richTextBox1.Text);
                    int price = DataBank.find_Price(richTextBox1.Text);
                    int uses = Convert.ToInt32(clients[Array.IndexOf(clients, richTextBox2.Text) + 2]);  //сколько раз клиент пользовался прокатом
                    int days = Convert.ToInt32(richTextBox3.Text);

                    kassets[indK + 2] = (Convert.ToInt32(kassets[indK + 2]) - 1).ToString();  //уменьшение количества таких кассет в калатоге на 1
                    File.Delete(DataBank.pathK);
                    for (int i = 0; i < kassets.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                        {
                            stream.WriteLine(kassets[i]);
                        }
                    }

                    clients[indC + 2] = (Convert.ToInt32(clients[indC + 2]) + 1).ToString();  //увеличение кол-ва использований клиента на 1
                    File.Delete(DataBank.pathC);
                    for (int i = 0; i < clients.Length; i++)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                        {
                            stream.WriteLine(clients[i]);
                        }
                    }

                    using (StreamWriter stream = new StreamWriter(DataBank.pathR, true))  //добавление кассеты в список арендованных
                    {
                        stream.WriteLine(richTextBox1.Text);
                        stream.WriteLine(richTextBox2.Text);
                        stream.WriteLine(DateTime.Today.ToShortDateString());  //когда взял
                        stream.WriteLine(richTextBox3.Text);   //на сколько дней взял
                        stream.WriteLine(DateTime.Today.AddDays(Convert.ToInt32(richTextBox3.Text)).ToShortDateString());  //когда вернет
                    }

                    if (uses >= 5)
                    {
                        MessageBox.Show("Клиент является постоянным \nЦена составит: " + (days) * (price * 0.8) + " с учётом скидки 20% \nОставить залог в размере " + price * 10);
                        getMainMenu();
                    }
                    else
                    {
                        MessageBox.Show("Цена составит: " + (days) * (price) + " \nОставить залог в размере " + price * 10);
                        getMainMenu();
                    }
                }

                else if (schK == 0)
                {
                    MessageBox.Show("Такой кассеты нет!");
                    getBack();
                }
                else if (schC == 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Такого клиента в базе нет!\nДобавить клиента в базу?", "Some Title", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        Hide();
                        AddClient AC = new AddClient();
                        AC.ShowDialog();
                        Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        Hide();
                        RentOutNew back = new RentOutNew();
                        back.ShowDialog();
                        Close();
                    }
                }

            }

            else if (!File.Exists(DataBank.pathK))
            {
                MessageBox.Show("Отсутствует каталок кассет!");
                getMainMenu();
            }
            else if (!File.Exists(DataBank.pathC))
            {
                MessageBox.Show("Отсутствует каталок клиентов!");
                getMainMenu();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            getMainMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() == string.Empty || richTextBox2.Text.Trim() == string.Empty || richTextBox3.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Обязательно заполните все данные!");
                getBack();
            }

            else if (File.Exists(DataBank.pathC) && File.Exists(DataBank.pathK))
            {
                try
                {
                    int schK = 0;  //есть ли такая кассета?
                    string[] kassets = File.ReadAllLines(DataBank.pathK);
                    foreach (string s in kassets)
                    {
                        if (s == richTextBox1.Text) schK++;
                    }

                    int schC = 0;  //есть ли вообще такой клиент?
                    string[] clients = File.ReadAllLines(DataBank.pathC);
                    foreach (string s in clients)
                    {
                        if (s == richTextBox2.Text) schC++;
                    }

                    if (schC != 0 && schK != 0)
                    {
                        int price = DataBank.find_Price(richTextBox1.Text);
                        int uses = Convert.ToInt32(clients[Array.IndexOf(clients, richTextBox2.Text) + 2]);  //сколько раз клиент пользовался прокатом
                        int days = Convert.ToInt32(richTextBox3.Text);

                        if (uses >= 5)
                        {
                            MessageBox.Show("Клиент является постоянным \nЦена составит: " + (days) * (price * 0.8) + " с учётом скидки 20% \nЗалог составит " + price * 10);
                        }
                        else
                        {
                            MessageBox.Show("Цена составит: " + (days) * (price) + " \nЗалог составит " + price * 10);
                        }
                    }


                    else if (schK == 0)
                    {
                        MessageBox.Show("Такой кассеты нет!");
                    }
                    else if (schC == 0)
                    {
                        int days = Convert.ToInt32(richTextBox3.Text);
                        int price = DataBank.find_Price(richTextBox1.Text);
                        MessageBox.Show("Такого клиента в базе нет!\nЦена составляет: " + (days) * (price) + " \nЗалог составляет " + price * 10);
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат введённых данных!");
                }
            }
        }

        private void RentOutNew_Load(object sender, EventArgs e)
        {
            if (!File.Exists(DataBank.pathK))
            {
                MessageBox.Show("Отсутствует каталок кассет!");
                getMainMenu();
            }
            else if (!File.Exists(DataBank.pathC))
            {
                DialogResult dialogResult = MessageBox.Show("Отсутствует каталог клиентов. Пополнить?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Hide();
                    AddClient AC = new AddClient();
                    AC.ShowDialog();
                    Close();
                }
                else if (dialogResult == DialogResult.No)
                {
                    Hide();
                    RentOutNew back = new RentOutNew();
                    back.ShowDialog();
                    Close();
                }
            }
        }
    }
}
