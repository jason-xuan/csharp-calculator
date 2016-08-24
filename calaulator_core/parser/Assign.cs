using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    class Assign : Node
    {
        Identifier left;
        Node right;
        public Assign(Node left, Node right)
        {
            this.left = (Identifier)left;
            this.right = right;
        }
        public override double Value
        {
            get
            {
                double v = right.Value;
                left.SetValue(v);
                SymbolTable.Table[left.Name] = left;
                return v;
            }
        }
    }
}
