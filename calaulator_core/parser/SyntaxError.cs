using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calaulator_core.parser
{
    class SyntaxError : ApplicationException
    {
        public SyntaxError(string message) : base(message)
        {

        }
    }
}
