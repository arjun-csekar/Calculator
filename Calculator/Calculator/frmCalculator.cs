using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {
        private bool valid;
        private bool equals;
        private decimal val = 0m;
        private enum type { add, sub, mult, div };
        private type func;
        private Calculator oper;
        private Calculator mem;
        public frmCalculator()
        {
            oper = new Calculator();
            mem = new MemoryCalculator();
            oper.Left = 0m;
            equals = false;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (oper.Result != 0m)
            {
                oper.Left = oper.Result;
            }
            else
            {
                valid = Validation();
                oper.Left = val;
            }
            txtDisplay.Text = "";
            func = type.add;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (oper.Result != 0m)
            {
                oper.Left = oper.Result;
            }
            else
            {
                valid = Validation();
                oper.Left = val;
            }
            txtDisplay.Text = "";
            func = type.sub;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (oper.Result != 0m)
            {
                oper.Left = oper.Result;
            }
            else
            {
                valid = Validation();
                oper.Left = val;
            }
            txtDisplay.Text = "";
            func = type.mult;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (oper.Result != 0m)
            {
                oper.Left = oper.Result;
            }
            else
            {
                valid = Validation();
                oper.Left = val;
            }
            txtDisplay.Text = "";
            func = type.div;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }
        private void btnSquareRoot_Click(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                oper.Result = Convert.ToDecimal(Math.Round(Math.Sqrt(Double.Parse(txtDisplay.Text)),13));
                endResult();
            }
            else
            {
                txtDisplay.Text = "Error";
            }
        }
        private void btnExponent_Click(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                oper.Result = Convert.ToDecimal(1 / (Double.Parse(txtDisplay.Text)));
                endResult();
            }
            else
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                if (!equals)
                {
                    oper.Right = Decimal.Parse(txtDisplay.Text);
                }
                equals = true;
                switch (func)
                {
                    case type.add:
                        oper.Result = oper.Add();
                        endResult();
                        break;
                    case type.sub:
                        oper.Result = oper.Sub();
                        endResult();
                        break;
                    case type.mult:
                        oper.Result = oper.Multiply();
                        endResult();
                        break;
                    case type.div:
                        try
                        {
                            oper.Result = oper.Divide();
                            endResult();
                        }
                        catch (DivideByZeroException except)
                        {
                            txtDisplay.Text = except.Message;
                        }
                        break;
                    default:
                        break;
                }

                oper.Left = oper.Result;
            }
            else
            {
                txtDisplay.Text = "Error";
            }
        }

        private void endResult()
        {
            txtDisplay.Text = oper.Result.ToString();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "9";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "6";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "3";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                equals = false;
            }
            txtDisplay.Text = txtDisplay.Text + "0";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + ".";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            oper.Left = 0m;
            oper.Right = 0m;
            oper.Result = 0m;
        }

        private void btnPositiveNegative_Click(object sender, EventArgs e)
        {
            oper.Result = 0m;
            if (char.IsNumber(txtDisplay.Text[0])) {
                txtDisplay.Text = "-" + txtDisplay.Text;

            }
            else {
                txtDisplay.Text = txtDisplay.Text.Substring(1);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (!equals)
                {
                    txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
                }
                
            }
            catch(Exception exce)
            {
                
            }
        }

        private void btnMemorySave_Click(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                ((MemoryCalculator)mem).MemoryValue = number;
                txtMemoryDisplay.Text = "M";
            }
            else
            {
                txtDisplay.Text = "Error";
                equals = true;
            }
            
        }

        private void btnMemoryClear_Click(object sender, EventArgs e)
        {
            ((MemoryCalculator)mem).MemoryValue = 0;
            txtMemoryDisplay.Text = "";
        }

        private void btnMemoryRetrieve_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = ((MemoryCalculator)mem).MemoryValue.ToString();
        }

        private void btnMemoryPlus_Click(object sender, EventArgs e)
        {
            decimal number;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                ((MemoryCalculator)mem).DisplayValue = number;
                ((MemoryCalculator)mem).MemoryValue = mem.Add();
            }
            else
            {
                txtDisplay.Text = "Error";
                equals = true;
            }
            
        }

        private bool Validation()
        {
            
            return decimal.TryParse(txtDisplay.Text, out val);
        }
    }
}
