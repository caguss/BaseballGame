using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        Double first, second, number, answer;
        int control;
        string window;
        public Form1()
        {
            InitializeComponent();
        }
       



            //숫자입력
        private void Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            textBox1.Text += btn.Text;
            window += btn.Text;
        }


        // 1/x
        private void DIVONE(object sender, EventArgs e)
        {
            number = Convert.ToDouble(window);
            textBox1.Clear();
            textBox1.Text = Convert.ToString(1 / number);
            window = textBox1.Text;
        }

        // 루트
        private void Sqrt(object sender, EventArgs e)
        {
            number = Convert.ToDouble(window);
            textBox1.Clear();
            textBox1.Text += Math.Sqrt(number);
            window = textBox1.Text;
        }

        //%
        private void divpercent(object sender, EventArgs e)
        {
            number = Convert.ToDouble(window);
            textBox1.Clear();
            textBox1.Text = Convert.ToString(number / 100);
            window = textBox1.Text;
        }


        // 사칙연산
        private void plus(object sender, EventArgs e)
        {
            first = Convert.ToDouble(window);
            textBox1.Clear();
            window = textBox1.Text;
            textBox1.Text = Convert.ToString(first);
            textBox1.Text += "+";

            control = 1;
        }

        private void minus(object sender, EventArgs e)
        {

            first = Convert.ToDouble(window);
            textBox1.Clear();
            window = textBox1.Text;
            textBox1.Text = Convert.ToString(first);
            textBox1.Text += "-";
            control = 2;
        }

        private void multiple(object sender, EventArgs e)
        {

            first = Convert.ToDouble(window);
            textBox1.Clear();
            window = textBox1.Text;
            textBox1.Text = Convert.ToString(first);
            textBox1.Text += "*";
            control = 3;
        }

        private void divide(object sender, EventArgs e)
        {

            first = Convert.ToDouble(window);
            textBox1.Clear();
            window = textBox1.Text;
            textBox1.Text = Convert.ToString(first);
            textBox1.Text += "/";
            control = 4;
        }


        // +&-
        private void PLUSMINUS(object sender, EventArgs e)
        {
            number = Convert.ToDouble(window);
            number -= number * 2;
            textBox1.Clear();
            textBox1.Text = Convert.ToString(number);
            window = textBox1.Text;
        }

        // C
        private void clearall(object sender, EventArgs e)
        {
            textBox1.Clear();
            window = textBox1.Text;
            first = 0;
            second = 0;
            control = 0;
        }
        // =
        private void result(object sender, EventArgs e)
        {
            second = Convert.ToDouble(window);
            textBox1.Text += "=";
            switch (control)
            {
                case 1:
                        answer = first + second; break;
                case 2:
                    answer = first - second; break;
                case 3:
                    answer = first * second; break;
                case 4:
                    answer = first / second; break;
            }
            textBox1.Text += Convert.ToString(answer);
            window = Convert.ToString(answer);
            first = answer;
            control = 0;
        }

        // CE
        private void CLEARPART(object sender, EventArgs e)
        {
            if (window == Convert.ToString(first))
            {
                textBox1.Clear();
                window = textBox1.Text;
                first = 0;
            }
            else
            {
                textBox1.Clear();
                textBox1.Text += Convert.ToString(first);
                window = Convert.ToString(first);
            }
            control = 0;
        }

        private void BACKSPACE(object sender, EventArgs e)
        {
            if(window == Convert.ToString(first))
            {
                first = 0;
            }
            window = textBox1.Text;
            if(window.Length == 0)
            {
                window = "0";
            }
            window = window.Substring(0, window.Length - 1);
            textBox1.Text = window;
            if (textBox1.Text == Convert.ToString(first))
            {
                first = 0;
            }
            control = 0;
        }

    }
}
