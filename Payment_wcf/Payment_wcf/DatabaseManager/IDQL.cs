using Payment_wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment_wcf.DatabaseManager
{
    internal interface IDQL
    {
        List<Customer> Select();
    }
}
