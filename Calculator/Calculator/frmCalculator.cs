using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCalculator : Form
    {

        private decimal left;
        private decimal right;
        private decimal result;
        private bool valid;
        private bool equals;
        private bool operation;
        private List<decimal> backQueue;
        private enum type{add, sub, mult, div};
        private type func;
        public frmCalculator()
        {
            backQueue = new List<decimal>();
            left = 0m;
            equals = false;
            operation = false;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (result != 0m)
            {
                left = result;
            }
            else
            {
                valid = decimal.TryParse(txtDisplay.Text, out left);
            }
            txtDisplay.Text = "";
            operation = true;
            func = type.add;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            if (result != 0m)
            {
                left = result;
            }
            else
            {
                valid = decimal.TryParse(txtDisplay.Text, out left);
            }
            txtDisplay.Text = "";
            operation = true;
            func = type.sub;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (result != 0m)
            {
                left = result;
            }
            else
            {
                valid = decimal.TryParse(txtDisplay.Text, out left);
            }
            txtDisplay.Text = "";
            operation = true;
            func = type.mult;
            equals = false;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (result != 0m)
            {
                left = result;
            }
            else
            {
                valid = decimal.TryParse(txtDisplay.Text, out left);
            }
            txtDisplay.Text = "";
            operation = true;
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
            operation = true;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                result = Convert.ToDecimal(Math.Round(Math.Sqrt(Double.Parse(txtDisplay.Text)),13));
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
            operation = true;
            if (decimal.TryParse(txtDisplay.Text, out number))
            {
                result = Convert.ToDecimal(1 / (Double.Parse(txtDisplay.Text)));
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
                functions oper = new functions();
                if (!equals)
                {
                    right = Decimal.Parse(txtDisplay.Text);
                }
                equals = true;
                switch (func)
                {
                    case type.add:
                        result = oper.add(left,right);
                        endResult();
                        break;
                    case type.sub:
                        result = oper.sub(left,right);
                        endResult();
                        break;
                    case type.mult:
                        result = oper.multiply(left,right);
                        endResult();
                        break;
                    case type.div:
                        try
                        {
                            result = oper.divide(left, right);
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

                
                backQueue.Add(result);
                left = result;
            }
            else
            {
                txtDisplay.Text = "Error";
            }
        }

        private void endResult()
        {
            txtDisplay.Text = result.ToString();
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "9";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "6";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
            }
            txtDisplay.Text = txtDisplay.Text + "3";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            result = 0m;
            if (equals)
            {
                txtDisplay.Text = "";
                operation = false;
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
        }

        private void btnPositiveNegative_Click(object sender, EventArgs e)
        {
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
                txtDisplay.Text = txtDisplay.Text.Substring(0, txtDisplay.Text.Length - 1);
            }
            catch(Exception exce)
            {
                
            }
        }

        
    }
}
