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
        Double first=0, second=0, number=0, answer=0;
        int control;
        string window; //문자열
        public Form1()
        {
            InitializeComponent();
        }

        private void FrmCalc_KeyDown(object sender, KeyEventArgs e)
        {
            string numPad = string.Empty;
            if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
            {
                numPad = (((int)e.KeyCode) - 96).ToString();

                if (first == 0)
                    first = Convert.ToDouble(numPad);
                else
                    first = int.Parse(first.ToString() + numPad);
                textBox1.Text = first.ToString();
            }
            else
            {
                if (e.KeyCode == Keys.Add)
                    this.button11.PerformClick();
                else if (e.KeyCode == Keys.Subtract)
                    this.button12.PerformClick();
                else if (e.KeyCode == Keys.Multiply)
                    this.button13.PerformClick();
                else if (e.KeyCode == Keys.Divide)
                    this.button14.PerformClick();
            }
        }


        //숫자입력
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            window += btn.Text;
            textBox1.Text += btn.Text;
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
        private void Divpercent(object sender, EventArgs e)
        {
            number = Convert.ToDouble(window);
            textBox1.Clear();
            textBox1.Text = Convert.ToString(number / 100);
            window = textBox1.Text;
        }

        private void Calculate(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "+":
                    {
                        if (window == "")
                        { }
                        else
                        {
                            first = first+ Convert.ToDouble(window);
                        }
                        window = "";
                        textBox1.Text = Convert.ToString(first);
                        textBox1.Text += "+";

                        control = 1;
                        break;
                    }
                case "-":
                    {
                        if (window == "")
                        { }
                        else
                        {
                            first = first - Convert.ToDouble(window);
                        }
                        window = "";
                        textBox1.Text = Convert.ToString(first);
                        textBox1.Text += "-";
                        control = 2;

                        break;
                    }
                case "÷":
                    {
                        if (window == "")
                        { }
                        else
                        {
                            first = Convert.ToDouble(window);
                        }
                        window = "";
                        textBox1.Text = Convert.ToString(first);
                        textBox1.Text += "÷";
                        control = 3;

                        break;
                    }
                case "×":
                    {
                        if (window == "")
                        { }
                        else
                        {
                            first = Convert.ToDouble(window);
                        }
                        window = "";
                        textBox1.Text = Convert.ToString(first);
                        textBox1.Text += "×";
                        control = 4;

                        break;
                    }
                case "=":
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
                                answer = first / second; break;
                            case 4:
                                answer = first * second; break;
                        }
                        textBox1.Text += Convert.ToString(answer);
                        first = answer;
                        second = 0;
                        control = 0;
                        window = "";
                        break;
                    }
            }
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
        private void Clearall(object sender, EventArgs e)
        {
            first = 0;
            second = 0;
            control = 0;
            textBox1.Clear();
            window = textBox1.Text;
            
        }



        // =
        private void Result(object sender, EventArgs e)
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
            second = 0;
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
