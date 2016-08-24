using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    /// <summary>
    /// 语法分析树的基类
    /// 定义公共方法
    /// 也是大部分函数返回的接口
    /// </summary>
    public abstract class Node
    {
        public abstract double Value
        {
            get;
        }
    }
}
