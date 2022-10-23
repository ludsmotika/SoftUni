using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrakZad_Daniel_Anastasov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int sumOfNumbers = 0;
            int countOfNumbers = 0;
            for (int i =100 ; i < 1000; i++)
            {
                int number = i;
                int sumOfNumber = 0;
                while (number>0)
                {
                    sumOfNumber+=number % 10;
                    number /= 10;
                }
                bool isPrime = true;
                for (int k = 2; k <=Math.Sqrt(sumOfNumber); k++)
                {
                    if (sumOfNumber%k==0)
                    {
                        isPrime = false;
                    }
                }
                if (isPrime == true)
                {
                    sumOfNumbers += i;
                    countOfNumbers++;
                    comboBox1.Items.Add(i);
                }
            }
            
            if (checkBox2.Checked==true)
            {
                textBox1.Text=$"Count: {countOfNumbers}";
            }
            if (checkBox3.Checked==true)
            {
                textBox2.Text = $"Sum: {sumOfNumbers}";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            comboBox1.Items.Clear();
        }
    }
}
