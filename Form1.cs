using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Double result = 0;
        string operation = string.Empty;
        string fstNum = string.Empty;
        string secNum = string.Empty;
        bool enterValue = false;


        public Form1()
        {
            InitializeComponent();
        }
        private void BtnMathOperation_Click(object sender, EventArgs e)
        {
            if (enterValue)
                return;

            if (result != 0 )
                BtnEquals.PerformClick();
            else
                result = Double.Parse(TxtDisplay1.Text);

            Button button = (Button)sender;
            operation = button.Text;
            enterValue = true;

            if (TxtDisplay1.Text != "0")
            {
                TxtDisplay2.Text = $"{result} {operation}";
            }
        }
        private void BtnEquals_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text != string.Empty)
            {
                if (TxtDisplay1.Text == "0")
                    TxtDisplay2.Text = string.Empty;

                switch(operation)
                {
                    case "+":
                        TxtDisplay1.Text = (result + Double.Parse(secNum)).ToString();
                        break;
                    
                    case "-":
                        TxtDisplay1.Text = (result - Double.Parse(secNum)).ToString();
                        break;
                    
                    case "×":
                        TxtDisplay1.Text = (result * Double.Parse(secNum)).ToString();
                        break;
                    
                    case "÷":
                        TxtDisplay1.Text = (result / Double.Parse(secNum)).ToString();
                        break;

                    default:
                        break;
                }

                result = Double.Parse(TxtDisplay1.Text);

                if (operation != string.Empty)
                {
                    TxtDisplay2.Text = $"{fstNum} {operation} {secNum} =";
                 
                }

                operation = string.Empty;

                fstNum = string.Empty;
                secNum = string.Empty;
            }
            
        }
        private void btnBackSpace_click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text.Length > 0)
                TxtDisplay1.Text = TxtDisplay1.Text.Remove(TxtDisplay1.Text.Length - 1, 1);

            if (TxtDisplay1.Text == string.Empty) 
                TxtDisplay1.Text = "0";
        }
        private void BtnC_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
            TxtDisplay2.Text = string.Empty;
            result = 0;

        }
        private void BtnCE_Click(object sender, EventArgs e)
        {
            TxtDisplay1.Text = "0";
        }
        private void btnOperations_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Text;

            switch(operation)
            {
                case "2√x":
                    TxtDisplay2.Text = $"√({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Math.Sqrt(Double.Parse(TxtDisplay1.Text)));
                    break;

                case "x^2":
                    TxtDisplay2.Text = $"sqr({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Math.Pow(Double.Parse(TxtDisplay1.Text), 2));
                    break;
                
                case "1/x":
                    TxtDisplay2.Text = $"1/({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(1.0/Double.Parse(TxtDisplay1.Text));
                    break;
                
                case "%":
                    TxtDisplay2.Text = $"%({TxtDisplay1.Text})";
                    TxtDisplay1.Text = Convert.ToString(Double.Parse(TxtDisplay1.Text) / Convert.ToDouble(100));
                    break;
                
                case "+/-":
                    TxtDisplay1.Text = Convert.ToString(Double.Parse(TxtDisplay1.Text) * -1);
                    break;

                default:
                    break;
            }
        }
        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (TxtDisplay1.Text == "0" || enterValue) 
                TxtDisplay1.Text = string.Empty;

            enterValue = false;
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                if (!TxtDisplay1.Text.Contains("."))
                    TxtDisplay1.Text = TxtDisplay1.Text + button.Text;
            }
            else 
                TxtDisplay1.Text = TxtDisplay1.Text + button.Text;

            if (fstNum == string.Empty)
                fstNum = TxtDisplay1.Text;
            else
                secNum = TxtDisplay1.Text;
        }
    }
}
