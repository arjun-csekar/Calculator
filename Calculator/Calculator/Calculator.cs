using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        private decimal left;
        private decimal right;
        private decimal result;

        public decimal Left
        {
            set => left = value;
            get => left;
        }

        public decimal Right
        {
            set => right = value;
            get => right;
        }

        public decimal Result
        {
            set => result = value;
            get => result;
        }

        public virtual decimal Add()
        {
            return left + right;
        }

        public decimal Sub()
        {
            return left - right;
        }

        public decimal Divide()
        {
            return left / right;
        }

        public decimal Multiply()
        {
            return left * right;
        }


    }
}
