using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace calaulator_core.parser
{
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
