using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calaulator_core.scanner;
namespace calaulator_core.parser
{
    /// <summary>
    /// 计算结点，重要节点之一，适用双目运算符
    /// </summary>
    class Operation : Node
    {
        Node first;

        Tag op;

        Node second;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="first">
        /// 表达式左侧结点
        /// </param>
        /// <param name="op">
        /// 运算符
        /// </param>
        /// <param name="second">
        /// 表达式右侧结点
        /// </param>
        public Operation(Node first, Tag op, Node second)
        {
            this.first = first;
            this.op = op;
            this.second = second;
        }

        /// <summary>
        /// 采取惰性计算，需要值时才进行计算，递归取得子节点的值
        /// </summary>
        public override double Value
        {
            get
            {
                switch (op)
                {
                    case Tag.EQ:
                        return first.Value == second.Value ? 1 : 0;
                    case Tag.NE:
                        return first.Value != second.Value ? 1 : 0;
                    case Tag.GE:
                        return first.Value >= second.Value ? 1 : 0;
                    case Tag.LE:
                        return first.Value <= second.Value ? 1 : 0;
                    case (Tag)'>':
                        return first.Value > second.Value ? 1 : 0;
                    case (Tag)'<':
                        return first.Value < second.Value ? 1 : 0;
                    case (Tag)'+':
                        return first.Value + second.Value;
                    case (Tag)'-':
                        return first.Value - second.Value;
                    case (Tag)'*':
                        return first.Value * second.Value;
                    case (Tag)'/':
                        return first.Value / second.Value;
                    case (Tag)'^':
                        return Math.Pow(first.Value, second.Value);
                }
                throw new SyntaxError("operation error");
            }
        }
    }
}
