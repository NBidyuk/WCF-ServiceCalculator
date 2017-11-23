using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceHost.CalcService;

namespace ServiceClient
{
    public partial class Form1 : Form
    {
        private double num1;
        
        private double saveNum;
        private double result;
        private string currentNum;
        private  bool dec;
        private int operation = 0; // operation code +1,-2,*3,/4,root5,%6
        private bool calculating;

       public Form1()
        {
            InitializeComponent();

            dec = false;
            num1 = 0;
       
            saveNum = 0;
        currentNum = "";
            result = 0;
            calculating = false;
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            dec = false;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;
            currentNum += pressedButton.Text;
            textBox1.Text = currentNum;
            textBox1.Refresh();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                this.ClientSize = new System.Drawing.Size(412, 328);
                this.textBox1.Size = new System.Drawing.Size(359, 42);
                this.Refresh();
            }
            else
            {
                this.ClientSize = new System.Drawing.Size(283, 328);
                this.textBox1.Size = new System.Drawing.Size(239, 42);
                this.Refresh();

            }
        }

        private void MSbutton_Click(object sender, EventArgs e)
        {
            saveNum = Convert.ToDouble(currentNum);
        }

        private void MCbutton_Click(object sender, EventArgs e)
        {
            saveNum = 0;
        }

        private void CEbutton_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Cbutton_Click(object sender, EventArgs e)
        {
            currentNum = "";
        }

        private void Erasebutton_Click(object sender, EventArgs e)
        {
            if(currentNum.Length>1)
            currentNum = currentNum.Substring(0, currentNum.Length - 1);
            textBox1.Text = currentNum;
            textBox1.Refresh();
        }

        private void Divbutton_Click(object sender, EventArgs e)
        {
            if(calculating)
            ResultButton.PerformClick();
            operation = 4;
            num1 = Convert.ToDouble(currentNum);
            currentNum = "";
            calculating = true;
        }

        

        private void Multbutton_Click(object sender, EventArgs e)
        {
            if (calculating)
                ResultButton.PerformClick();
            operation = 3;
            num1 = Convert.ToDouble(currentNum);
            currentNum = "";
            calculating = true;
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            if (calculating)
                ResultButton.PerformClick();
            operation = 2;
            num1 = Convert.ToDouble(currentNum);
            currentNum = "";
            calculating = true;
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            if (calculating)
                ResultButton.PerformClick();
            operation = 1;
            num1 = Convert.ToDouble(currentNum);
            currentNum = "";
            calculating = true;
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            CalculatorClient simpleCalc;
            
            switch (operation)
            {
                case 0:
                    break;
                case 1:
                    simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
                    result = simpleCalc.Sum(num1, Convert.ToDouble(currentNum));
                    simpleCalc.Close();
                    break;
                case 2:
                    simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
                    result = simpleCalc.Minus(num1, Convert.ToDouble(currentNum));
                    simpleCalc.Close();
                    break;
                case 3:
                    simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
                    result = simpleCalc.Mult(num1, Convert.ToDouble(currentNum));
                    simpleCalc.Close();
                    break;
                case 4:
                    try
                    { simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
                        result = simpleCalc.Div(num1, Convert.ToDouble(currentNum));
                        simpleCalc.Close();
                    }
                    catch (DivideByZeroException ex)
                    {
                        MessageBox.Show("Attempt to devide by zero was made!!!");
                    }

                    break;
              

            }
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            calculating = false;
            result = 0;
         
            operation = 0;
            
        }

        private void MRbutton_Click(object sender, EventArgs e)
        {
            currentNum = saveNum.ToString();
        }

        private void Reset ()
        {
            //dec = false;
            num1 = 0;
           
            saveNum = 0;
            currentNum = "";
            textBox1.Clear();
            result = 0;
            
        }

        private void Mplusbutton_Click(object sender, EventArgs e)
        {
            saveNum += Convert.ToDouble(currentNum);
        }

        private void Mminusbutton_Click(object sender, EventArgs e)
        {
            saveNum -= Convert.ToDouble(currentNum);
        }

        private void Rootbutton_Click(object sender, EventArgs e)
        {
            CalculatorClient simpleCalc;
            simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
            result = simpleCalc.SquareRoot(Convert.ToDouble(currentNum));
            simpleCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
           


        }

        private void Percentbutton_Click(object sender, EventArgs e)
        {

            CalculatorClient simpleCalc;
            simpleCalc = new CalculatorClient("BasicHttpBinding_ICalculator");
            result = simpleCalc.Percent(num1, Convert.ToDouble(currentNum));
            simpleCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
           
        }

        private void sinbutton_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Sin(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
            
        }

        private void pow2button_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Square(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;

        }

        private void cosbutton_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Cos(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
        }

        private void pow3button_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Triple(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
        }

        private void tanbutton_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Tan(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Pow(num1,Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;

        }

        private void nbutton_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Factorial(Convert.ToInt32(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;

        }

        private void logbutton_Click(object sender, EventArgs e)
        {
            EngineerCalculatorClient engineCalc;
            engineCalc = new EngineerCalculatorClient("NetTcpBinding_IEngineerCalculator");
            result = engineCalc.Log(Convert.ToDouble(currentNum));
            engineCalc.Close();
            currentNum = result.ToString();
            textBox1.Text = currentNum;
            textBox1.Refresh();
            num1 = result;
            result = 0;
        }
    }
}
