using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace calaulator_core.parser
{
    /// <summary>
    /// 符号表
    /// Table以单例的方式成为全局变量
    /// </summary>
    class SymbolTable
    {
        private static Hashtable table_;

        public static Hashtable Table
        {
            get
            {
                return table_;
            }
        }

        static SymbolTable()
        {
            table_ = new Hashtable();
        }
    }
}
