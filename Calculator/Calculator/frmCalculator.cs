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
        private List<decimal> backQueue;
        private enum type{add, sub, mult, div};
        private type func;
        public frmCalculator()
        {
            backQueue = new List<decimal>();
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            valid = decimal.TryParse(txtDisplay.Text, out left);
            txtDisplay.Text = "";
            func = type.add;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            valid = decimal.TryParse(txtDisplay.Text, out left);
            txtDisplay.Text = "";
            func = type.sub;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            valid = decimal.TryParse(txtDisplay.Text, out left);
            txtDisplay.Text = "";
            func = type.mult;
            if (!valid)
            {
                txtDisplay.Text = "Error";
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            valid = decimal.TryParse(txtDisplay.Text, out left);
            txtDisplay.Text = "";
            func = type.div;
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

                right = Decimal.Parse(txtDisplay.Text);

                switch (func)
                {
                    case type.add:
                        result = left + right;
                        break;
                    case type.sub:
                        result = left - right;
                        break;
                    case type.mult:
                        result = left * right;
                        break;
                    case type.div:
                        result = left / right;
                        break;
                    default:
                        break;
                }
                backQueue.Add(result);
                endResult();
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
            txtDisplay.Text = txtDisplay.Text + "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "9";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "6";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + "3";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
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
            txtDisplay.Text = backQueue[backQueue.Count-1].ToString();
        }
    }
}
