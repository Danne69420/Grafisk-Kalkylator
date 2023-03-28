/// <summary>
/// Daniel Kindvall
/// SY21
/// Examination grafisk kalkylator
/// /// </summary>

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
        /// <summary>
        /// constructor, initializes the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// This method takes a long string of calculations that contains a Power.
        /// It splits off the power from the rest of the string and calculates it, and puts the string back together again with the base and exponent of the power replaced with the result of it.
        /// </summary>
        /// <param name="Calculation"></param>
        /// the string to calculate
        /// <returns></returns>
        private string PowerOf(string Calculation)
        {
            //datatable.Calculate uses . but Math.Pow wants a , 
            Calculation = Calculation.Replace(".", ",");    
            List<string> calculations = new List<string>();
            //first split into before and after ^. "2^2" becomes "2","2" "2+2^2" becomes "2+2", "2"
            calculations = Calculation.Split("^").ToList<string>(); 
            decimal[] PowResults = new decimal[calculations.Count];

            int i = 0;
            foreach (string calculation in calculations)
            {
                try
                {
                    List<string> newCalculations = new List<string>();
                    List<string> newCalculations2 = new List<string>();
                    newCalculations = calculations[i].Split('+', '-', '*', '/').ToList<string>();
                    decimal x = Convert.ToDecimal(newCalculations.Last().Trim());
                    newCalculations2 = calculations[i + 1].Split('+', '*', '/').ToList<string>();     //we don't split at - because it would break negative exponents
                    decimal y = Convert.ToDecimal(newCalculations2.First().Trim());
                    PowResults[i] = Convert.ToDecimal(Math.Pow(decimal.ToDouble(x), decimal.ToDouble(y)));
                    decimal number = PowResults[i];
                    string checker = x.ToString() + "^" + y.ToString();
                    if (Calculation.Contains(checker) == true)
                    {
                        Calculation = Calculation.Replace(checker, PowResults[i].ToString());
                    }
                }
                catch
                {
                    return "ERROR";
                }
            }
            Calculation = Calculation.Replace(",", ".");
            return Calculation;
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
                if (e is EvaluateException)     //Datatabale.Compute does not work with exponents, if we get this exception that means there's a ^ symbol
                {
                    return PowerOf(Calculation);
                }
                
                return "ERROR";
            }
            result = result.Replace(",", ".");
            return result;
        }
        /// <summary>
        /// is called when any button is clicked. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {

            Button Sender = (Button)sender;

            if (Sender == buttonEquals)
            {
                Display.Text = Calculate();
            }
            else if (Sender == buttonClear)
            {
                Display.Text = string.Empty;
            }
            else if (Sender == buttonDEL)
            {
                Display.Text = Display.Text.Remove(Display.Text.Length-1);
            }
            else
            {
                string newText = Sender.Text;
                Display.Text = Display.Text + newText;
            }
        }

    }
}
