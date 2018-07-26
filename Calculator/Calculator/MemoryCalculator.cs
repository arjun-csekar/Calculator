using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class MemoryCalculator : Calculator
    {

        private decimal memoryValue = 0m;
        private decimal displayValue = 0m;

        public decimal MemoryValue
        {
            set => memoryValue = value;
            get => memoryValue;
        }

        public decimal DisplayValue
        {
            set => displayValue = value;
        }

        public override decimal Add() => memoryValue + displayValue;

    }
}
