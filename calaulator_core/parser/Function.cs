using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using calaulator_core.scanner;

namespace calaulator_core.parser
{
    class Function : Node
    {
        /// <summary>
        /// 方程的类型
        /// </summary>
        Tag function;

        /// <summary>
        /// 调用函数的参数
        /// </summary>
        Node expr;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="func">
        /// 方程的类型
        /// </param>
        /// <param name="expr">
        /// 调用函数的参数
        /// </param>
        public Function(Tag func,Node expr)
        {
            function = func;
            this.expr = expr;
        }

        /// <summary>
        /// 通过数学库计算函数的值
        /// </summary>
        public override double Value
        {
            get
            {
                switch (function)
                {
                    case Tag.SIN:
                        return Math.Sin(expr.Value);
                    case Tag.COS:
                        return Math.Cos(expr.Value);
                    case Tag.TAN:
                        return Math.Tan(expr.Value);
                    case Tag.LN:
                        return Math.Log(expr.Value);
                    case Tag.LOG:
                        return Math.Log10(expr.Value);
                }
                throw new SyntaxError("wrong function type.");
            }
        }
    }
}
