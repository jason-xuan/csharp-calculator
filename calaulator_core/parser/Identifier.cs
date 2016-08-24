using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    /// <summary>
    /// 变量结点
    /// </summary>
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

        /// <summary>
        /// 赋值结点给变量赋值时适用的方法
        /// </summary>
        /// <param name="v">
        /// 变量的值
        /// </param>
        public void SetValue(double v)
        {
            value = v;
        }
    }
}
