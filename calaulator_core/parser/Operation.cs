using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calaulator_core.scanner;
namespace calaulator_core.parser
{
    class Operation : Node
    {
        Node first;
        Tag op;
        Node second;
        public Operation(Node first, Tag op, Node second)
        {
            this.first = first;
            this.op = op;
            this.second = second;
        }
        public override double Value
        {
            get
            {
                switch (op)
                    {
                        case Tag.EQ: return first.Value == second.Value ? 1 : 0;
                        case Tag.NE: return first.Value != second.Value ? 1 : 0;
                        case Tag.GE: return first.Value >= second.Value ? 1 : 0;
                        case Tag.LE: return first.Value <= second.Value ? 1 : 0;
                        case (Tag)'>': return first.Value > second.Value ? 1 : 0;
                        case (Tag)'<': return first.Value < second.Value ? 1 : 0;
                        case (Tag)'+': return first.Value + second.Value;
                        case (Tag)'-': return first.Value - second.Value;
                        case (Tag)'*': return first.Value * second.Value;
                        case (Tag)'/': return first.Value / second.Value;
                        case (Tag)'^':  return Math.Pow(first.Value, second.Value);
                    }
                    throw new SyntaxError("operation error");
            }
        }
    }
}
