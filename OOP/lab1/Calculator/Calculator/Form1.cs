using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Calculator
{
    public interface ICalculator
    {
        void Form1_Load(object sender, EventArgs e);
        void zeroButton_Click(object sender, EventArgs e);
        void oneButton_Click(object sender, EventArgs e);
        void twoButton_Click(object sender, EventArgs e);
        void threeButton_Click(object sender, EventArgs e);
        void fourButton_Click(object sender, EventArgs e);
        void fiveButton_Click(object sender, EventArgs e);
        void sixButton_Click(object sender, EventArgs e);
        void sevenButton_Click(object sender, EventArgs e);
        void eightButton_Click(object sender, EventArgs e);
        void nineButton_Click(object sender, EventArgs e);
        void clearButton_Click(object sender, EventArgs e);
        void minusButton_Click(object sender, EventArgs e);
        void errorTick_Tick(object sender, EventArgs e);
        void andButton_Click(object sender, EventArgs e);
        void orButton_Click(object sender, EventArgs e);
        void xorButton_Click(object sender, EventArgs e);
        void notButton_Click(object sender, EventArgs e);
        void equalButton_Click(object sender, EventArgs e);

    }
    public partial class Calculator : Form, ICalculator
    {

        private long firstNum;
        private long result;
        private byte operation = 0;
        private bool firstEqual = true;
        private bool flag = false;


        public Calculator()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            errorTick.Stop();
        }

        public void zeroButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && examplePanel.Text != "" && examplePanel.Text != "-" && !errorTick.Enabled)
            {
                examplePanel.Text += 0;
                memory.Text += 0;
            }
        }

        public void oneButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 1;
                memory.Text += 1;
            }
        }

        public void twoButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 2;
                memory.Text += 2;
            }
        }

        public void threeButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 3;
                memory.Text += 3;
            }
        }

        public void fourButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 4;
                memory.Text += 4;
            } 
        }

        public void fiveButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 5;
                memory.Text += 5;
            }
                
        }

        public void sixButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 6;
                memory.Text += 6;
            }
                
        }

        public void sevenButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 7;
                memory.Text += 7;
            }
                
        }

        public void eightButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 8;
                memory.Text += 8;
            }
                
        }

        public void nineButton_Click(object sender, EventArgs e)
        {
            if (firstEqual && !errorTick.Enabled)
            {
                examplePanel.Text += 9;
                memory.Text += 9;
            }
        }

        public void clearButton_Click(object sender, EventArgs e)
        {
            if (errorTick.Enabled)
            {
                errorTick.Stop();
                examplePanel.ForeColor = Color.Black;
                memory.ForeColor = Color.Black;
            }
            examplePanel.Clear();
            memory.Text = "";
            decBox.Text = "DEC ";
            binBox.Text = "BIN ";
            hexBox.Text = "HEX ";
            octBox.Text = "OCT ";
            firstEqual = true;
        }
        public void minusButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstEqual && !errorTick.Enabled)
                {
                    if (examplePanel.Text == "")
                    {
                        examplePanel.Text += '-';
                        memory.Text += "-";
                    }
                    else
                    {
                        throw new Exception("Minus isn't valid");
                    }
                }               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
        }

        public void errorTick_Tick(object sender, EventArgs e)
        {
            if (examplePanel.ForeColor == Color.Black)
            {
                examplePanel.ForeColor = Color.Red;
                memory.ForeColor = Color.Red;
            }
            else
            {
                examplePanel.ForeColor = Color.Black;
                memory.ForeColor = Color.Black;
            }

        }

        public void andButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstEqual && !errorTick.Enabled)
                {
                    if (examplePanel.Text == "")
                    {
                        throw new Exception("Misuse of operations or long number");
                    }
                    firstNum = long.Parse(examplePanel.Text);
                    examplePanel.Text = "";
                    operation = 1;
                    memory.Text += " AND ";
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
        }

        public void orButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstEqual && !errorTick.Enabled)
                {
                    if (examplePanel.Text == "")
                    {
                        throw new Exception("Misuse of operations");
                    }
                    firstNum = long.Parse(examplePanel.Text);
                    examplePanel.Text = "";
                    operation = 2;
                    memory.Text += " OR ";
                }    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
        }

        public void xorButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstEqual && !errorTick.Enabled)
                {
                    if (examplePanel.Text == "")
                    {
                        throw new Exception("Misuse of operations");
                    }
                    firstNum = long.Parse(examplePanel.Text);
                    examplePanel.Text = "";
                    operation = 3;
                    memory.Text += " XOR ";
                }
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
        }

        public void notButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstEqual && !errorTick.Enabled)
                {
                    if (examplePanel.Text == "")
                    {
                        throw new Exception("Misuse of operations");
                    }
                    firstNum = long.Parse(examplePanel.Text);
                    examplePanel.Text = "";
                    memory.Text += " NOT ";

                    result = ~firstNum;
                    decBox.Text += result.ToString();
                    binBox.Text += Convert.ToString(result, 2);
                    hexBox.Text += Convert.ToString(result, 16);
                    octBox.Text += Convert.ToString(result, 8);
                    firstEqual = false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
        }

        public void equalButton_Click(object sender, EventArgs e)
        {
            try
            {
                flag = false;
                if (firstEqual && !errorTick.Enabled)
                {
                    switch (operation)
                    {
                        case 1:
                            {
                                result = firstNum & long.Parse(examplePanel.Text);
                                decBox.Text += result.ToString();
                                binBox.Text += Convert.ToString(result, 2);
                                hexBox.Text += Convert.ToString(result, 16);
                                octBox.Text += Convert.ToString(result, 8);
                                break;
                            }
                        case 2:
                            {
                                result = firstNum | long.Parse(examplePanel.Text);
                                decBox.Text += result.ToString();
                                binBox.Text += Convert.ToString(result, 2);
                                hexBox.Text += Convert.ToString(result, 16);
                                octBox.Text += Convert.ToString(result, 8);
                                break;
                            }
                        case 3:
                            {
                                result = firstNum ^ long.Parse(examplePanel.Text);
                                decBox.Text += result.ToString();
                                binBox.Text += Convert.ToString(result, 2);
                                hexBox.Text += Convert.ToString(result, 16);
                                octBox.Text += Convert.ToString(result, 8);
                                break;
                            }
                        default:
                            {
                                flag = true;
                                break;
                            }
                    }
                    firstEqual = flag;
                    operation = 0;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                examplePanel.Text = "ERROR!";
                memory.Text = "ERROR!";
                errorTick.Start();
            }
            
        }

    } 
}
