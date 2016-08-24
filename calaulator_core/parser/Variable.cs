using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    /// <summary>
    /// 有具体值的结点，对应Tag为Real(double)或Num(int)的Token
    /// </summary>
    class Variable : Node
    {
        private double value;

        public Variable(double v)
        {
            value = v;
        }

        public override double Value
        {
            get
            {
                return value;
            }
        }
    }
}
