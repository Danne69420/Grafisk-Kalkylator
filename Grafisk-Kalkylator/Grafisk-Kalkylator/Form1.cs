using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Grafisk_Kalkylator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            List<Button> buttons = new List<Button> { button, button0, button1, button2, button3, button4, button5, button6, button7, button8, button9, buttonEquals, buttonPlus, buttonMinus, buttonTimes, buttonDecimal, button, button, };
            InitializeComponent();
        }
        


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private string Plus(decimal number1, decimal number2)
        {
            decimal sum = number1 + number2;
            return sum.ToString();
        }
        private string Minus(decimal number1, decimal number2)
        {
            decimal sum = number1 - number2;
            return sum.ToString();
        }
        private string Times(decimal number1, decimal number2)
        {
            decimal sum = number1 * number2;
            return sum.ToString();
        }
        private void UpdateDisplay(Button sender, EventArgs e)
        {
            if (sender == buttonEquals)
            {
                Display.Text = Calculate();
            }
            else if(sender == buttonClear)
            {
                Display.Text = string.Empty;
            }
            else
            {
                string newText = sender.Text;
                Display.Text = Display.Text + newText;

            }

        }
        /// <summary>
        /// Performs a calculation based on Display.Text
        /// </summary>
        /// <returns>Calculated number as string to be displayed</returns>
        private string Calculate()
        {
            string result = string.Empty;

            string Calculation = Display.Text;

            try
            {
                result = new DataTable().Compute(Calculation, null).ToString();
            }
            catch (Exception e)
            {
                if (e is System.Data.EvaluateException)
                {
                    Calculation = Calculation.Replace(".", ",");
                    List<string> calculations = new List<string>();
                    calculations = Calculation.Split("^").ToList<string>();
                    decimal[] PowResults = new decimal[calculations.Count];

                    int i = 0;
                    foreach (string calculation in calculations)
                    {
                        List<string> newCalculations = new List<string>();
                        List<string> newCalculations2 = new List<string>();
                        newCalculations = calculations[i].Split('+', '-', '*', '/').ToList<string>();
                        decimal x = Convert.ToDecimal(newCalculations.Last().Trim());
                        newCalculations2 = calculations[i+1].Split('+', '-', '*', '/').ToList<string>();
                        decimal y = Convert.ToDecimal(newCalculations2.First().Trim());
                        PowResults[i] = Convert.ToDecimal(Math.Pow(decimal.ToDouble(x), decimal.ToDouble(y)));
                        decimal number = PowResults[i];
                        string checker = x.ToString() + "^" + y.ToString();
                        if (Calculation.Contains(checker) == true)
                        {
                            Calculation = Calculation.Replace(checker, PowResults[i].ToString());
                        }
                    }
                    Calculation = Calculation.Replace(",", ".");

                    return Calculation;
                }

                return "ERROR";
            }
            result = result.Replace(",", ".");
            return result;
        }
        private void button9_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button9, e);
        }

        private void button0_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button0, e);
        }

        private void buttonDecimal_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonDecimal, e);
        }

        private void buttonEquals_Click(object sender, EventArgs e)     
        {
            UpdateDisplay(buttonEquals, e);
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonPlus, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button3, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button2, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button1, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button4, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button5, e);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button6, e);
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonMinus, e);
        }

        private void buttonTimes_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonTimes, e);
        }

        private void button_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button, e);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button8, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button7, e);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            UpdateDisplay(button17, e);
        }

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonDivide, e);
        }

        private void buttonExponent_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonExponent, e);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            UpdateDisplay(buttonClear, e);
        }
    }
}
