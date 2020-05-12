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
    public partial class List_of_requests : Form
    {
        public List_of_requests()
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Введите название кассеты, которое нужно удалить из списка");
                Hide();
                List_of_requests go = new List_of_requests();
                go.ShowDialog();
                Close();
            }
            using (StreamWriter stream = new StreamWriter(DataBank.pathLOR, true))
            {
                stream.WriteLine(richTextBox1.Text);
            }
            Hide();
            List_of_requests back = new List_of_requests();
            back.ShowDialog();
            Close();
        }

        private void List_of_requests_Load(object sender, EventArgs e)
        {
            try
            {
                string[] readText = File.ReadAllLines(DataBank.pathLOR);
                for (int i = 0; i < readText.Length; i++)
                {
                    label3.Text += readText[i].ToString() + "\n";
                }
            }
            catch (FileNotFoundException)
            {
                DialogResult dialogResult = MessageBox.Show("Список заявок пуст! \nПополнить?", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Hide();
                    Add_Request go = new Add_Request();
                    go.ShowDialog();
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

        private void button3_Click(object sender, EventArgs e)
        {
            string[] requests = File.ReadAllLines(DataBank.pathLOR);
            int ind1 = Array.IndexOf(requests, richTextBox2.Text);
            File.Delete(DataBank.pathLOR);
            for (int i = 0; i < requests.Length; i++)
            {
                if (i != ind1)
                {
                    using (StreamWriter stream = new StreamWriter(DataBank.pathLOR, true))
                    {
                        stream.WriteLine(requests[i]);
                    }
                }
            }
            Hide();
            List_of_requests go = new List_of_requests();
            go.ShowDialog();
            Close();
        }
    }
}
