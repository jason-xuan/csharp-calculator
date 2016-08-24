using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
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
