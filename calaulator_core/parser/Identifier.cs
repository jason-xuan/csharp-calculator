using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    class Identifier : Node
    {
        private string name;
        private double? value;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public Identifier(string name)
        {
            this.name = name;
        }
        public override double Value
        {
            get
            {
                if (value.HasValue)
                {
                    return value.Value;
                }
                else
                {
                    throw new SyntaxError("variable has no value.");
                }
            }
        }
        public void SetValue(double v)
        {
            value = v;
        }
    }
}
