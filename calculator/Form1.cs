using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0;
        String operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((TextBox_Result.Text == "0") || (isOperationPerformed))
                TextBox_Result.Clear();

            isOperationPerformed = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!TextBox_Result.Text.Contains("."))
                    TextBox_Result.Text = TextBox_Result.Text + button.Text;

            }
            else
                TextBox_Result.Text = TextBox_Result.Text + button.Text;


        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultValue != 0)
            {
                ButtonEquilty.PerformClick();
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {

                operationPerformed = button.Text;
                resultValue = Double.Parse(TextBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private void Clear_Click(object sender, EventArgs e)
        {


            TextBox_Result.Text = "0";
        }

        private void ClearEmd_Click(object sender, EventArgs e)
        {
            TextBox_Result.Text = "0";
            resultValue = 0;
        }

        private void Equity_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    TextBox_Result.Text = (resultValue + Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "-":
                    TextBox_Result.Text = (resultValue - Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "*":
                    TextBox_Result.Text = (resultValue * Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                case "/":
                    TextBox_Result.Text = (resultValue / Double.Parse(TextBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = Double.Parse(TextBox_Result.Text);
            labelCurrentOperation.Text = "";
        }
    }
}
