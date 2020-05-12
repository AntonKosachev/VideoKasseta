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
    public partial class AddKass : Form
    {
        public AddKass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == string.Empty || textBox1.Text.Trim() == string.Empty || textBox2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Обязательно заполните все данные о кассете!");
                Hide();
                AddKass Ak = new AddKass();
                Ak.ShowDialog();
                Close();
            }

            else
            {
                bool isNum1 = int.TryParse(textBox2.Text, out int num1);
                bool isNum2 = int.TryParse(textBox3.Text, out int num2);

                if (isNum1 && isNum2 && Convert.ToInt32(textBox2.Text)>0 && Convert.ToInt32(textBox3.Text) > 0)
                {                   
                    using (StreamWriter stream = new StreamWriter(DataBank.pathK, true))
                    {
                        stream.WriteLine(textBox1.Text);
                        stream.WriteLine(textBox2.Text);
                        stream.WriteLine(textBox3.Text);
                    }
                    Hide();
                    Change_Kass_Info back = new Change_Kass_Info();
                    back.ShowDialog();
                    Close();
                }
                else if (!isNum1)
                {
                    MessageBox.Show("Цена должна являться положительным числом.");
                }
                else if (!isNum2)
                {
                    MessageBox.Show("Количесвто должно являться положительным числом.");
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
    }
}
