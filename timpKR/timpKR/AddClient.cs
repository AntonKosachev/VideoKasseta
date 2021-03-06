﻿using System;
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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text.Trim() == string.Empty || richTextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Обязательно заполните все данные о клиенте!");
                Hide();
                AddClient AC = new AddClient();
                AC.ShowDialog();
                Close();
            }
            else
            {
                if (!File.Exists(DataBank.pathC))
                {
                    File.Create(DataBank.pathC).Close();
                    
                }
                bool isNum = int.TryParse(richTextBox3.Text, out int num);

                if (isNum && Convert.ToInt32(richTextBox3.Text)>0)
                {
                    int schC = 0;  //есть ли вообще такой клиент?
                    string[] clients = File.ReadAllLines(DataBank.pathC);
                    foreach (string s in clients)
                    {
                        if (s == richTextBox3.Text) schC++;
                    }

                    if (schC == 0)
                    {
                        using (StreamWriter stream = new StreamWriter(DataBank.pathC, true))
                        {
                            stream.WriteLine(richTextBox3.Text);
                            stream.WriteLine(richTextBox1.Text);
                            stream.WriteLine(0);
                        }
                        Hide();
                        Form1 back = new Form1();
                        back.ShowDialog();
                        Close();
                    }
                    else if (schC != 0) MessageBox.Show("Клиент с таким номером уже существует!");
                }

                else
                {
                    MessageBox.Show("Номер должен являться положительным числом!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 back = new Form1();
            back.ShowDialog();
            Close();
        }

        private void AddClient_Load(object sender, EventArgs e)
        {

        }
    }
}
