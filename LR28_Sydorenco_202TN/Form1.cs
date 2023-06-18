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

namespace LR28_Sydorenco_202TN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CopyDirectory(string ss, string sd)
        {
            if (Directory.Exists(ss))
            {
                Directory.CreateDirectory(sd);
                foreach (string file in Directory.GetFiles(ss))
                {
                    string fileName = Path.GetFileName(file);
                    string targetFilePath = Path.Combine(sd, fileName);
                    File.Copy(file, targetFilePath, true);
                }
                foreach (string directory in Directory.GetDirectories(ss))
                {
                    string directoryName = Path.GetFileName(directory);
                    string targetDirectoryPath = Path.Combine(sd, directoryName);
                    CopyDirectory(directory, targetDirectoryPath);
                }
                MessageBox.Show("Каталог скопійовано успішно!");
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                Directory.CreateDirectory(textBox1.Text);
                MessageBox.Show("Каталог створено успішно!");
            }
            else
            {
                MessageBox.Show("Каталог вже існує!");
            }
        }
        //"D:\Fory"

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Text = "Створити каталог";
            button2.Text = "перенести в";
            button3.Text = "Скопіювати в";
            button4.Text = "Видалити каталог";
            button8.Text = "Створити файл";
            button7.Text = "перенести в";
            button6.Text = "Скопіювати в";
            button5.Text = "Видалити файл";
            button9.Text = "Замінити атрибути лівого файла на атрибули прапого";
            button10.Text = "Відредагувати файл";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox2.Text))
            {
                Directory.Move(textBox2.Text, textBox3.Text);
                MessageBox.Show("Каталог перенесено успішно!");
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }
        //"D:\Пари"
        //"D:\Fory"

        private void button3_Click(object sender, EventArgs e)
        {
            CopyDirectory(textBox5.Text, textBox4.Text);
        }
        //"D:\Пари"
        //"D:\Fory"

        private void button4_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(textBox6.Text))
            {
                Directory.Delete(textBox6.Text, true);
                MessageBox.Show("Каталог видалено успішно!");
            }
            else
            {
                MessageBox.Show("Каталог не існує!");
            }
        }       
        //"D:\Fory"

        private void button8_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox12.Text))
            {
                File.Create(textBox12.Text);
                MessageBox.Show("Файл створено успішно!");
            }
            else
            {
                MessageBox.Show("Файл вже існує!");
            }
        }
        //"D:\Fory.txt"

        private void button7_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox11.Text))
            {
                File.Move(textBox11.Text, textBox10.Text);
                MessageBox.Show("Файл перенесено успішно!");
            }
            else
            {
                MessageBox.Show("Файл не існує!");
            }
        }
        //"C:\Users\Lenovo\OneDrive\Рабочий стол\пробник.txt"
        //"D:\Fory.txt"

        private void button6_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox9.Text))
            {
                File.Copy(textBox9.Text, textBox8.Text, true);
                MessageBox.Show("Файл скопійовано успішно!");
            }
            else
            {
                MessageBox.Show("Файл не існує!");
            }
        }
        //"D:\Fory.txt"
        //"C:\Users\Lenovo\OneDrive\Рабочий стол\пробник.txt"

        private void button5_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox7.Text))
            {
                File.Delete(textBox7.Text);
                MessageBox.Show("Файл видалено успішно!");
            }
            else
            {
                MessageBox.Show("Файл не існує!");
            }
        }
        //"D:\Fory.txt"

        private void button9_Click(object sender, EventArgs e)
        {
            FileAttributes attributes = File.GetAttributes(textBox14.Text);
            if (File.Exists(textBox13.Text))
            {
                FileInfo fileInfo = new FileInfo(textBox13.Text);
                fileInfo.Attributes = attributes;
                MessageBox.Show("Атрибути файлу скопійовано з іншого файлу успішно!");
            }
            else
            {
                MessageBox.Show("Файл або каталог не існує!");
            }
        }
        //"C:\Users\Lenovo\OneDrive\Рабочий стол\от насті.txt"
        //"C:\Users\Lenovo\OneDrive\Рабочий стол\пробник.txt"

        private void button10_Click(object sender, EventArgs e)
        {
            if (File.Exists(textBox16.Text))
            {
                using (StreamWriter writer = new StreamWriter(textBox16.Text))
                {
                    string text = richTextBox1.Text;
                    writer.Write(text);
                }
                MessageBox.Show("Файл збережено успішно!");
            }
            else
            {
                MessageBox.Show("Файл не існує!");
            }
        }
        //"C:\Users\Lenovo\OneDrive\Рабочий стол\пробник.txt"


    }
}
