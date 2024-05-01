using System;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (isOperationPerformed)
            {
                textBox_Result.Clear();
                isOperationPerformed = false;
            }

            if (button.Text == ",")
            {
                if (!textBox_Result.Text.Contains(","))
                {
                    textBox_Result.Text += button.Text;
                }
            }
            else
            {
                if (textBox_Result.Text != "0")
                    textBox_Result.Text += button.Text;
                else
                {
                    textBox_Result.Text = "";
                    textBox_Result.Text = button.Text;
                }
            }
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(operationPerformed))
            {
                resultValue = Calculate(resultValue, double.Parse(textBox_Result.Text), operationPerformed);
                operationPerformed = button.Text;
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
            else
            {
                operationPerformed = button.Text;
                resultValue = double.Parse(textBox_Result.Text);
                labelCurrentOperation.Text = resultValue + " " + operationPerformed;
                isOperationPerformed = true;
            }
        }

        private double Calculate(double firstValue, double secondValue, string operation)
        {
            switch (operation)
            {
                case "+":
                    return firstValue + secondValue;
                case "-":
                    return firstValue - secondValue;
                case "*":
                    return firstValue * secondValue;
                case "/":
                    if (secondValue != 0)
                    {
                        return firstValue / secondValue;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(operationPerformed))
            {
                resultValue = Calculate(resultValue, double.Parse(textBox_Result.Text), operationPerformed);
                textBox_Result.Text = resultValue.ToString();
                labelCurrentOperation.Text = "";
                operationPerformed = "";
                isOperationPerformed = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            resultValue = 0;
            labelCurrentOperation.Text = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            switch (operationPerformed)
            {
                case "+":
                    resultValue += double.Parse(textBox_Result.Text);
                    break;
                case "-":
                    resultValue -= double.Parse(textBox_Result.Text);
                    break;
                case "*":
                    resultValue *= double.Parse(textBox_Result.Text);
                    break;
                case "/":
                    double divisor = double.Parse(textBox_Result.Text);
                    if (divisor != 0)
                    {
                        resultValue /= divisor;
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                default:
                    break;
            }
            textBox_Result.Text = resultValue.ToString();
            labelCurrentOperation.Text = "";
            resultValue = 0;
            operationPerformed = "";
            isOperationPerformed = false;
        }
    }
}