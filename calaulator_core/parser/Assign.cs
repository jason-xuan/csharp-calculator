using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    /// <summary>
    /// 赋值结点，由左值（变量）与右值（表达式）组成
    /// 计算并返回值的同时将变量的值保存在符号表中
    /// </summary>
    class Assign : Node
    {
        /// <summary>
        /// 变量
        /// </summary>
        Identifier left;

        /// <summary>
        /// 表达式
        /// </summary>
        Node right;

        /// <summary>
        /// 唯一构造函数
        /// </summary>
        /// <param name="left">
        /// 变量
        /// </param>
        /// <param name="right">
        /// 表达式
        /// </param>
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
